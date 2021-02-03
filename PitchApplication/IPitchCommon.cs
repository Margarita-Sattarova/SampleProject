using Framework;

namespace PitchApplication {
    public interface IPitchCommon {
        ICommand MoveNextCommand { get; }
        ICommand MovePreviousCommand { get; }
        ICommand ReturnToStartCommand { get; }
        ICommand SkipNextMoveCommand { get; }
    }
}
