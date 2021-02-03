using Framework;

namespace PitchApplication {
    public abstract class PitchCommonDefinition : IPitchCommon {
        protected IPitchCommon PitchCommon;
        public IHost Host { get; internal set; }
        ICommonPitchHost CommonPitchHost => (ICommonPitchHost)Host;
        public bool IsRunning => Host.IsRunning;

        public virtual void Initialize() {  }

        #region Commands

        public ICommand MoveNextCommand {
            get {
                if (vMoveNextCommand == null) {
                    vMoveNextCommand = new Command { Name = "MoveNext" };
                }
                return vMoveNextCommand;
            }
        }

        private ICommand vMoveNextCommand;


        public ICommand MovePreviousCommand {
            get {
                if (vMovePreviousCommand == null) {
                    vMovePreviousCommand = new Command { Name = "MoveBack" };
                }
                return vMovePreviousCommand;
            }
        }

        private ICommand vMovePreviousCommand;

        public ICommand ReturnToStartCommand {
            get {
                if (vReturnToStartCommand == null) {
                    vReturnToStartCommand = new Command { Name = "ReturnToStart" };
                }
                return vReturnToStartCommand;
            }
        }

        private ICommand vReturnToStartCommand;

        public ICommand SkipNextMoveCommand {
            get {
                if (vSkipNextMoveCommand == null) {
                    vSkipNextMoveCommand = new Command { Name = "SkipNextMove" };
                }
                return vSkipNextMoveCommand;
            }
        }

        private ICommand vSkipNextMoveCommand;

        #endregion

        protected PitchCommonDefinition(IPitchCommon pitchCommon, IHost host) {
            PitchCommon = pitchCommon;
            Host = host;
        }

        public void MakeNextStep() {
            if (!IsRunning) { return; }
            
            if(!MoveNextCommand.Enabled) {
               
            }
            RefreshCommandsAccess(false);
        }

        public void MakePreviousStep() {
            if (!IsRunning) { return; }

            if (!MovePreviousCommand.Enabled) {
                
            }

            RefreshCommandsAccess(false);
        }

        public void ReturnToStart() {
            if (!IsRunning) { return; }

            if (!ReturnToStartCommand.Enabled) {
               
            }
            RefreshCommandsAccess(false);
        }

        public void SkipNextMove() {
            if (!IsRunning) { return; }

            if (!SkipNextMoveCommand.Enabled) {

            }
            RefreshCommandsAccess(false);
        }

        public virtual bool EnabledMoveNextCommand() {
            return CommonPitchHost.CanMove && CommonPitchHost.IsNextMove;
        }

        public virtual bool EnabledMovePreviousCommand() {
            return CommonPitchHost.CanMove && CommonPitchHost.IsPreviousMove;
        }

        public virtual bool EnabledReturnToStartCommand() {
            return CommonPitchHost.CanMove && CommonPitchHost.IsReturnToStart;
        }

        public virtual bool EnabledSkipNextMoveCommand() {
            return CommonPitchHost.CanMove && CommonPitchHost.IsSkipNextMove;
        }

        protected abstract ICommandsAvailability GetCommandsAvailabilityObject();

        protected abstract ICommandsAccess GetCommandsAccessObject();

        protected void DisableCommands() {
            ICommandsAccess commandsAccess = GetCommandsAccessObject();
            commandsAccess.RefreshCommandsAccess(true);
        }

        public void RefreshCommandsAccess(bool disableAll) {
            ICommandsAccess commandsAccess = GetCommandsAccessObject();
            commandsAccess.RefreshCommandsAccess(disableAll);
        }
    }
}
