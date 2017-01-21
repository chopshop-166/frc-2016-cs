using WPILib.Commands;

namespace ChopShop2016.Commands.Drive
{
    public class Neutral : InstantCommand
    {
        public Neutral()
        {
            Requires(ChopShop2016.drive);
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.drive.GearValue = Subsystems.Drive.Gear.Neutral;
        }
    }
}
