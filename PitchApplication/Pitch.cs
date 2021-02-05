using Framework;

namespace PitchApplication {
    public class Pitch : IPitchCommandsAccessOwner {
        private IHost Host;
        private bool IsOnline => Host.IsOnLine;
        private bool IsRunning => Host.IsRunning;
        private bool IsInFocus => Host.IsInFocus;
        bool IPitchCommonCommandsAccessOwner.AllowCommands => IsRunning && IsInFocus && IsOnline;
        bool IPitchCommandsAccessOwner.CanRun => ((ICommonPitchHost)Host).CanRun;
        bool IPitchCommandsAccessOwner.CanJump => ((ICommonPitchHost)Host).CanJump;
        internal PitchCommonImplementation Implementation { get; set; }
       
        public Pitch(IHost Host) {
            Implementation = new PitchCommonImplementation(this, Host);
        }

        public bool EnabledMoveNextCommand() => Implementation.EnabledMoveNextCommand();
        public bool EnabledMovePreviousCommand() => Implementation.EnabledMovePreviousCommand();
        public bool EnabledReturnToStartCommand() => Implementation.EnabledReturnToStartCommand();
        public bool EnabledSkipNextMoveCommand() => Implementation.EnabledSkipNextMoveCommand();
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
                    vJumpCommand = new Command { Name = "Jump" };
                }
                return vJumpCommand;
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
