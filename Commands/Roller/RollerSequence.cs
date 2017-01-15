using WPILib.Commands;
using WPILib.SmartDashboard;

namespace ChopShop2016.Commands.Roller
{
    public class RollerSequence : Command
    {
        public RollerSequence()
        {
            Requires(ChopShop2016.intakeRoller);
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.intakeRoller.Start(0.25);
        }

        // Called repeatedly when this Command is scheduled to run
        protected override void Execute()
        {
            SmartDashboard.PutNumber("Intake IR Voltage", ChopShop2016.intakeRoller.IRVoltage);
        }

        // Make this return true when this Command no longer needs to run Execute()
        protected override bool IsFinished()
        {
            return ChopShop2016.intakeRoller.IsBallLoaded;
        }

        // Called once after isFinished returns true
        protected override void End() { ChopShop2016.intakeRoller.Stop(); }

        // Called when another command which requires one or more of the same
        // subsystems is scheduled to run
        protected override void Interrupted() { }
    }
}
