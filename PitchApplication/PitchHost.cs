using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchApplication {
    public class PitchHost : CommonPitchHost, IPitchHost {
        public bool CanRun { get; set; } = true;
        public bool CanJump { get; set; } = true;
    }
}
