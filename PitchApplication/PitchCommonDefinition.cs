using Framework;

namespace PitchApplication {
    public abstract class PitchCommonDefinition : IPitchCommon {
        protected IPitchCommon PitchCommon;

        public bool CanMove { get; set; } = true;
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

        public virtual void Initialize() {
            IsOnline = true;
            InitializeCommandAvailability();
        }

        private void InitializeCommandAvailability() {
            MoveNextCommand.Available = CanMove;
            MovePreviousCommand.Available = CanMove;
            ReturnToStartCommand.Available = CanMove;
            SkipNextMoveCommand.Available = CanMove;
        }

        public void MoveNext() {
            MoveNextCommand.Enabled = true;
        }

        public void MovePrevious() {
            MovePreviousCommand.Enabled = true;
        }

        public void ReturnToStart() {
            ReturnToStartCommand.Enabled = true;
        }

        public void SkipNextMove() {
            SkipNextMoveCommand.Enabled = true;
        }
    }
}
