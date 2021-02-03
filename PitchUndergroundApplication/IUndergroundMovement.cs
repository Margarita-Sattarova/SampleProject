using PitchApplication;

namespace PitchUndergroundApplication {
    public interface IUndergroundMovement : ICommonMovement {
        bool CanCrawl { get; set; }
    }
}
