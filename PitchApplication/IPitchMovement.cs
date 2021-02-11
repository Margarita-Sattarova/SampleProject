using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchApplication {
    public interface IPitchMovement : ICommonMovement{
        bool CanRun { get; set; }
        bool CanJump { get; set; }
    }
}
