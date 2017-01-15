using System;
using WPILib;
using WPILib.Commands;

namespace ChopShop2016.Subsystems
{
    [WPILib.Extras.AttributedCommandModel.ExportSubsystem]
    public sealed class ShooterLock : Subsystem, IDisposable
    {
        DoubleSolenoid solenoid = new DoubleSolenoid(RobotMap.Solenoid.ShooterLockForward, RobotMap.Solenoid.ShooterLockReverse);

        public void Lock()
        {
            solenoid.Set(DoubleSolenoid.Value.Forward);
        }

        public void Unlock()
        {
            solenoid.Set(DoubleSolenoid.Value.Reverse);
        }

        public bool Locked
        {
            get { return solenoid.Get() == DoubleSolenoid.Value.Forward; }
            set { if (value) Lock(); else Unlock(); }
        }

        protected override void InitDefaultCommand() { }

        public void Dispose()
        {
            solenoid.Dispose();
        }
    }
}
