using ChopShop2016.Commands.Drive;
using ChopShop2016.Commands.Shooter;
using ChopShop2016.Commands.ShooterLock;
using WPILib.Commands;

namespace ChopShop2016.Commands.Autonomous
{
    public class AllDownMidAuto : CommandGroup
    {
        public AllDownMidAuto()
        {
            AddSequential(new SetShooterSpeed(.9));
            AddSequential(new MoveActuatorsDown());
            AddSequential(new DriveDistance(.9, 162));
            AddSequential(new MoveActuatorsUp());
            AddSequential(new UnlockShooter());
            AddSequential(new MediumRangeShot());
        }
    }
}
