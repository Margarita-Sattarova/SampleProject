using Framework;

namespace PitchApplication {
    interface IPitchCommandsAccessOwner : IPitchCommonCommandsAccessOwner, IPitch {
        bool CanRun { get; }
        bool CanJump { get; }
    }
}
