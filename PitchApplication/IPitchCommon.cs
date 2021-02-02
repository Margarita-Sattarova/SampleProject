using Framework;

namespace PitchApplication {
    public interface IPitchCommon {
        bool IsOnline { get; set; }
        bool CanMove { get; set; }
        ICommand MoveNextCommand { get; set; }
        ICommand MovePreviousCommand { get; set; }
        ICommand ReturnToStartCommand { get; set; }
        ICommand SkipNextMoveCommand { get; set; }
    }
}
