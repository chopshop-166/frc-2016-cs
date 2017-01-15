using ChopShop2016.Commands.Drive;
using ChopShop2016.Commands.Intake;
using ChopShop2016.Commands.Shooter;
using WPILib.Commands;

namespace ChopShop2016.Commands.Autonomous
{
    public class PositionTwoAuto : CommandGroup
    {
        public PositionTwoAuto()
        {
            AddSequential(new SetShooterSpeed(.9));
            AddSequential(new MoveActuatorsDown(), 2);
            AddSequential(new DriveDistance(.9, 70));
            AddSequential(new RaiseRake());
            AddSequential(new DriveDistance(.9, 50));
            // AddSequential(new WaitCommand(1));
            AddSequential(new TurnAngle(30));
            // AddSequential(new DriveDistance(.7, 112));
            AddSequential(new DriveDistance(.7, 10));
            AddSequential(new MediumRangeShot());
            // AddSequential(new ToggleDriveDirection());
        }
    }
}
