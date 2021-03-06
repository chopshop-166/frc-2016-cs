﻿using WPILib.Commands;

namespace ChopShop2016.Commands.AManipulators
{
    public class ToggleAManipulators : InstantCommand
    {
        public ToggleAManipulators()
        {
            Requires(ChopShop2016.aManipulators);
        }

        // Called just before this Command runs the first time
        protected override void Initialize()
        {
            ChopShop2016.aManipulators.Toggle();
        }
    }
}
