using Framework;

namespace PitchApplication {
    public abstract class PitchCommonDefinition : IPitchCommon {
        protected IPitchCommon PitchCommon;

        public bool CanMove { get; set; } = true;

        public bool IsRunning { get; set; } = true;

        public virtual void Initialize()
        {
            IsOnline = true;
        }

        #region Commands
        public bool IsOnline {
            get => PitchCommon.IsOnline;
            set => PitchCommon.IsOnline = value;
        }

        public ICommand MoveNextCommand {
            get => PitchCommon.MoveNextCommand;
            set => PitchCommon.MoveNextCommand = value;
        }

        public ICommand MovePreviousCommand {
            get => PitchCommon.MovePreviousCommand;
            set => PitchCommon.MovePreviousCommand = value;
        }

        public ICommand ReturnToStartCommand {
            get => PitchCommon.ReturnToStartCommand;
            set => PitchCommon.ReturnToStartCommand = value;
        }

        public ICommand SkipNextMoveCommand {
            get => PitchCommon.SkipNextMoveCommand;
            set => PitchCommon.SkipNextMoveCommand = value;
        }

        #endregion

        protected PitchCommonDefinition(IPitchCommon pitchCommon)
        {
            PitchCommon = pitchCommon;
        }

        public void SomeMethod1()
        {
            RefreshCommandsAccess(false);
        }

        public void SomeMethod2()
        {
            RefreshCommandsAccess(false);
        }

        public void SomeMethod3()
        {
            RefreshCommandsAccess(false);
        }

        protected abstract ICommandsAvailability GetCommandsAvailabilityObject();

        protected abstract ICommandsAccess GetCommandsAccessObject();

        protected void DisableCommands()
        {
            ICommandsAccess commandsAccess = GetCommandsAccessObject();
            commandsAccess.RefreshCommandsAccess(true);
        }

        public void RefreshCommandsAccess(bool disableAll)
        {
            ICommandsAccess commandsAccess = GetCommandsAccessObject();
            commandsAccess.RefreshCommandsAccess(disableAll);
        }
    }
}
