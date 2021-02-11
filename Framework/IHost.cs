namespace Framework {
    public interface IHost {
        bool IsRunning { get; }

        bool IsInFocus { get; }

        bool IsOnLine { get; }
    }
}
