using Framework;

namespace PitchApplication {
    public interface IPitch : IPitchCommon {
        ICommand RunCommand { get; }
        ICommand JumpCommand { get; }
    }
}
