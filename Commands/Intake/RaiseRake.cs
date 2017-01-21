using WPILib.Commands;

namespace ChopShop2016.Commands.Intake
{
    public class RaiseRake : InstantCommand
    {
        public RaiseRake()
        {
            Requires(ChopShop2016.intake);
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.intake.RaiseRake();
        }
    }
}
