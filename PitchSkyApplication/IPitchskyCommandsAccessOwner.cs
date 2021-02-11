using PitchApplication;

namespace PitchSkyApplication {
    interface IPitchSkyCommandsAccessOwner : IPitchCommonCommandsAccessOwner, IPitchSky {
        bool CanFly { get; }
        bool CanLand { get; }
    }
}
