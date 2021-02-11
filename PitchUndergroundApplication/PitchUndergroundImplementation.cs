using Framework;
using PitchApplication;

namespace PitchUndergroundApplication {
    public class PitchUndergroundImplementation : PitchCommonDefinition {
        private IPitchUnderground PitchUnderground => (IPitchUnderground)PitchCommon;

        public PitchUndergroundImplementation(IPitchUnderground pitch, IHost host) : base(pitch, host) { }

        public override void Initialize() {
            base.Initialize();
        }

        protected override ICommandsAccess GetCommandsAccessObject() {
            return new PitchUndergroundCommandsAccess((IPitchUndergroundCommandsAccessOwner)PitchUnderground);
        }

        protected override ICommandsAvailability GetCommandsAvailabilityObject() {
            return new PitchUndergroundCommandsAvailability(PitchUnderground);
        }
    }
}
