namespace PitchApplication {
    public interface IPitchCommandsAccessOwner : IPitchCommonCommandsAccessOwner, IPitch {
        bool CanRun { get; }
        bool CanJump { get; }
        bool EnabledRunCommand();
        bool EnabledJumpCommand();
    }
}
