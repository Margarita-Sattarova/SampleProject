using Framework;

namespace PitchUndergroundApplication {
    public class PitchUndergroundImplementation : IPitchUnderground {
        public bool IsOnline { get; set; }
        public bool CanMove { get; set; }
        public bool CanCrawl { get; set; }
        public ICommand MoveNextCommand { get; set; }
        public ICommand MovePreviousCommand { get; set; }
        public ICommand ReturnToStartCommand { get; set; }
        public ICommand SkipNextMoveCommand { get; set; }
        public ICommand SwitchToLightCommand { get; set; }
        public ICommand SwitchToDarkCommand { get; set; }
        public ICommand FindWayCommand { get; set; }
    }
}
