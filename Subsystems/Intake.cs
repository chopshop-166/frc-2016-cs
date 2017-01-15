using System;
using WPILib;
using WPILib.Commands;

namespace ChopShop2016.Subsystems
{
    [WPILib.Extras.AttributedCommandModel.ExportSubsystem]
    public sealed class Intake : Subsystem, IDisposable
    {
        readonly DoubleSolenoid Actuator = new DoubleSolenoid(RobotMap.Solenoid.IntakeSolenoidForwards, RobotMap.Solenoid.IntakeSolenoidBackwards);
        readonly Victor IntakeCIM = new Victor(RobotMap.Pwm.MainIntakeVictor);
        readonly Victor IntakeCIM2 = new Victor(RobotMap.Pwm.CrossIntakeVictor);

        #region Motor Methods
        public void MotorForward()
        {
            IntakeCIM.Set(Preferences.Instance.GetDouble("Forward", 1.0));
            IntakeCIM2.Set(Preferences.Instance.GetDouble("Forward2", -1.0));
        }

        public void MotorReverse()
        {
            IntakeCIM.Set(Preferences.Instance.GetDouble("Reverse", -1.0));
            IntakeCIM2.Set(Preferences.Instance.GetDouble("Reverse2", 1.0));
        }

        public void MotorStop()
        {
            IntakeCIM.Set(0.0);
            IntakeCIM2.Set(0.0);
        }
        #endregion

        #region Solenoid Methods

        public void LowerRake()
        {
            Actuator.Set(DoubleSolenoid.Value.Reverse);
        }

        public void RaiseRake()
        {
            Actuator.Set(DoubleSolenoid.Value.Forward);
        }

        public void ToggleIntakeSolenoid()
        {
            if (Actuator.Get() == DoubleSolenoid.Value.Forward)
            {
                LowerRake();
            }
            else
            {
                RaiseRake();
            }
        }
        #endregion

        #region Intake Final Commands
        public void StartLoadProcess()
        {
            LowerRake();
            MotorForward();
        }
        #endregion

        protected override void InitDefaultCommand() { }

        public void Dispose()
        {
            Actuator.Dispose();
            IntakeCIM.Dispose();
            IntakeCIM2.Dispose();
        }
    }
}
