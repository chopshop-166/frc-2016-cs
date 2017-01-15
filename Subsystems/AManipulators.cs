using System;
using WPILib;
using WPILib.Commands;

namespace ChopShop2016.Subsystems
{
    [WPILib.Extras.AttributedCommandModel.ExportSubsystem]
    public sealed class AManipulators : Subsystem, IDisposable
    {
        DoubleSolenoid solenoid = new DoubleSolenoid(RobotMap.Solenoid.AManipulatorForward, RobotMap.Solenoid.AManipulatorReverse);

        public void Toggle()
        {
            if (solenoid.Get() == DoubleSolenoid.Value.Reverse)
            {
                solenoid.Set(DoubleSolenoid.Value.Forward);
            }
            else
            {
                solenoid.Set(DoubleSolenoid.Value.Reverse);
            }
        }

        public void Lower()
        {
            solenoid.Set(DoubleSolenoid.Value.Reverse);
        }

        public void Raise()
        {
            solenoid.Set(DoubleSolenoid.Value.Forward);
        }

        protected override void InitDefaultCommand() { }

        public void Dispose()
        {
            solenoid.Dispose();
        }
    }
}
