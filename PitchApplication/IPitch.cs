using Framework;

namespace PitchApplication {
    public interface IPitch : IPitchCommon {
        ICommand RunCommand { get; set; }
        ICommand JumpCommand { get; set; }
    }
}
