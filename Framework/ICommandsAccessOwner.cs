
namespace Framework
{
    public interface ICommandsAccessOwner
    {
        bool IsRunning { get; }

        bool IsInFocus { get; }
    }
}
