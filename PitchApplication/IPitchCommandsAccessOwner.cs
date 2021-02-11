namespace PitchApplication {
    public interface IPitchCommandsAccessOwner : IPitchCommonCommandsAccessOwner, IPitch {
        bool CanRun { get; }
        bool CanJump { get; }
    }
}
