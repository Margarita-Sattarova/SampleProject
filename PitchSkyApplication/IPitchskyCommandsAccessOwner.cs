using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PitchApplication;

namespace PitchSkyApplication {
    interface IPitchSkyCommandsAccessOwner : IPitchCommonCommandsAccessOwner, IPitchSky {
        bool CanFly { get; }
        bool CanLand { get; }
    }
}
