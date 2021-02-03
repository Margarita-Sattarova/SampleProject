using Framework;

namespace PitchApplication {
    public class PitchCommonImplementation : PitchCommonDefinition {

        private IPitch Pitch => (IPitch)PitchCommon;

        public PitchCommonImplementation(IPitch pitch, IHost host) : base(pitch, host) { }

        public override void Initialize() {
            base.Initialize();
        }

        protected override ICommandsAccess GetCommandsAccessObject() {
            return new PitchCommandsAccess((IPitchCommandsAccessOwner)Pitch);
        }

        protected override ICommandsAvailability GetCommandsAvailabilityObject() {
            return new PitchCommandsAvailability(Pitch);
        }
    }
}
