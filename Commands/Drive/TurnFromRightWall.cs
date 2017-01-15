using WPILib.Commands;

namespace ChopShop2016.Commands.Drive
{
    public class TurnFromRightWall : Command
    {
        public TurnFromRightWall()
        {
            Requires(ChopShop2016.drive);
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.drive.ResetEncoders();
        }

        // Called repeatedly when this Command is scheduled to run
        protected override void Execute()
        {
            ChopShop2016.drive.DriveRightMotorsForward();
        }

        // Make this return true when this Command no longer needs to run Execute()
        protected override bool IsFinished() => false;

        // Called once after isFinished returns true
        protected override void End()
        {
            ChopShop2016.drive.Stop();
        }

        // Called when another command which requires one or more of the same
        // subsystems is scheduled to run
        protected override void Interrupted() { }
    }
}
