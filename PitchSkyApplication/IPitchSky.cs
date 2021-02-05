using Framework;
using PitchApplication;

namespace PitchSkyApplication {
    public interface IPitchSky : IPitchCommon, ISkyMovement {
        ICommand FlyForwardCommand { get; }
        ICommand LandCommand { get; }
        ICommand TakeOffCommand { get; }
    }
}
