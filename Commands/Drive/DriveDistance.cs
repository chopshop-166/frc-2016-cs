using System;
using WPILib.Commands;
using WPILib.SmartDashboard;

namespace ChopShop2016.Commands.Drive
{
    public class DriveDistance : Command
    {
        double mySpeed;
        double myDistance;

        public DriveDistance(double speed, double distance)
        {
            Requires(ChopShop2016.drive);

            mySpeed = -speed; // negative because speed is reversed for these motors
            myDistance = distance;
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.drive.ResetEncoders();
            ChopShop2016.drive.ResetGyro();
        }

        // Called repeatedly when this Command is scheduled to run
        protected override void Execute()
        {
            SmartDashboard.PutNumber("Encoder Distance", ChopShop2016.drive.EncoderDistance);
            ChopShop2016.drive.driveWithGyro(mySpeed, mySpeed);
        }

        // Make this return true when this Command no longer needs to run Execute()
        protected override bool IsFinished()
        {
            return Math.Abs(ChopShop2016.drive.EncoderDistance) >= Math.Abs(myDistance);
        }

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
