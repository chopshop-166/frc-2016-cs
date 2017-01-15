using ChopShop2016.Commands;
using ChopShop2016.Commands.Autonomous;
using ChopShop2016.Subsystems;
using ChopShop2016.Triggers;
using WPILib;
using WPILib.Commands;
using WPILib.LiveWindow;
using WPILib.SmartDashboard;

namespace ChopShop2016
{
    public class ChopShop2016 : IterativeRobot
    {
        public static OI oi;

        #region Subsystems
        public static Drive drive;
        public static Intake intake;
        public static Shooter shooter;
        public static AimShooter aimShooter;
        public static Vision vision;
        public static IntakeRoller intakeRoller;
        public static AManipulators aManipulators;
        public static ShooterLock shooterLock;
        #endregion

        private static SendableChooser autoChooser;

        #region Triggers
        private POVUpTrigger povUpTrigger = new POVUpTrigger();
        private POVDownTrigger povDownTrigger = new POVDownTrigger();
        private RightXBoxTrigger rightXBoxTrigger = new RightXBoxTrigger();
        #endregion

        Command autonomousCommand;

        // This function is run when the robot is first started up and should be
        // used for any initialization code.
        //
        public override void RobotInit()
        {
            drive = new Drive();
            intake = new Intake();
            shooter = new Shooter();
            aimShooter = new AimShooter();
            vision = new Vision();
            intakeRoller = new IntakeRoller();
            aManipulators = new AManipulators();
            shooterLock = new ShooterLock();

            autoChooser = new SendableChooser();

            oi = new OI();

            // auto chooser commands
            autoChooser.AddObject("NOTHING", null);
            autoChooser.AddDefault("ONE: LOW", new FarLeftAuto());
            autoChooser.AddObject("MID: UP", new AllUpMidAuto());
            autoChooser.AddObject("MID: DOWN", new AllDownMidAuto());
            autoChooser.AddObject("MID: CDF", new MidCDFAuto());
            autoChooser.AddObject("TWO: (Untested)", new PositionTwoAuto());
            autoChooser.AddObject("FIVE: (Untested)", new PositionFiveAuto());

            SmartDashboard.PutData("Autonomous", autoChooser);

            povUpTrigger.WhenActive(new MoveActuatorsUp());
            povDownTrigger.WhenActive(new MoveActuatorsDown());
            rightXBoxTrigger.WhenActive(new MediumRangeShot());
        }

        public override void DisabledPeriodic()
        {
            Scheduler.Instance.Run();
        }
        
        public override void AutonomousInit()
        {
            autonomousCommand = (Command)autoChooser.GetSelected();

            // schedule the autonomous command (example)
            autonomousCommand?.Start();
        }


        // This function is called periodically during autonomous
        public override void AutonomousPeriodic()
        {
            Scheduler.Instance.Run();
        }

        public override void TeleopInit()
        {
            // This makes sure that the autonomous stops running when
            // teleop starts running. If you want the autonomous to 
            // continue until interrupted by another command, remove
            // this line or comment it out.
            autonomousCommand?.Cancel();
        }

        //
        // This function is called when the disabled button is hit.
        // You can use it to reset subsystems before shutting down.
        //
        public override void DisabledInit()
        {
            autonomousCommand?.Cancel();
        }

        //
        // This function is called periodically during operator control
        //
        public override void TeleopPeriodic()
        {
            Scheduler.Instance.Run();
        }

        //
        // This function is called periodically during test mode
        //
        public override void TestPeriodic()
        {
            LiveWindow.Run();
        }
    }
}
