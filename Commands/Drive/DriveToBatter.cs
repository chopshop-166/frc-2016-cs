﻿using WPILib;
using WPILib.Commands;

namespace ChopShop2016.Commands.Drive
{
    public class DriveToBatter : Command
    {
        public DriveToBatter()
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
            var speed = Preferences.Instance.GetDouble("DriveToBatterSpeed", .7);
            ChopShop2016.drive.driveWithGyro(speed, speed);
        }

        // Make this return true when this Command no longer needs to run Execute()
        protected override bool IsFinished()
        {
            return ChopShop2016.drive.FrontUltrasonicVoltage < Preferences.Instance.GetDouble("BatterDistanceConstant", .73);
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
