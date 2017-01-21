using WPILib.Commands;

namespace ChopShop2016.Commands.Roller
{
    public class ReverseRoller : InstantCommand
    {
        public ReverseRoller()
        {
            Requires(ChopShop2016.intakeRoller);
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.intakeRoller.Start(-1.0);
        }
    }
}
