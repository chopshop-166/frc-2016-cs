using ChopShop2016.Commands.Drive;
using ChopShop2016.Commands.Intake;
using ChopShop2016.Commands.Shooter;
using WPILib.Commands;

namespace ChopShop2016.Commands.Autonomous
{
    public class FarLeftAuto : CommandGroup
    {
        public FarLeftAuto()
        {
            AddSequential(new SetShooterSpeed(.9));
            AddSequential(new MoveActuatorsDown(), 2);
            AddSequential(new DriveDistance(.9, 70));
            AddSequential(new RaiseRake());
            AddSequential(new DriveDistance(.9, 100));
            // AddSequential(new WaitCommand(1));
            AddSequential(new TurnAngle(45));
            // AddSequential(new DriveDistance(.7, 112));
            AddSequential(new DriveDistance(.7, 36));
            AddSequential(new MediumRangeShot());
            // AddSequential(new ToggleDriveDirection());
        }
    }
}
