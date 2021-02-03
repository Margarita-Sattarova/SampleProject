using Framework;

namespace PitchApplication {
    public interface IPitchCommonCommandsAccessOwner : ICommandsAccessOwner, IPitchCommon {
        bool AllowCommands { get; }
        bool EnabledMoveNextCommand { get; }
        bool EnabledMovePreviousCommand { get; }
        bool EnabledReturnToStartCommand { get; }
        bool EnabledSkipNextMoveCommand { get; }
    }
}
