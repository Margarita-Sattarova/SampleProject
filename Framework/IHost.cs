using System;
namespace Framework {
    public interface IHost {
        bool IsRunning { get; set; }

        bool IsInFocus { get; set; }

        bool IsOnLine { get; set; }
    }
}
