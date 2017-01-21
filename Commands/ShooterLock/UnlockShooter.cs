using WPILib.Commands;

namespace ChopShop2016.Commands.ShooterLock
{
    public class UnlockShooter : InstantCommand
    {
        public UnlockShooter()
        {
            Requires(ChopShop2016.shooterLock);
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.shooterLock.Unlock();
        }
    }
}
