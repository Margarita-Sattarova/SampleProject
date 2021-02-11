using Framework;

namespace PitchApplication {
    public interface IPitch : IPitchCommon, ICommonMovement {
        ICommand RunCommand { get; }
        ICommand JumpCommand { get; }
    }
}
