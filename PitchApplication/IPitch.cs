using Framework;

namespace PitchApplication {
    public interface IPitch : IPitchCommon, IPitchMovement {
        ICommand RunCommand { get; }
        ICommand JumpCommand { get; }
    }
}
