using Framework;
using PitchApplication;

namespace PitchUndergroundApplication {
    public interface IPitchUnderground : IPitchCommon {
        bool CanCrawl { get; set; }
        ICommand SwitchToLightCommand { get; set; }
        ICommand SwitchToDarkCommand { get; set; }
        ICommand FindWayCommand { get; set; }
    }
}
