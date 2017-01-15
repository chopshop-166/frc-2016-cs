using ChopShop2016.Commands.AManipulators;
using ChopShop2016.Commands.Drive;
using ChopShop2016.Commands.Shooter;
using ChopShop2016.Commands.ShooterLock;
using WPILib.Commands;

namespace ChopShop2016.Commands.Autonomous
{
    public class MidCDFAuto : CommandGroup
    {
        public MidCDFAuto()
        {
            AddSequential(new SetShooterSpeed(.9));
            AddSequential(new MoveActuatorsUp());
            AddSequential(new DriveDistance(.5, 42));
            AddSequential(new LowerAManipulators(), 2);
            AddSequential(new WaitCommand(.5));
            AddSequential(new DriveDistance(-.4, -6));
            AddSequential(new DriveDistance(.7, 102));
            AddSequential(new UnlockShooter());
            AddSequential(new MediumRangeShot());
        }
    }
}
