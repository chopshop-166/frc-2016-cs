using ChopShop2016.Commands.Intake;
using ChopShop2016.Commands.Roller;
using WPILib.Commands;

namespace ChopShop2016.Commands
{
    public class EjectBall : CommandGroup
    {
        public EjectBall()
        {
            AddSequential(new RaiseRake());
            AddParallel(new ReverseRoller());
            AddSequential(new IntakeReverse());
            AddSequential(new WaitCommand(1.0)); // maybe change this
            AddSequential(new StopRoller());
            AddSequential(new IntakeStop());
        }
    }
}
