using WPILib.Commands;

namespace ChopShop2016.Commands.Autonomous
{
    public class PaperWeightAuto : CommandGroup
    {
        public PaperWeightAuto()
        {
            AddSequential(new WaitCommand(15));
        }
    }
}
