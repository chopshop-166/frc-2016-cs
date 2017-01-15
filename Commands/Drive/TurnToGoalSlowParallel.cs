using System;
using WPILib.Commands;

namespace ChopShop2016.Commands.Drive
{
    public class TurnToGoalSlowParallel : Command
    {
        protected double endOffset;

        public TurnToGoalSlowParallel(double end)
        {
            Requires(ChopShop2016.drive);
            Requires(ChopShop2016.vision);
            endOffset = end;
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.drive.ResetGyro();
        }

        // Called repeatedly when this Command is scheduled to run
        protected override void Execute()
        {
            if (Math.Abs(ChopShop2016.vision.XOffset) > .02)
            {
                ChopShop2016.drive.turnToGoalParallel(ChopShop2016.vision.XOffset);
            }
            else
            {
                ChopShop2016.drive.Stop();
            }
        }

        // Make this return true when this Command no longer needs to run Execute()
        protected override bool IsFinished() { return false; }

        // Called once after isFinished returns true
        protected override void End()
        {
            ChopShop2016.drive.turnToGoalAngle = ChopShop2016.drive.GetGyro();
        }

        // Called when another command which requires one or more of the same
        // subsystems is scheduled to run
        protected override void Interrupted() { }
    }
}
