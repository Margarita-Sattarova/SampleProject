namespace Framework
{
    public static class CommandExtensions
    {
        public static void SetUnavailable(this ICommand command, bool unavailable)
        {
            Command applicationCommand = command as Command;
            if (applicationCommand == null) { return; }

            if (unavailable)
            {
                applicationCommand.Available = false;
            }
        }
    }
}
