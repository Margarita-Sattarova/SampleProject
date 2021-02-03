using PitchApplication;

namespace PitchSkyApplication {
    public interface ISkyMovement : ICommonMovement {
        bool CanFly { get; set; }
    }
}
