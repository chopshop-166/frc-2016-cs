using System;
using WPILib.Commands;

namespace ChopShop2016.Commands.Drive
{
    public class TurnToGoalWithGyro : Command
    {
        const double shotZone = .045;
        const double fastSpinSpeed = .17;

        double xOffset = 0.0;

        protected double spinSpeed = .26;

        public TurnToGoalWithGyro()
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
            xOffset = ChopShop2016.vision.XOffset;
            double speed = spinSpeed;

            if (!ChopShop2016.drive.IsRobotSpinning)
            {
                speed = fastSpinSpeed;
            }

            if (xOffset > shotZone)
            {
                ChopShop2016.drive.spinRight(speed);
            }
            else if (xOffset < -shotZone)
            {
                ChopShop2016.drive.spinLeft(speed);
            }
            else
            {
                ChopShop2016.drive.Brake();
            }
        }

        // Make this return true when this Command no longer needs to run Execute()
        protected override bool IsFinished()
        {
            return (!ChopShop2016.drive.IsRobotSpinning) && (Math.Abs(xOffset) < shotZone);
        }

        // Called once after isFinished returns true
        protected override void End() { }

        // Called when another command which requires one or more of the same
        // subsystems is scheduled to run
        protected override void Interrupted() { }
    }
}
