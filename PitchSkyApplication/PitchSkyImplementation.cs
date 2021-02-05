using Framework;
using PitchApplication;

namespace PitchSkyApplication {
    public class PitchSkyImplementation : PitchCommonDefinition {
        private IPitchSky PitchSky => (IPitchSky)PitchCommon;

        public PitchSkyImplementation(IPitchSky pitch, IHost host) : base(pitch, host) { }

        public override void Initialize() {
            base.Initialize();
        }

        protected override ICommandsAccess GetCommandsAccessObject() {
            return new PitchSkyCommandsAccess((IPitchSkyCommandsAccessOwner)PitchSky);
        }

        protected override ICommandsAvailability GetCommandsAvailabilityObject() {
            return new PitchSkyCommandsAvailability(PitchSky);
        }
    }
}
