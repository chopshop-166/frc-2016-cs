using WPILib.Commands;
using WPILib.SmartDashboard;

namespace ChopShop2016.Commands.Drive
{
    public class DriveWithJoysticks : Command
    {
        public DriveWithJoysticks()
        {
            Requires(ChopShop2016.drive);
        }

        // Called just before this Command runs the first time
        protected override void Initialize() { }

        // Called repeatedly when this Command is scheduled to run
        protected override void Execute()
        {
            ChopShop2016.drive.driveWithJoysticks(ChopShop2016.oi.LeftYAxis, ChopShop2016.oi.RightYAxis);

            SmartDashboard.PutNumber("POT Angle", ChopShop2016.aimShooter.ShooterAngle);
            SmartDashboard.PutNumber("Pot Voltage", ChopShop2016.aimShooter.PotVoltage);
            SmartDashboard.PutNumber("X Offset", ChopShop2016.vision.XOffset);
            SmartDashboard.PutNumber("X Position", ChopShop2016.vision.XPos);
            ChopShop2016.drive.PrintGyroRate();
            SmartDashboard.PutNumber("Front Ultrasonic Distance", ChopShop2016.drive.FrontUltrasonicVoltage);
            SmartDashboard.PutNumber("Distance Traveled", ChopShop2016.drive.EncoderDistance);
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
