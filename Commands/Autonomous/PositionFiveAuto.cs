using ChopShop2016.Commands.Drive;
using ChopShop2016.Commands.Intake;
using ChopShop2016.Commands.Shooter;
using WPILib.Commands;

namespace ChopShop2016.Commands.Autonomous
{
    public class PositionFiveAuto : CommandGroup
    {
        public PositionFiveAuto()
        {
            AddSequential(new SetShooterSpeed(.9));
            AddSequential(new MoveActuatorsDown(), 2);
            AddSequential(new DriveDistance(.9, 70));
            AddSequential(new RaiseRake());
            AddSequential(new DriveDistance(.9, 20));
            AddSequential(new TurnAngle(-20));
            AddSequential(new MediumRangeShot());
        }
    }
}
