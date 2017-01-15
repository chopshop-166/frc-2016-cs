using ChopShop2016.Commands.Aim;
using ChopShop2016.Commands.AManipulators;
using ChopShop2016.Commands.Intake;
using ChopShop2016.Commands.ShooterLock;
using WPILib.Commands;

namespace ChopShop2016.Commands
{
    public class MoveActuatorsDown : CommandGroup
    {
        public MoveActuatorsDown()
        {
            AddSequential(new UnlockShooter());
            AddSequential(new LowerAManipulators());
            AddSequential(new LowerRake());
            AddSequential(new AimToAngle(43));
        }
    }
}
