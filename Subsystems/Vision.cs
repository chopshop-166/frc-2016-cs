using NetworkTables;
using System;
using WPILib.Commands;
using WPILib.SmartDashboard;

namespace ChopShop2016.Subsystems
{
    [WPILib.Extras.AttributedCommandModel.ExportSubsystem]
    public sealed class Vision : Subsystem
    {
        const double screenCenter = 143;
        const double xOffsetMultiplier = 1.0 / 160.0;
        const double defaultShooterAngle = 45.0;
        const double cameraLag = .14; // seconds
        double xOffset = 0;
        double xPos = 0;
        NetworkTable visionTable;

        public Vision()
        {
            visionTable = NetworkTable.GetTable("VisionDataTable");
        }

        public double DesiredShooterAngle
        {
            get
            {
                // returns the desired shooter angle as calculated in the python code
                double angle = visionTable.GetNumber("shooterAngle", defaultShooterAngle);
                if (angle < 45)
                {
                    SmartDashboard.PutString("Shot Distance", "Too Far");
                }
                else
                {
                    SmartDashboard.PutString("Shot Distance", "Good");
                }

                return Math.Max(angle, 41);
            }
        }

        public double correctForLag(double offset)
        {

            var lagAngle = cameraLag * ChopShop2016.drive.GyroRate;
            SmartDashboard.PutNumber("Correction Angle", lagAngle);

            var offsetAngle = offset * (45.0 / 160.0);
            var realAngle = offsetAngle - lagAngle;
            return realAngle * (320.0 / 45.0) * xOffsetMultiplier;
        }

        public double XOffset
        {
            get
            {
                if (IsValidTarget)
                {
                    xPos = visionTable.GetNumber("xPosition", screenCenter);
                    xOffset = (xPos - screenCenter) * xOffsetMultiplier;
                    return correctForLag(xOffset);
                }
                else
                {
                    return (1.0);
                }
            }
        }

        public bool IsValidTarget => visionTable.GetBoolean("isValidTarget", false);
        public double XPos => visionTable.GetNumber("xPosition", screenCenter);
        public double DistanceToTarget => visionTable.GetNumber("distanceToTarget", 0);

        protected override void InitDefaultCommand() { }
    }
}
