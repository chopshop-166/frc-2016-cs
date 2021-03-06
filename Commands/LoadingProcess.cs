﻿using ChopShop2016.Commands.Aim;
using ChopShop2016.Commands.Intake;
using ChopShop2016.Commands.Roller;
using ChopShop2016.Commands.Shooter;
using ChopShop2016.Commands.ShooterLock;
using WPILib.Commands;

namespace ChopShop2016.Commands
{
    public class LoadingProcess : CommandGroup
    {
        public LoadingProcess()
        {
            AddSequential(new UnlockShooter());
            AddParallel(new AimToAngle(45));
            AddSequential(new LowerRake());
            AddSequential(new IntakeForward());
            AddSequential(new RollerSequence());
            AddSequential(new IntakeStop());
            AddSequential(new RaiseRake());
            AddSequential(new SetShooterSpeed(.9));
        }
    }
}
