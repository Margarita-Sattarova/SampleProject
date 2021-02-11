using Framework;

namespace PitchApplication {
    public interface IPitchCommon {
        IHost Host { get; set; }
        ICommand MoveNextCommand { get; }
        ICommand MovePreviousCommand { get; }
        ICommand ReturnToStartCommand { get; }
        ICommand SkipNextMoveCommand { get; }
    }
}
