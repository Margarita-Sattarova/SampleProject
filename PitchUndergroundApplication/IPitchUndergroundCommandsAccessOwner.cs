using PitchApplication;

namespace PitchUndergroundApplication {
    interface IPitchUndergroundCommandsAccessOwner : IPitchCommonCommandsAccessOwner, IPitchUnderground {
        bool CanCrawl { get; }
    }
}
