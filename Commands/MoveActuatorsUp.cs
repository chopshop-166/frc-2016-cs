using ChopShop2016.Commands.Aim;
using ChopShop2016.Commands.AManipulators;
using ChopShop2016.Commands.Intake;
using ChopShop2016.Commands.ShooterLock;
using WPILib.Commands;

namespace ChopShop2016.Commands
{
    public class MoveActuatorsUp : CommandGroup
    {
        public MoveActuatorsUp()
        {
            AddSequential(new RaiseAManipulators());
            AddSequential(new RaiseRake());
            AddSequential(new AimToMinimumAngle(55));
            AddSequential(new LockShooter());
        }
    }
}
