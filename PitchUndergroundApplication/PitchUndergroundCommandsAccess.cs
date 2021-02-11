using PitchApplication;

namespace PitchUndergroundApplication {
    internal class PitchUndergroundCommandsAccess : PitchCommonCommandsAccess<IPitchUndergroundCommandsAccessOwner> {
        public PitchUndergroundCommandsAccess(IPitchUndergroundCommandsAccessOwner owner) : base(owner) { }

        protected override void SetCommandsAccess(bool disableAll) {
            base.SetCommandsAccess(disableAll);

            IPitchUnderground applet = Owner;

            applet.FindWayCommand.Enabled = Owner.IsRunning && Owner.CanCrawl;
            applet.SwitchToDarkCommand.Enabled = Owner.IsRunning && Owner.CanCrawl;
            applet.SwitchToLightCommand.Enabled = Owner.IsRunning && Owner.CanCrawl;
        }
    }
}
