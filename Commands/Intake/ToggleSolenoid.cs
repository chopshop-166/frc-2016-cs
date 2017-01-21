using WPILib.Commands;

namespace ChopShop2016.Commands.Intake
{
    public class ToggleSolenoid : InstantCommand
    {
        public ToggleSolenoid()
        {
            Requires(ChopShop2016.intake);
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.intake.ToggleIntakeSolenoid();
        }
    }
}
