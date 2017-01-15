namespace ChopShop2016
{
    /**
     * The RobotMap is a mapping from the ports sensors and actuators are wired into
     * to a variable name. This provides flexibility changing wiring, makes checking
     * the wiring easier and significantly reduces the number of magic numbers
     * floating around.
     */
    public class RobotMap
    {

        // Driver Controls
        public static class Driver
        {
            public static int leftJoystickPort = 0;
            public static int rightJoystickPort = 1;
            public static int Joystick = 1;
        }

        // Copilot Controls
        public static class Copilot
        {
            public static int copilotPort = 2;
            public static int Joystick = 2;
        }

        // PWM Channels
        public static class Pwm
        {

            // public static int rollerPort = 6; unused?

            public static int LeftShooterMotor = 4;
            public static int RightShooterMotor = 3;
            public static int ShooterAngleMotor = 2;

            public static int leftTransmissionServoPort = 7;
            public static int rightTransmissionServoPort = 8;

            public static int MainIntakeVictor = 1;
            public static int CrossIntakeVictor = 5;
            public static int RollerVictor = 0;
        }

        public static class CAN
        {
            public static int leftTopDrive = 3;
            public static int leftBotDrive = 4;
            public static int rightTopDrive = 1;
            public static int rightBotDrive = 2;
        }

        // Encoder (Digital Input) Channels
        public static class Digital
        {

            public static int leftEncoderA = 2; // front left
            public static int leftEncoderB = 3;
            public static int rightEncoderA = 0; // front right
            public static int rightEncoderB = 1;

            public static int ShooterLeftChannelA = 8;
            public static int ShooterLeftChannelB = 9;

            public static int ShooterRightChannelA = 4;
            public static int ShooterRightChannelB = 5;

        }

        // Analog Inputs
        public static class Analog
        {
            public static int gyroPort = 0;
            public static int IntakeSensor = 1;
            public static int ShooterPotAngle = 2;
            public static int frontUltrasonic = 3;
        }

        // Solenoids
        public static class Solenoid
        {
            public static int IntakeSolenoidForwards = 0;
            public static int IntakeSolenoidBackwards = 1;
            public static int AManipulatorForward = 2;
            public static int AManipulatorReverse = 3;
            public static int ShooterLockForward = 4;
            public static int ShooterLockReverse = 5;
        }

        // Prefs
        public static class Prefs
        {
            public static string ShooterP = "ShooterP";
            public static string ShooterI = "ShooterI";
            public static string ShooterD = "ShooterD";
            public static string ShooterF = "ShooterF";

            public static string ShooterAngleP = "ShooterAngleP";
            public static string ShooterAngleI = "ShooterAngleI";
            public static string ShooterAngleD = "ShooterAngleD";
            public static string ShooterAngleF = "ShooterAngleF";

            public static string ShooterSpeed = "ShooterSpeed";

            public static string angleToDisplacementConstant = "angleToDisplacementConstant";

            public static string IntakeRollerRotations = "IntakeRollerRotations";
            public static string IntakeRollerMotorSpeed = "IntakeRollerMotorSpeed";
            public static string IntakeSensorThreshold = "IntakeSensorThreshold";
        }

    }
}
