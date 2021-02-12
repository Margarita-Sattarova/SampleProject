using Framework;
using PitchApplication;

namespace PitchUndergroundApplication {
    public class PitchUnderground : IPitchUndergroundCommandsAccessOwner {
        public IHost Host { get; set; } = new PitchHost();

        private IUndergroundMovement UndergroundMovement;
        //private bool IsOnline => Host.IsOnLine;
        private bool IsRunning => Host.IsRunning;
        private bool IsInFocus => Host.IsInFocus;
        public bool IsOnLine => Host.IsOnLine;
        bool IPitchCommonCommandsAccessOwner.AllowCommands => IsRunning && IsInFocus && IsOnLine;
        bool IPitchUndergroundCommandsAccessOwner.CanCrawl => ((IPitchUndergroundHost)Host).CanCrawl;
        bool ICommandsAccessOwner.IsRunning => Host.IsRunning;
        bool ICommandsAccessOwner.IsInFocus => Host.IsInFocus;
        internal PitchUndergroundImplementation Implementation { get; set; }

        public PitchUnderground(IHost Host) {
            Implementation = new PitchUndergroundImplementation(this, Host);
        }

        public bool EnabledMoveNextCommand() => Implementation.EnabledMoveNextCommand();
        public bool EnabledMovePreviousCommand() => Implementation.EnabledMovePreviousCommand();
        public bool EnabledReturnToStartCommand() => Implementation.EnabledReturnToStartCommand();
        public bool EnabledSkipNextMoveCommand() => Implementation.EnabledSkipNextMoveCommand();

        public bool CanMove {
            get => UndergroundMovement.CanMove;
            set => UndergroundMovement.CanMove = value;
        }

        public bool CanCrawl {
            get => UndergroundMovement.CanCrawl;
            set => UndergroundMovement.CanCrawl = value;
        }

        #region Commands
        ICommand IPitchUnderground.FindWayCommand => vFindWayCommand ?? (vFindWayCommand = new Command {Name = "Find Way"});

        private ICommand vFindWayCommand;

        ICommand IPitchUnderground.SwitchToLightCommand => vSwitchToLightCommand ?? (vSwitchToLightCommand = new Command {Name = "Switch To Light"});

        private ICommand vSwitchToLightCommand;

        ICommand IPitchUnderground.SwitchToDarkCommand => vSwitchToDarkCommand ?? (vSwitchToDarkCommand = new Command {Name = "Switch To Dark"});

        private ICommand vSwitchToDarkCommand;

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
