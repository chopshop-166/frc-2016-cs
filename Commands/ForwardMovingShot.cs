using ChopShop2016.Commands.Aim;
using ChopShop2016.Commands.Drive;
using ChopShop2016.Commands.Roller;
using ChopShop2016.Commands.Shooter;
using ChopShop2016.Commands.ShooterLock;
using WPILib.Commands;

namespace ChopShop2016.Commands
{
    public class ForwardMovingShot : CommandGroup
    {
        public ForwardMovingShot()
        {
            AddSequential(new UnlockShooter()); // Release shooter piston
            AddSequential(new SetShooterSpeed(.9)); // Set shooter wheel PIDs
            AddParallel(new AimParallel());
            AddSequential(new TurnToGoalWhileDrivingForward()); // see TurnToGoalWhileDrivingBackward()
            AddSequential(new WaitCommand(.5));
            AddSequential(new Aim.Aim()); // Ajusts shooter angle based on distance algorithm

            // AddSequential(new WaitCommand(.5)); // Waits for shooter to settle
            AddSequential(new MoveBallIntoShooter()); // Drive feeder roller untill ball leaves
            AddSequential(new WaitCommand(.25)); // Guarantee ball has left
            AddSequential(new SetShooterSpeed(0.0)); // Spin down shooter
            AddSequential(new CancelShot()); // Free up shooting subsystems
            AddSequential(new DriveWithJoysticks()); // Return control to the driver
        }
    }
}
