
namespace PitchApplication
{
    internal class PitchCommandsAccess : PitchCommonCommandsAccess<IPitchCommandsAccessOwner>
    {
        public PitchCommandsAccess(IPitchCommandsAccessOwner owner) : base(owner) { }

        protected override void SetCommandsAccess(bool disableAll)
        {
            base.SetCommandsAccess(disableAll);

            IPitch applet = Owner;

            applet.RunCommand.Enabled = Owner.IsRunning && Owner.CanRun;
            applet.JumpCommand.Enabled = Owner.IsRunning && Owner.CanJump;
        }
    }
}
