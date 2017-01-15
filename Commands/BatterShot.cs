using ChopShop2016.Commands.Aim;
using ChopShop2016.Commands.Drive;
using ChopShop2016.Commands.Intake;
using ChopShop2016.Commands.Roller;
using ChopShop2016.Commands.Shooter;
using ChopShop2016.Commands.ShooterLock;
using WPILib;
using WPILib.Commands;

namespace ChopShop2016.Commands
{
    public class BatterShot : CommandGroup
    {
        public BatterShot()
        {
            AddSequential(new DriveDistance(-.4, 26));
            AddSequential(new UnlockShooter());
            AddSequential(new LowerRake());
            AddSequential(new SetShooterSpeed(Preferences.Instance.GetDouble("ShooterSpeed", 0.0)));
            AddSequential(new AimToAngle(61));
            AddSequential(new WaitCommand(1.0));
            AddSequential(new MoveBallIntoShooter());
            AddSequential(new WaitCommand(1.0));
            AddSequential(new SetShooterSpeed(0.0));
            AddSequential(new RaiseRake());
        }
    }
}
