using WPILib.Commands;

namespace ChopShop2016.Commands.Roller
{
    public class StopRoller : InstantCommand
    {
        public StopRoller()
        {
            Requires(ChopShop2016.intakeRoller);
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.intakeRoller.Stop();
        }
    }
}
