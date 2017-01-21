using WPILib.Commands;

namespace ChopShop2016.Commands
{
    public class CancelShot : InstantCommand
    {
        public CancelShot()
        {
            Requires(ChopShop2016.aimShooter);
            Requires(ChopShop2016.intakeRoller);
            Requires(ChopShop2016.shooter);
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.aimShooter.Stop();
            ChopShop2016.intakeRoller.Stop();
            ChopShop2016.shooter.SetSpeedOpenLoop(0.0);
            ChopShop2016.intake.MotorStop();
        }
    }
}
