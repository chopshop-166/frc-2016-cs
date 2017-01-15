namespace ChopShop2016.Commands.Shooter
{
    public class SetShooterSpeed : InstantCommand
    {
        double speed;

        public SetShooterSpeed(double _speed)
        {
            Requires(ChopShop2016.shooter);
            speed = _speed;
        }

        // Called just before this Command runs the first time
        protected override void Initialize() { }

        // Called repeatedly when this Command is scheduled to run
        protected override void Execute()
        {
            ChopShop2016.shooter.SetSpeedOpenLoop(speed);
        }
    }
}
