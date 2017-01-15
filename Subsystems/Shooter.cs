using System;
using WPILib;
using WPILib.Commands;
using WPILib.Interfaces;

namespace ChopShop2016.Subsystems
{
    [WPILib.Extras.AttributedCommandModel.ExportSubsystem]
    public sealed class Shooter : Subsystem, IDisposable
    {
        Talon shooterLeftSide = new Talon(RobotMap.Pwm.LeftShooterMotor);
        Talon shooterRightSide = new Talon(RobotMap.Pwm.RightShooterMotor);
        Encoder encoderLeft = new Encoder(RobotMap.Digital.ShooterLeftChannelA, RobotMap.Digital.ShooterLeftChannelB);
        Encoder encoderRight = new Encoder(RobotMap.Digital.ShooterRightChannelA, RobotMap.Digital.ShooterRightChannelB);

        const double distancePerPulse = 1.0 / 2500.0 / 37.0;

        public Shooter()
        {
            encoderLeft.PIDSourceType = PIDSourceType.Rate;
            encoderRight.PIDSourceType = PIDSourceType.Rate;
            encoderLeft.DistancePerPulse = distancePerPulse;
            encoderRight.DistancePerPulse = distancePerPulse;
        }

        public void SetSpeedOpenLoop(double power)
        {
            shooterLeftSide.Set(power);
            shooterRightSide.Set(-power);
        }

        protected override void InitDefaultCommand() { }

        public void Dispose()
        {
            shooterLeftSide.Dispose();
            shooterRightSide.Dispose();
            encoderLeft.Dispose();
            encoderRight.Dispose();
        }
    }
}
