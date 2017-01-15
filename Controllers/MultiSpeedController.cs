using NetworkTables;
using NetworkTables.Tables;
using WPILib.Interfaces;
using WPILib.LiveWindow;

namespace ChopShop2016.Subsystems
{
    /*
     * Implements a SpeedController with an underlying PID controller
     */
    public sealed class MultiSpeedController : ISpeedController, ILiveWindowSendable, ITableListener
    {

        private bool _isInverted = false;
        private ISpeedController[] _controllers;
        private double _setpoint;
        private ITable m_table;

        public MultiSpeedController(ISpeedController[] controllers, string subsystem, string controllerName)
        {
            _controllers = controllers;
            LiveWindow.AddActuator(subsystem, controllerName, this);
        }

        public void Dispose()
        {
            Disable();
            foreach (ISpeedController sc in _controllers)
                sc.Dispose();
        }

        public void PidWrite(double output)
        {
            Set(output);
        }

        public double Get()
        {
            return _setpoint;
        }

        public void Set(double setpoint, byte syncGroup)
        {
            Set(setpoint);
        }

        public void Set(double setpoint)
        {
            _setpoint = (setpoint < -1.0 ? -1.0 : (setpoint > 1.0 ? 1.0 : setpoint));

            foreach (ISpeedController sc in _controllers)
            {
                sc.Set(_setpoint);
            }
        }

        public void Disable()
        {
            foreach (ISpeedController sc in _controllers)
            {
                sc.Disable();
            }
        }

        public bool Inverted
        {
            get { return _isInverted; }
            set
            {
                _isInverted = value;

                foreach (ISpeedController sc in _controllers)
                    sc.Inverted = value;
            }
        }

        public void StopMotor()
        {
            foreach (ISpeedController sc in _controllers)
            {
                sc.StopMotor();
            }
            _setpoint = 0;
        }

        /*
         * Live Window code, only does anything if live window is activated.
         */

        public string SmartDashboardType => "Speed Controller";

        public void ValueChanged(ITable itable, string key, Value value, NotifyFlags flgs)
        {
            Set(value.GetDouble());
        }

        public void InitTable(ITable subtable)
        {
            m_table = subtable;
            UpdateTable();
        }

        public void UpdateTable()
        {
            m_table?.PutNumber("Value", Get());
        }

        public ITable Table => m_table;

        public void StartLiveWindowMode()
        {
            StopMotor(); // Stop for safety
            m_table?.AddTableListener("Value", this, true);
        }

        public void StopLiveWindowMode()
        {
            StopMotor(); // Stop for safety
                         // TODO: Broken, should only remove the listener from "Value" only.
            m_table?.RemoveTableListener(this);
        }

    }
}