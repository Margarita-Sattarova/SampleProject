namespace PitchApplication {
    public class CommonMovement : ICommonMovement {
        public bool CanMove { get; set; } = true;
        public bool CanRun { get; set; } = true;
        public bool CanJump { get; set; } = true;
    }
}
