using Framework;
using PitchApplication;

namespace PitchSkyApplication {
    public interface IPitchSky : IPitchCommon {
        bool CanFly { get; set; }
        ICommand FlyForwardCommand { get; set; }
        ICommand LandCommand { get; set; }
        ICommand TakeOffCommand { get; set; }
    }
}
