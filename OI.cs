using ChopShop2016.Commands;
using ChopShop2016.Commands.AManipulators;
using ChopShop2016.Commands.Drive;
using ChopShop2016.Commands.Intake;
using ChopShop2016.Commands.Shooter;
using WPILib;
using WPILib.Buttons;

namespace ChopShop2016
{
    /**
     * This class is the glue that binds the controls on the physical operator
     * interface to the commands and command groups that allow control of the robot.
     */
    public class OI
    {
        private Joystick leftStick;
        private Joystick rightStick;
        private Joystick copilotController;

        public OI()
        {
            leftStick = new Joystick(RobotMap.Driver.leftJoystickPort);
            rightStick = new Joystick(RobotMap.Driver.rightJoystickPort);
            copilotController = new Joystick(RobotMap.Copilot.copilotPort);

            JoystickButton rightJoyTrigger = new JoystickButton(rightStick, 1);
            JoystickButton leftJoyTrigger = new JoystickButton(leftStick, 1);
            JoystickButton rightJoyButton2 = new JoystickButton(rightStick, 2);
            JoystickButton leftJoyButton3 = new JoystickButton(leftStick, 3);
            JoystickButton rightJoyButton4 = new JoystickButton(rightStick, 4);
            JoystickButton rightJoyButton5 = new JoystickButton(rightStick, 5);
            JoystickButton rightJoyButton3 = new JoystickButton(rightStick, 3);

            JoystickButton CPbutton1 = new JoystickButton(copilotController, 1);
            JoystickButton CPbutton2 = new JoystickButton(copilotController, 2);
            JoystickButton CPbutton3 = new JoystickButton(copilotController, 3);
            JoystickButton CPbutton4 = new JoystickButton(copilotController, 4);
            JoystickButton CPbutton5 = new JoystickButton(copilotController, 5);
            JoystickButton CPbutton6 = new JoystickButton(copilotController, 6);
            JoystickButton CPbutton7 = new JoystickButton(copilotController, 7);

            // Buttons
            leftJoyTrigger.WhileHeld(new DriveWithGyro());
            leftJoyButton3.WhenPressed(new TurnToGoalFast());
            rightJoyTrigger.WhenPressed(new ToggleDirection());

            rightJoyButton3.WhenPressed(new TurnToGoalWithGyro());
            rightJoyButton2.WhenPressed(new EjectBall());
            rightJoyButton4.WhileHeld(new TurnFromRightWall());
            rightJoyButton5.WhileHeld(new TurnFromLeftWall());

            // The Following commands are mapped from buttons on a joystick and may
            // need to be changed if the copilot's controller turns out to be an
            // Xbox controller
            CPbutton1.WhenPressed(new MediumRangeShot());
            CPbutton2.WhenPressed(new BatterShot());
            CPbutton3.WhenPressed(new CancelShot());
            CPbutton4.WhenPressed(new LoadingProcess());
            CPbutton5.WhenPressed(new ToggleSolenoid());
            CPbutton6.WhenPressed(new ToggleAManipulators());
            CPbutton7.WhenPressed(new SetShooterSpeed(1.0));

        }

        public double LeftYAxis => leftStick.GetRawAxis(1);
        public double RightYAxis => rightStick.GetRawAxis(1);
        public double CopilotRightTrigger => copilotController.GetRawAxis(3);
        public double CopilotLeftTrigger => copilotController.GetRawAxis(2);
        public double CopilotLeftJoyUpDownAxis => -copilotController.GetRawAxis(1);
    }
}
