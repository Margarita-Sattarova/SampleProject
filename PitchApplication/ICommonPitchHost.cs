using Framework;

namespace PitchApplication {
    public interface ICommonPitchHost : IHost, ICommonMovement {
        bool IsNextMove { get; set; }
        bool IsPreviousMove { get; set; }
        bool IsReturnToStart { get; set; }
        bool IsSkipNextMove { get; set; }
    }
}
