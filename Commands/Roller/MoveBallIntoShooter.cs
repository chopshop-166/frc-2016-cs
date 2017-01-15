using WPILib.Commands;

namespace ChopShop2016.Commands.Roller
{
    public class MoveBallIntoShooter : Command
    {
        public MoveBallIntoShooter()
        {
            Requires(ChopShop2016.intakeRoller);
            Requires(ChopShop2016.intake);
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.intakeRoller.Start(1.0);
            ChopShop2016.intake.MotorForward();
        }

        // Called repeatedly when this Command is scheduled to run
        protected override void Execute() { }

        // Make this return true when this Command no longer needs to run Execute()
        protected override bool IsFinished()
        {
            return ChopShop2016.intakeRoller.IsBallShot;
        }

        // Called once after isFinished returns true
        protected override void End()
        {
            ChopShop2016.intakeRoller.Stop();
            ChopShop2016.intake.MotorStop();
        }

        // Called when another command which requires one or more of the same
        // subsystems is scheduled to run
        protected override void Interrupted() { }
    }
}
