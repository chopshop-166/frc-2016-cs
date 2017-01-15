using CTRE;
using NetworkTables;
using System;
using WPILib;
using WPILib.Commands;
using WPILib.Interfaces;
using WPILib.SmartDashboard;

namespace ChopShop2016.Subsystems
{
    [WPILib.Extras.AttributedCommandModel.ExportSubsystem]
    public sealed class Drive : Subsystem, IDisposable
    {
        #region Constants
        // calculated based on wheel diameter and encoder specs
        double distancePerPulse = (System.Math.PI * 10.25) / 1024.0;
        double gyroConstant = -0.3 / 10.0;
        double driveSpeedModifierConstant = .7;

        const double joyDeadZone = 0.1;
        const double turnSpeedScalar = 0.3; // was .35
        const double shotZone = .05;

        const double alignSpeedDeadzone = 1.0;
        const double brakeSpeed = .1;
        const double driveLeftMotorsForwardSpeed = 1.0;
        const double alignSpeed = .17;

        const double highGearValue = 0.0;
        const double lowGearValue = 1.0;
        #endregion

        public double turnToGoalAngle = 0;
        double referenceAngle = 0;
        public bool isReversed = false;
        double gyroVal = 0;
        double joystickTurnOffset;

        #region Devices
        readonly CANTalon leftTopMotor = new CANTalon(RobotMap.CAN.leftTopDrive);
        readonly CANTalon leftBotMotor = new CANTalon(RobotMap.CAN.leftBotDrive);
        readonly CANTalon rightTopMotor = new CANTalon(RobotMap.CAN.rightTopDrive);
        readonly CANTalon rightBotMotor = new CANTalon(RobotMap.CAN.rightBotDrive);

        Servo leftTransmissionServo = new Servo(RobotMap.Pwm.leftTransmissionServoPort);
        Servo rightTransmissionServo = new Servo(RobotMap.Pwm.rightTransmissionServoPort);

        Encoder leftEncoder = new Encoder(RobotMap.Digital.leftEncoderA, RobotMap.Digital.leftEncoderB);
        Encoder rightEncoder = new Encoder(RobotMap.Digital.rightEncoderA, RobotMap.Digital.rightEncoderB);

        IGyro gyro = new AnalogGyro(RobotMap.Analog.gyroPort);
        AnalogInput frontUltrasonic = new AnalogInput(RobotMap.Analog.frontUltrasonic);

        MultiSpeedController leftDrive;
        MultiSpeedController rightDrive;

        PIDSpeedController leftPID;
        PIDSpeedController rightPID;

        RobotDrive tankDrive;
        #endregion

        public enum Gear
        {
            Low,
            Neutral,
            High,
        }

        Gear _gear;

        public Drive()
        {
            leftDrive = new MultiSpeedController(new ISpeedController[] { leftTopMotor, leftBotMotor }, "Drive", "Left Multi Drive");
            rightDrive = new MultiSpeedController(new ISpeedController[] { rightTopMotor, rightBotMotor }, "Drive", "Right Multi Drive");

            leftPID = new PIDSpeedController(leftEncoder, leftDrive, "Drive", "Left PID");
            rightPID = new PIDSpeedController(rightEncoder, rightDrive, "Drive", "Right PID");

            tankDrive = new RobotDrive(leftDrive, rightDrive);
        }

        private void TankDrive(double left, double right, bool squaredinputs)
        {
            if (isReversed)
            {
                tankDrive.TankDrive(-left, -right, squaredinputs);
            }
            else
            {
                tankDrive.TankDrive(left, right, squaredinputs);
            }
        }

        private bool IsDead(double value)
        {
            return Math.Abs(value) < joyDeadZone;
        }

        public void driveWithJoysticks(double left, double right)
        {

            SmartDashboard.PutBoolean("isReversed", isReversed);

            if (!IsDead(right) && !IsDead(left) && Math.Sign(right) == Math.Sign(left))
            {
                // The joysticks have the same sign and are out of the deadzone
                TankDrive(((right + left) / 2.0), ((right + left) / 2.0), false);
                SmartDashboard.PutString("Drive State", "Straight");
            }
            else if (!IsDead(right) || !IsDead(left))
            {
                // the joysticks have opposite signs and are out of the deadzone
                joystickTurnOffset = (left - right) * turnSpeedScalar;
                tankDrive.TankDrive(joystickTurnOffset, -joystickTurnOffset, false);
                SmartDashboard.PutString("Drive State", "Turning");
            }
            else
            {
                // the joysticks are within the deadzone
                SmartDashboard.PutString("Drive State", "Stopped");
            }
        }

        public void initializeGear()
        {
            if (leftTransmissionServo.Get() > .6)
            {
                GearValue = Gear.High;
            }
            else
            {
                GearValue = Gear.Low;
            }
        }

        public Gear GearValue
        {
            get { return _gear; }
            set
            {
                _gear = value;
                SmartDashboard.PutString("Gear", _gear.ToString());
                switch (_gear)
                {
                    case Gear.High:
                        leftTransmissionServo.Set(highGearValue);
                        rightTransmissionServo.Set(highGearValue);
                        leftEncoder.DistancePerPulse = distancePerPulse;
                        rightEncoder.DistancePerPulse = distancePerPulse;
                        break;
                    case Gear.Low:
                        leftTransmissionServo.Set(lowGearValue);
                        rightTransmissionServo.Set(lowGearValue);
                        leftEncoder.DistancePerPulse = distancePerPulse * 2.5;
                        rightEncoder.DistancePerPulse = distancePerPulse * 2.5;
                        break;
                    case Gear.Neutral:
                        leftTransmissionServo.Set(0.5);
                        rightTransmissionServo.Set(0.5);
                        break;
                }
            }
        }

        public void spinRight(double speed)
        {
            spin(-speed);
        }

        public void spinLeft(double speed)
        {
            spin(speed);
        }

        private void spin(double speed)
        {
            leftTopMotor.Set(speed);
            leftBotMotor.Set(speed);
            rightTopMotor.Set(speed);
            rightBotMotor.Set(speed);
        }

        public void turnToGoalWhileDriving(double offset, double speed = alignSpeed)
        {
            var alignScalar = Math.Min(offset * 2, .23);
            if (offset > shotZone)
            {
                tankDrive.TankDrive(-speed - alignScalar, speed);
            }
            else if (offset < -shotZone)
            {
                tankDrive.TankDrive(-speed, speed + alignScalar);
            }
            else
            {
                Stop();
            }
        }

        public void turnToGoal(double offset)
        {
            turnToGoal(offset, .18);
        }

        public void turnToGoalParallel(double offset)
        {
            turnToGoal(offset, .135);
        }

        private void turnToGoal(double offset, double speed)
        {
            if (offset > 0)
            {
                spin(-speed);
            }
            else
            {
                spin(speed);
            }
        }

        public void driveWithGyro(double left, double right)
        {
            double rightPower = right * driveSpeedModifierConstant;
            double leftPower = left * driveSpeedModifierConstant;
            double power = (rightPower + leftPower) / 1.5;
            if (Math.Abs(right) > .05 || Math.Abs(left) > .05)
            {
                TankDrive(power - getGyroOffset(), power + getGyroOffset(), false);
            }
        }

        public double getGyroOffset()
        {
            gyroVal = GetGyro() * gyroConstant;
            if (Math.Abs(gyroVal) > (1.0 - driveSpeedModifierConstant))
            {
                // sets gyroVal to either 1 or -1
                gyroVal = (1.0 - driveSpeedModifierConstant) * Math.Abs(gyroVal) / gyroVal;
            }
            return gyroVal;
        }

        public void PrintGyroRate()
        {
            SmartDashboard.PutNumber("Gyro Rate", GyroRate);
        }

        public double GyroRate => gyro.GetRate();

        public void Brake()
        {
            var turnRate = gyro.GetRate(); // Get the gyro rate in degrees/second
            if (turnRate > alignSpeedDeadzone)
            {
                SetAll(brakeSpeed); // Spin with low power to the left
            }
            else if (turnRate < -alignSpeedDeadzone)
            {
                SetAll(-brakeSpeed); // Spin with low power to the right
            }
            else
            {
                Stop(); // Send 0 power to MCs
            }
        }

        public bool IsRobotSpinning => Math.Abs(gyro.GetRate()) >= alignSpeedDeadzone;

        public void Stop()
        {
            SetAll(0.0);
        }

        private void SetAll(double speed)
        {
            leftTopMotor.Set(speed);
            leftBotMotor.Set(speed);
            rightTopMotor.Set(speed);
            rightBotMotor.Set(speed);
        }

        public void DriveLeftMotorsForward()
        {
            leftTopMotor.Set(-driveLeftMotorsForwardSpeed);
            leftBotMotor.Set(-driveLeftMotorsForwardSpeed);
        }

        public void DriveRightMotorsForward()
        {
            rightTopMotor.Set(driveLeftMotorsForwardSpeed);
            rightBotMotor.Set(driveLeftMotorsForwardSpeed);
        }

        public void setPIDConstants()
        {
            double p = 0.025;
            double i = 0.0;
            double d = 0.0;
            double f = 1.0;

            rightPID.SetPID(p, i, d, f);
            leftPID.SetPID(p, i, d, f);
        }

        public void ResetEncoders()
        {
            leftEncoder.Reset();
            rightEncoder.Reset();
        }

        public double GetLeftEncoder()
        {
            // returns the rate of the left encoder
            SmartDashboard.PutNumber("Left Encoder", leftEncoder.GetRate());
            return leftEncoder.GetRate();
        }

        public double GetRightEncoder()
        {
            // returns the rate of the right encoder
            SmartDashboard.PutNumber("Right Encoder", rightEncoder.GetRate());
            return rightEncoder.GetRate();
        }

        // returns the distance traveled by the right encoder
        public double EncoderDistance => -leftEncoder.GetDistance();

        public double GetGyro()
        {
            var angle = gyro.GetAngle() + referenceAngle;
            SmartDashboard.PutNumber("Right Encoder", angle);
            return angle;
        }

        public void ResetGyro()
        {
            // resets the gyro
            gyro.Reset();
            referenceAngle = 0;
        }

        public double FrontUltrasonicVoltage => frontUltrasonic.GetVoltage();

        protected override void InitDefaultCommand() { }

        public void Dispose()
        {
            leftTopMotor.Dispose();
            rightTopMotor.Dispose();
            leftBotMotor.Dispose();
            rightBotMotor.Dispose();
            frontUltrasonic.Dispose();
            gyro.Dispose();
            leftDrive.Dispose();
            rightDrive.Dispose();
            leftEncoder.Dispose();
            leftPID.Dispose();
            leftTransmissionServo.Dispose();
            rightEncoder.Dispose();
            rightPID.Dispose();
            rightTransmissionServo.Dispose();
            tankDrive.Dispose();
        }
    }
}
