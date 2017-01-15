namespace ChopShop2016.Commands.AManipulators
{
    public class LowerAManipulators : InstantCommand
    {
        public LowerAManipulators()
        {
            Requires(ChopShop2016.aManipulators);
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.aManipulators.Lower();
        }
    }
}
