﻿using Framework;
using PitchApplication;

namespace PitchUndergroundApplication {
    public class PitchUnderground : IPitchUndergroundCommandsAccessOwner {
        private IHost Host;
        private bool IsOnline => Host.IsOnLine;
        private bool IsRunning => Host.IsRunning;
        private bool IsInFocus => Host.IsInFocus;
        bool IPitchCommonCommandsAccessOwner.AllowCommands => IsRunning && IsInFocus && IsOnline;
        bool IPitchUndergroundCommandsAccessOwner.CanCrawl => ((IPitchUndergroundHost)Host).CanCrawl;
        internal PitchUndergroundImplementation Implementation { get; set; }

        public PitchUnderground(IHost Host) {
            Implementation = new PitchUndergroundImplementation(this, Host);
        }

        public bool EnabledMoveNextCommand() => Implementation.EnabledMoveNextCommand();
        public bool EnabledMovePreviousCommand() => Implementation.EnabledMovePreviousCommand();
        public bool EnabledReturnToStartCommand() => Implementation.EnabledReturnToStartCommand();
        public bool EnabledSkipNextMoveCommand() => Implementation.EnabledSkipNextMoveCommand();
        bool ICommandsAccessOwner.IsRunning => Host.IsRunning;
        bool ICommandsAccessOwner.IsInFocus => Host.IsInFocus;

        #region Commands
        ICommand IPitchUnderground.FindWayCommand {
            get {
                if (vFindWayCommand == null) {
                    vFindWayCommand = new Command { Name = "Find Way" };
                }
                return vFindWayCommand;
            }
        }

        private ICommand vFindWayCommand;

        ICommand IPitchUnderground.SwitchToLightCommand {
            get {
                if (vSwitchToLightCommand == null) {
                    vSwitchToLightCommand = new Command { Name = "Switch To Light" };
                }
                return vSwitchToLightCommand;
            }
        }

        private ICommand vSwitchToLightCommand;

        ICommand IPitchUnderground.SwitchToDarkCommand {
            get {
                if (vSwitchToDarkCommand == null) {
                    vSwitchToDarkCommand = new Command { Name = "Switch To Dark" };
                }
                return vSwitchToDarkCommand;
            }
        }

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
