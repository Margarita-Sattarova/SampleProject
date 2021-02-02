using System;

namespace Framework {
    public interface ICommand {
        string Name { get; set; }
        bool Enabled { get; set; }
        bool Available { get; set; }

        event ExecutingEventHandler Executing;
        event ExecutedEventHandler Executed;

        void Execute();
        void Cancel();
    }

    public delegate void ExecutedEventHandler(object sender, EventArgs args);

    public delegate void ExecutingEventHandler(object sender, EventArgs args);
}
