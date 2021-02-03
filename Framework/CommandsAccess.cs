
namespace Framework {
    public abstract class CommandsAccess<TOwner> : ICommandsAccess where TOwner : ICommandsAccessOwner {
        protected TOwner Owner;

        protected CommandsAccess() { }

        protected CommandsAccess(TOwner owner) {
            Owner = owner;
        }

        public void RefreshCommandsAccess(bool disableAll) {
            if (disableAll) {
                SetCommandsAccess(disableAll);
            }
        }

        public virtual void InitialCommandsDisabling() { }

        protected virtual bool CanSetCommandsAccess() => Owner.IsRunning && Owner.IsInFocus;

        protected abstract void SetCommandsAccess(bool disableAll);
    }
}
