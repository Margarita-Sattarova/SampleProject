using Framework;

namespace PitchApplication {
    public interface IPitchCommonCommandsAccessOwner : ICommandsAccessOwner, IPitchCommon {
        bool AllowCommands { get; }
        bool EnabledMoveNextCommand();
        bool EnabledMovePreviousCommand();
        bool EnabledReturnToStartCommand();
        bool EnabledSkipNextMoveCommand();
    }
}
