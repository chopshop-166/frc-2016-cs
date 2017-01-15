using System;
using WPILib;
using WPILib.Commands;
using WPILib.SmartDashboard;

namespace ChopShop2016.Subsystems
{
    [WPILib.Extras.AttributedCommandModel.ExportSubsystem]
    public sealed class IntakeRoller : Subsystem, IDisposable
    {
        const double TicksPerRotation = 1024.0;
        Victor motor = new Victor(RobotMap.Pwm.RollerVictor);
        AnalogInput intakeSensor = new AnalogInput(RobotMap.Analog.IntakeSensor);

        public void Start(double speed)
        {
            motor.Set(speed);
        }

        public void Stop()
        {
            motor.Set(0.0);
            motor.StopMotor();
        }

        public void PrintVoltage()
        {
            SmartDashboard.PutNumber("Intake Sensor", TicksPerRotation);
        }

        public double IRVoltage => intakeSensor.GetVoltage();

        public bool IsBallLoaded => IRVoltage >= 2.0;

        public bool IsBallShot => IRVoltage <= 2.0;

        protected override void InitDefaultCommand() { }

        public void Dispose()
        {
            motor.Dispose();
            intakeSensor.Dispose();
        }
    }
}
