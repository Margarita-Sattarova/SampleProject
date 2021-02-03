using Framework;

namespace PitchApplication {
    public class Pitch : IPitchCommandsAccessOwner {
        private IHost Host;
        private bool IsOnline => Host.IsOnLine;
        private bool IsRunning => Host.IsRunning;
        private bool IsInFocus => Host.IsInFocus;
        internal PitchCommonImplementation Implementation { get; set; }
        public Pitch(IHost Host) {
            Implementation = new PitchCommonImplementation(this, Host);
        }

        bool IPitchCommandsAccessOwner.CanRun => throw new System.NotImplementedException();

        bool IPitchCommandsAccessOwner.CanJump => throw new System.NotImplementedException();

        bool IPitchCommonCommandsAccessOwner.AllowCommands => throw new System.NotImplementedException();

        bool IPitchCommonCommandsAccessOwner.EnabledMoveNextCommand => throw new System.NotImplementedException();

        bool IPitchCommonCommandsAccessOwner.EnabledMovePreviousCommand => throw new System.NotImplementedException();

        bool IPitchCommonCommandsAccessOwner.EnabledReturnToStartCommand => throw new System.NotImplementedException();

        bool IPitchCommonCommandsAccessOwner.EnabledSkipNextMoveCommand => throw new System.NotImplementedException();

        bool ICommandsAccessOwner.IsRunning => Host.IsRunning;

        bool ICommandsAccessOwner.IsInFocus => Host.IsInFocus;

        #region Commands
        ICommand IPitch.RunCommand {
            get {
                if (vRunCommand == null) {
                    vRunCommand = new Command { Name = "Run" };
                }
                return vRunCommand;
            }
        }

        private ICommand vRunCommand;

        ICommand IPitch.JumpCommand {
            get {
                if (vJumpCommand == null) {
                    vRunCommand = new Command { Name = "Jump" };
                }
                return vRunCommand;
            }
        }

        private ICommand vJumpCommand;

        public ICommand MoveNextCommand => Implementation.MoveNextCommand;
        public ICommand MovePreviousCommand => Implementation.MovePreviousCommand;
        public ICommand ReturnToStartCommand => Implementation.ReturnToStartCommand;
        public ICommand SkipNextMoveCommand => Implementation.SkipNextMoveCommand;
        #endregion

        public void MakeNextStep() {
            if (!IsRunning) { return; }

            Implementation.MakeNextStep();

        }

        public void MakePreviousStep() {
            if (!IsRunning) { return; }

            Implementation.MakePreviousStep();
        }

        public void ReturnToStart() {
            if (!IsRunning) { return; }

            Implementation.ReturnToStart();
        }

        public void SkipNextMove() {
            if (!IsRunning) { return; }

            Implementation.SkipNextMove();
        }
    }
}
