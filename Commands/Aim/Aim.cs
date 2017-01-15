using System;
using WPILib.Commands;
using WPILib.SmartDashboard;

namespace ChopShop2016.Commands.Aim
{
    public class Aim : Command
    {
        public Aim()
        {
            Requires(ChopShop2016.aimShooter);
            Requires(ChopShop2016.vision);
        }

        // Called just before this Command runs the first time
        protected override void Initialize() { }

        // Called repeatedly when this Command is scheduled to run
        protected override void Execute()
        {
            SmartDashboard.PutNumber("Desired Angle", ChopShop2016.vision.DesiredShooterAngle);
            SmartDashboard.PutNumber("POT Angle", ChopShop2016.aimShooter.ShooterAngle);
            ChopShop2016.aimShooter.MoveToAngle(ChopShop2016.vision.DesiredShooterAngle);
        }

        // Make this return true when this Command no longer needs to run Execute()
        protected override bool IsFinished()
        {
            return Math.Abs(ChopShop2016.vision.DesiredShooterAngle - ChopShop2016.aimShooter.ShooterAngle) < .25;
        }

        // Called once after isFinished returns true
        protected override void End() { ChopShop2016.aimShooter.Stop(); }

        // Called when another command which requires one or more of the same
        // subsystems is scheduled to run
        protected override void Interrupted() { }
    }
}
