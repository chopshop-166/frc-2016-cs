using WPILib;
using WPILib.Interfaces;
using WPILib.LiveWindow;

namespace ChopShop2016.Subsystems
{
    /*
     * Implements a SpeedController with an underlying PID controller
     */
    public class PIDSpeedController : PIDController, ISpeedController
    {
        public PIDSpeedController(IPIDSource source, IPIDOutput output, string subsystem, string controllerName)
            : base(0, 0, 0, 0, source, output)
        {
            LiveWindow.AddActuator(subsystem, controllerName, this);
        }

        public void Set(double setpoint, byte syncGroup)
        {
            Set(setpoint);
        }

        public void Set(double setpoint)
        {
            Setpoint = setpoint;
            Enable();
        }

        public bool Inverted
        {
            get { return false; }
            set { }
        }

        public void StopMotor()
        {
            Disable();
        }

        public void PidWrite(double value) { }
    }
}