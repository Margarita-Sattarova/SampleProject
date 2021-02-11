using PitchApplication;

namespace PitchSkyApplication {
    internal class PitchSkyCommandsAccess : PitchCommonCommandsAccess<IPitchSkyCommandsAccessOwner> {
        public PitchSkyCommandsAccess(IPitchSkyCommandsAccessOwner owner) : base(owner) { }

        protected override void SetCommandsAccess(bool disableAll) {
            base.SetCommandsAccess(disableAll);

            IPitchSky applet = Owner;

            applet.FlyForwardCommand.Enabled = Owner.IsRunning && Owner.CanFly;
            applet.LandCommand.Enabled = Owner.IsRunning && Owner.CanLand;
            applet.TakeOffCommand.Enabled = Owner.IsRunning && Owner.CanFly;
        }
    }
}
