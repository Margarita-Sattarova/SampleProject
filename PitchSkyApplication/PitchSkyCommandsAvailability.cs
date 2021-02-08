using Framework;
using PitchApplication;

namespace PitchSkyApplication {
    public class PitchSkyCommandsAvailability : PitchCommonCommandsAvailability<IPitchSky> {
        public PitchSkyCommandsAvailability(IPitchSky pitch) : base(pitch) { }
        public override void InitializeCommandsAvailability() {
            base.InitializeCommandsAvailability();
            Pitch.FlyForwardCommand.SetUnavailable(!Pitch.CanFly);
            Pitch.TakeOffCommand.SetUnavailable(!Pitch.CanFly);
            Pitch.LandCommand.SetUnavailable(!Pitch.CanLand);
        }
    }
}
