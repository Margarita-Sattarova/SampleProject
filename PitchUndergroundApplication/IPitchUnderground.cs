using Framework;
using PitchApplication;

namespace PitchUndergroundApplication {
    public interface IPitchUnderground : IPitchCommon, IUndergroundMovement {
        ICommand SwitchToLightCommand { get; }
        ICommand SwitchToDarkCommand { get; }
        ICommand FindWayCommand { get; }
    }
}
