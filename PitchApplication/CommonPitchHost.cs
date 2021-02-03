namespace PitchApplication {
    public class CommonPitchHost : ICommonPitchHost {
        public bool IsRunning { get; set; } = true;
        public bool IsInFocus { get; set; } = true;
        public bool IsOnLine { get; set; } = true;
        public bool CanMove { get; set; } = true;
        public bool CanRun { get; set; } = true;
        public bool CanJump { get; set; } = true;
    }
}
