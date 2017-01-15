using WPILib.Commands;

namespace ChopShop2016.Commands.Aim
{
    public class AimToMinimumAngle : Command
    {
        double angle;

        public AimToMinimumAngle(double _angle)
        {
            Requires(ChopShop2016.aimShooter);
            angle = _angle;
        }

        // Called just before this Command runs the first time
        protected override void Initialize() { }

        // Called repeatedly when this Command is scheduled to run
        protected override void Execute()
        {
            ChopShop2016.aimShooter.MoveToAngle(angle);
        }

        // Make this return true when this Command no longer needs to run Execute()
        protected override bool IsFinished()
        {
            return angle <= ChopShop2016.aimShooter.ShooterAngle;
        }

        // Called once after isFinished returns true
        protected override void End() { ChopShop2016.aimShooter.Stop(); }

        // Called when another command which requires one or more of the same
        // subsystems is scheduled to run
        protected override void Interrupted() { }
    }
}
