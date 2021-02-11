using Framework;

namespace PitchApplication {
    public class Pitch : IPitchCommandsAccessOwner, IPitchHost
    {
        public IHost Host { get; set; } = new PitchHost();

        private IPitchMovement PitchMovement;
        private bool IsRunning => Host.IsRunning;
        bool IHost.IsRunning => Host.IsRunning;
        bool IHost.IsInFocus => IsInFocus;
        public bool IsOnLine => Host.IsOnLine;

        bool IPitchCommonCommandsAccessOwner.AllowCommands => IsRunning && IsInFocus && IsOnLine;
        bool IPitchCommandsAccessOwner.CanRun => ((IPitchHost)Host).CanRun;
        bool IPitchCommandsAccessOwner.CanJump => ((IPitchHost)Host).CanJump;
        bool ICommandsAccessOwner.IsRunning => Host.IsRunning;
        bool ICommandsAccessOwner.IsInFocus => IsInFocus;

        private bool IsInFocus => Host.IsInFocus;
        internal PitchCommonImplementation Implementation { get; set; }
       
        public Pitch() {
            Implementation = new PitchCommonImplementation(this, Host);
        }

        public bool EnabledMoveNextCommand() => Implementation.EnabledMoveNextCommand();
        public bool EnabledMovePreviousCommand() => Implementation.EnabledMovePreviousCommand();
        public bool EnabledReturnToStartCommand() => Implementation.EnabledReturnToStartCommand();
        public bool EnabledSkipNextMoveCommand() => Implementation.EnabledSkipNextMoveCommand();
        public bool CanMove {
            get => PitchMovement.CanMove;
            set => PitchMovement.CanMove = value;
        }
        public bool CanRun {
            get => PitchMovement.CanRun;
            set => PitchMovement.CanRun = value;
        }
        public bool CanJump {
            get => PitchMovement.CanJump;
            set => PitchMovement.CanJump = value;
        }

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

        public bool IsNextMove { get; set; }
        public bool IsPreviousMove { get; set; }
        public bool IsReturnToStart { get; set; }
        public bool IsSkipNextMove { get; set; }
    }
}
