using WPILib;
using WPILib.Commands;

namespace ChopShop2016.Commands.Drive
{
    public class DriveWithGyro : Command
    {
        public DriveWithGyro()
        {
            Requires(ChopShop2016.drive);
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.drive.ResetGyro();
        }

        // Called repeatedly when this Command is scheduled to run
        protected override void Execute()
        {
            ChopShop2016.drive.GetRightEncoder();
            Joystick leftStick = new Joystick(RobotMap.Driver.leftJoystickPort);
            Joystick rightStick = new Joystick(RobotMap.Driver.rightJoystickPort);
            ChopShop2016.drive.driveWithGyro(leftStick.GetY(), rightStick.GetY());
        }

        // Make this return true when this Command no longer needs to run Execute()
        protected override bool IsFinished() => false;

        // Called once after isFinished returns true
        protected override void End() { }

        // Called when another command which requires one or more of the same
        // subsystems is scheduled to run
        protected override void Interrupted() { }
    }
}
