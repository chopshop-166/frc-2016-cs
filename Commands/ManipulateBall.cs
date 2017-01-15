using WPILib.Commands;

namespace ChopShop2016.Commands
{
    public class ManipulateBall : CommandGroup
    {
        public ManipulateBall()
        {
            if (ChopShop2016.intakeRoller.IsBallLoaded)
            {
                AddSequential(new EjectBall());
            }
            else
            {
                AddSequential(new LoadingProcess());
            }
        }
    }
}
