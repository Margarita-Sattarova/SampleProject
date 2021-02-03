namespace PitchApplication {
    public interface ICommonMovement {
        bool CanMove { get; set; }
        bool CanRun { get; set; }
        bool CanJump { get; set; }
    }
}
