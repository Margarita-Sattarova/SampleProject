﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;
using PitchApplication;

namespace PitchUndergroundApplication {
    public class PitchUndergroundCommandsAvailability : PitchCommonCommandsAvailability<IPitchUnderground> {
        public PitchUndergroundCommandsAvailability(IPitchUnderground pitch) : base(pitch) { }
        public override void InitializeCommandsAvailability() {
            base.InitializeCommandsAvailability();
            Pitch.FindWayCommand.SetUnavailable(!Pitch.CanCrawl);
            Pitch.SwitchToDarkCommand.SetUnavailable(!Pitch.CanCrawl);
            Pitch.SwitchToLightCommand.SetUnavailable(!Pitch.CanCrawl);
        }
    }
}
