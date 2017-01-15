using ChopShop2016.Commands.AManipulators;
using ChopShop2016.Commands.Drive;
using ChopShop2016.Commands.Intake;
using WPILib.Commands;

namespace ChopShop2016.Commands.Autonomous
{
    public class UberAuto : CommandGroup
    {
        public UberAuto()
        {
            AddSequential(new LowerAManipulators());
            AddSequential(new LoadingProcess());
            AddSequential(new TurnAngle(-30.0));
            AddSequential(new DriveDistance(.9, 29)); // real distance is 37
            AddSequential(new TurnAngle(30.0));
            AddSequential(new LowerRake());
            AddSequential(new DriveDistance(.9, 126)); // real distance is 162
            AddSequential(new RaiseRake());
            AddSequential(new TurnAngle(45.0));
            AddSequential(new MediumRangeShot());
            AddSequential(new TurnAngle(-45.0 - ChopShop2016.drive.turnToGoalAngle));
            AddSequential(new LowerRake());
            AddSequential(new DriveDistance(-.9, -141)); // real distance is 141
            AddSequential(new AutoLoadingProcess());
            AddSequential(new DriveDistance(.9, 141));
            AddSequential(new RaiseRake());
            AddSequential(new TurnAngle(45.0));
            AddSequential(new MediumRangeShot());
        }
    }
}
