using System;
using WPILib;
using WPILib.Commands;
using WPILib.Interfaces;

namespace ChopShop2016.Subsystems
{
    [WPILib.Extras.AttributedCommandModel.ExportSubsystem]
    public sealed class AimShooter : Subsystem, IDisposable
    {
        readonly Victor motor = new Victor(RobotMap.Pwm.ShooterAngleMotor);
        readonly AnalogInput pot = new AnalogInput(RobotMap.Analog.ShooterPotAngle);

        const double voltsPerDegree = .0927;
        const double degreesPerVolt = 1 / voltsPerDegree;
        const double zeroDegreeVoltage = .553;
        const double minAngle = 41.5;
        const double hardStopAngle = 41.5;

        PIDSpeedController anglePID;

        // Initialize your subsystem here
        public AimShooter()
        {
            pot.PIDSourceType = PIDSourceType.Displacement;

            anglePID = new PIDSpeedController(pot, motor, "anglePID", "AimShooter");

            UpdatePIDConstants();
            anglePID.Set(0);
        }

        private void UpdatePIDConstants()
        {

            var AngleP = Preferences.Instance.GetDouble(RobotMap.Prefs.ShooterAngleP, 0);
            var AngleI = Preferences.Instance.GetDouble(RobotMap.Prefs.ShooterAngleI, 0);
            var AngleD = Preferences.Instance.GetDouble(RobotMap.Prefs.ShooterAngleD, 0);
            var AngleF = Preferences.Instance.GetDouble(RobotMap.Prefs.ShooterAngleF, 0);
            anglePID.SetPID(AngleP, AngleI, AngleD, AngleF);
        }

        public double ShooterAngle
        {
            get { return hardStopAngle + ((pot.GetVoltage() - zeroDegreeVoltage) * degreesPerVolt); }
            set
            {
                var angle = Math.Max(value, minAngle);
                anglePID.Set((angle - hardStopAngle) * voltsPerDegree);
            }
        }

        public double PotVoltage => pot.GetVoltage();

        public void MoveToAngle(double angle)
        {
            if (angle > ShooterAngle)
            {
                motor.Set(.4);
            }
            else
            {
                motor.Set(-0.12);
            }
        }

        public void MoveToAngleParallel(double angle)
        {
            if (angle > ShooterAngle)
            {
                motor.Set(.3);
            }
            else
            {
                motor.Set(-.1);
            }
        }

        public void MaintainAngle(int angle)
        {
            if (angle > (ShooterAngle + 1))
            {
                MoveToAngle(angle);
            }
            else
            {
                Stop();
            }
        }

        public void Stop()
        {
            motor.Set(0.0);
        }


        protected override void InitDefaultCommand() { }

        public void Dispose()
        {
            motor.Dispose();
            pot.Dispose();
            anglePID.Dispose();
        }
    }
}
