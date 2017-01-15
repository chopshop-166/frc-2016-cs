using WPILib.Commands;

namespace ChopShop2016.Commands
{
    public abstract class InstantCommand : Command
    {
        // Called repeatedly when this Command is scheduled to run
        protected override void Execute() { }

        // Make this return true when this Command no longer needs to run Execute()
        protected override bool IsFinished() { return true; }

        // Called once after isFinished returns true
        protected override void End() { }

        // Called when another command which requires one or more of the same
        // subsystems is scheduled to run
        protected override void Interrupted() { }
    }
}
