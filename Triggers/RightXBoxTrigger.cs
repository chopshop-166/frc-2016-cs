using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Buttons;

namespace ChopShop2016.Triggers
{
    public class RightXBoxTrigger : Trigger
    {
        public override bool Get()
        {
            return Math.Abs(ChopShop2016.oi.CopilotRightTrigger) > .75;
        }
    }
}
