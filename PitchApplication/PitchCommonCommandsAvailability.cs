using Framework;
using System;

namespace PitchApplication {
    public abstract class PitchCommonCommandsAvailability<TPitch> : ICommandsAvailability
        where TPitch : IPitchCommon, ICommonMovement {
        protected readonly TPitch Pitch;

        protected PitchCommonCommandsAvailability(TPitch pitch) {
            Pitch = pitch;
        }

        public virtual void InitializeCommandsAvailability() {
            Pitch.MoveNextCommand.SetUnavailable(!Pitch.CanMove);
            Pitch.MovePreviousCommand.SetUnavailable(!Pitch.CanMove);
            Pitch.ReturnToStartCommand.SetUnavailable(!Pitch.CanMove);
        }
    }
}
