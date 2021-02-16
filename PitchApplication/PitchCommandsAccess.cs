namespace PitchApplication {
    internal class PitchCommandsAccess : PitchCommonCommandsAccess<IPitchCommandsAccessOwner> {
        public PitchCommandsAccess(IPitchCommandsAccessOwner owner) : base(owner) { }

        protected override void SetCommandsAccess(bool disableAll) {
            base.SetCommandsAccess(disableAll);

            bool allowCommands = !disableAll && Owner.AllowCommands;

            IPitch applet = Owner;

            applet.RunCommand.Enabled = allowCommands && Owner.IsRunning && Owner.CanRun;
            applet.JumpCommand.Enabled = allowCommands && Owner.IsRunning && Owner.CanJump;
        }
    }
}
