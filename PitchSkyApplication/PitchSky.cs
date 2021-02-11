using Framework;
using PitchApplication;

namespace PitchSkyApplication {
    public class PitchSky : IPitchSkyCommandsAccessOwner {
        public IHost Host { get; set; } = new PitchHost();

        private ISkyMovement SkyMovement;
        private bool IsOnline => Host.IsOnLine;
        private bool IsRunning => Host.IsRunning;
        private bool IsInFocus => Host.IsInFocus;
        bool IPitchCommonCommandsAccessOwner.AllowCommands => IsRunning && IsInFocus && IsOnline;
        bool IPitchSkyCommandsAccessOwner.CanFly => ((IPitchSkyHost)Host).CanFly;
        bool IPitchSkyCommandsAccessOwner.CanLand => ((IPitchSkyHost)Host).CanLand;
        bool ICommandsAccessOwner.IsRunning => Host.IsRunning;
        bool ICommandsAccessOwner.IsInFocus => Host.IsInFocus;
        internal PitchSkyImplementation Implementation { get; set; }

        public PitchSky(IHost Host) {
            Implementation = new PitchSkyImplementation(this, Host);
            SkyMovement = (ISkyMovement)Host;
        }

        public bool EnabledMoveNextCommand() => Implementation.EnabledMoveNextCommand();
        public bool EnabledMovePreviousCommand() => Implementation.EnabledMovePreviousCommand();
        public bool EnabledReturnToStartCommand() => Implementation.EnabledReturnToStartCommand();
        public bool EnabledSkipNextMoveCommand() => Implementation.EnabledSkipNextMoveCommand();
        public bool CanLand {
            get => SkyMovement.CanLand;
            set => SkyMovement.CanLand = value;
        }
        public bool CanFly {
            get => SkyMovement.CanFly;
            set => SkyMovement.CanFly = value;
        }

        #region Commands
        ICommand IPitchSky.FlyForwardCommand {
            get {
                if (vFlyForwardCommand == null) {
                    vFlyForwardCommand = new Command { Name = "Fly Forward" };
                }
                return vFlyForwardCommand;
            }
        }

        private ICommand vFlyForwardCommand;

        ICommand IPitchSky.LandCommand {
            get {
                if (vLandCommand == null) {
                    vLandCommand = new Command { Name = "Land" };
                }
                return vLandCommand;
            }
        }

        private ICommand vLandCommand;

        ICommand IPitchSky.TakeOffCommand {
            get {
                if (vTakeOffCommand == null) {
                    vTakeOffCommand = new Command { Name = "Take Off" };
                }
                return vTakeOffCommand;
            }
        }

        private ICommand vTakeOffCommand;

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

        public bool CanMove {
            get => SkyMovement.CanMove;
            set => SkyMovement.CanMove = value;
        }
        //public bool CanRun {
        //    get => SkyMovement.CanRun;
        //    set => SkyMovement.CanRun = value;
        //}
        //public bool CanJump {
        //    get => SkyMovement.CanJump;
        //    set => SkyMovement.CanJump = value;
        //}
    }
}
