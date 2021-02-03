using Framework;

namespace PitchApplication {
    public class PitchCommandsAvailability : PitchCommonCommandsAvailability<IPitch> {
        public PitchCommandsAvailability(IPitch pitch) : base(pitch) { }
        public override void InitializeCommandsAvailability() {
            base.InitializeCommandsAvailability();
            Pitch.RunCommand.SetUnavailable(!Pitch.CanMove);
            Pitch.JumpCommand.SetUnavailable(!Pitch.CanMove);
        }
    }
}
