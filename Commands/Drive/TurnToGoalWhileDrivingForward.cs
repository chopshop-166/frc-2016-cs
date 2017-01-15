using System;
using WPILib.Commands;

namespace ChopShop2016.Commands.Drive
{
    public class TurnToGoalWhileDrivingForward : Command
    {
        public const double shotZone = .05;

        public TurnToGoalWhileDrivingForward()
        {
            Requires(ChopShop2016.drive);
            Requires(ChopShop2016.vision);
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.drive.ResetGyro();
        }

        // Called repeatedly when this Command is scheduled to run
        protected override void Execute()
        {
            ChopShop2016.drive.turnToGoalWhileDriving(ChopShop2016.vision.XOffset);
        }

        // Make this return true when this Command no longer needs to run Execute()
        protected override bool IsFinished()
        {
            return (!ChopShop2016.drive.IsRobotSpinning) && (Math.Abs(ChopShop2016.vision.XOffset) < shotZone);
        }

        // Called once after isFinished returns true
        protected override void End() { }

        // Called when another command which requires one or more of the same
        // subsystems is scheduled to run
        protected override void Interrupted() { }
    }
}
