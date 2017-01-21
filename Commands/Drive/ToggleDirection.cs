using WPILib.Commands;

namespace ChopShop2016.Commands.Drive
{
    public class ToggleDirection : InstantCommand
    {
        public ToggleDirection()
        {
            Requires(ChopShop2016.drive);
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.drive.isReversed = !ChopShop2016.drive.isReversed;
        }
    }
}
