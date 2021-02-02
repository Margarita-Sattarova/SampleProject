using System;

namespace Framework {
    public class Command : ICommand {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public bool Available { get; set; }

        public event ExecutingEventHandler Executing;
        public event ExecutedEventHandler Executed;

        public void Execute() {
            throw new NotImplementedException();
        }

        public void Cancel() {
            throw new NotImplementedException();
        }
    }
}
