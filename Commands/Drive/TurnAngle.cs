using System;
using WPILib.Commands;

namespace ChopShop2016.Commands.Drive
{
    public class TurnAngle : Command
    {
        double desiredAngle;

        public TurnAngle(double angle)
        {
            Requires(ChopShop2016.drive);

            desiredAngle = -angle;
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.drive.ResetGyro();
        }

        // Called repeatedly when this Command is scheduled to run
        protected override void Execute()
        {
            if (desiredAngle > 0)
            {
                ChopShop2016.drive.spinLeft(.3);
            }
            else
            {
                ChopShop2016.drive.spinRight(.3);
            }
        }

        // Make this return true when this Command no longer needs to run Execute()
        protected override bool IsFinished()
        {
            return Math.Abs(desiredAngle + ChopShop2016.drive.GetGyro()) < 5;
        }

        // Called once after isFinished returns true
        protected override void End()
        {
            ChopShop2016.drive.Stop();
        }

        // Called when another command which requires one or more of the same
        // subsystems is scheduled to run
        protected override void Interrupted()
        {
        }
    }
}
