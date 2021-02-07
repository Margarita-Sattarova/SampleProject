using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PitchApplication;

namespace PitchUndergroundApplication {
    interface IPitchUndergroundCommandsAccessOwner : IPitchCommonCommandsAccessOwner, IPitchUnderground {
        bool CanCrawl { get; }
    }
}
