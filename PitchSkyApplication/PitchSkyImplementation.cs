using Framework;

namespace PitchSkyApplication {
    public class PitchSkyImplementation : IPitchSky {
        public bool IsOnline { get; set; }
        public bool CanMove { get; set; }
        public bool CanFly { get; set; }
        public ICommand MoveNextCommand { get; set; }
        public ICommand MovePreviousCommand { get; set; }
        public ICommand ReturnToStartCommand { get; set; }
        public ICommand SkipNextMoveCommand { get; set; }
        public ICommand FlyForwardCommand { get; set; }
        public ICommand LandCommand { get; set; }
        public ICommand TakeOffCommand { get; set; }
    }
}
