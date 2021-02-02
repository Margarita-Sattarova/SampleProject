namespace Framework
{
    public interface ICommandsAccess
    {
        void RefreshCommandsAccess(bool disableAll);
        void InitialCommandsDisabling();
    }
}
