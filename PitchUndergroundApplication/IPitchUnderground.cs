using Framework;
using PitchApplication;

namespace PitchUndergroundApplication {
    public interface IPitchUnderground : IPitchCommon, IUndergroundMovement {
        //bool CanCrawl { get; set; }
        ICommand SwitchToLightCommand { get; }
        ICommand SwitchToDarkCommand { get; }
        ICommand FindWayCommand { get; }
    }
}
