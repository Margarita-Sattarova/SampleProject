using Framework;

namespace PitchApplication {
    public abstract class PitchCommonCommandsAccess<TOwner> : CommandsAccess<TOwner> where TOwner : IPitchCommonCommandsAccessOwner {
        protected PitchCommonCommandsAccess(TOwner owner) : base(owner) { }

        protected override void SetCommandsAccess(bool disableAll) {
            bool allowCommands = !disableAll && Owner.AllowCommands;

            IPitchCommon pitch = Owner;

            pitch.MoveNextCommand.Enabled = allowCommands && Owner.EnabledMoveNextCommand();
            pitch.MovePreviousCommand.Enabled = allowCommands && Owner.EnabledMovePreviousCommand();
            pitch.ReturnToStartCommand.Enabled = allowCommands && Owner.EnabledReturnToStartCommand();
            pitch.SkipNextMoveCommand.Enabled = allowCommands && Owner.EnabledSkipNextMoveCommand();
        }
    }
}
