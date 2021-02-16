using System;
using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PitchApplication;

namespace PitchApplicationTest {
    [TestClass]
    public class PitchCommonCommandsAccessTest
    {
        private Mock<IPitch> ApplicationMock;
        private IPitch Pitch;
        private Mock<IPitchCommandsAccessOwner> PitchCommandsAccessOwnerMock;
        private PitchCommandsAccess CommandsAccess;
        private Mock<ICommandsAccessOwner> CommandsAccessOwnerMock;

        private Mock<ICommonPitchHost> CommonPitchHostMock;
        private CommonPitchHost CommonPitchHost;

        private Mock<IPitchHost> PitchHostMock;


        [TestInitialize]
        public void TestInitialize()
        {
            SetupApplicationMock();
            CommandsAccessOwnerMock = ApplicationMock.As<ICommandsAccessOwner>();
            PitchCommandsAccessOwnerMock = ApplicationMock.As<IPitchCommandsAccessOwner>();
            AllowCommands(true);
            PitchCommandsAccessOwnerMockSetupCommandsEnabledMethods(true);

            CommandsAccessOwnerMock = ApplicationMock.As<ICommandsAccessOwner>();
            CommonPitchHostMock = ApplicationMock.As<ICommonPitchHost>();
            PitchHostMock = new Mock<IPitchHost>();
            PitchHostMock.Setup(o => o.CanMove).Returns(true);
            //var commonPitchHost = PitchHostMock.As<ICommonPitchHost>();
            //commonPitchHost.Setup(o => o.IsInFocus).Returns(true);
            //commonPitchHost.Setup(o => o.IsOnLine).Returns(true);
            //commonPitchHost.Setup(o => o.IsRunning).Returns(true);

            ApplicationMock.Setup(o => o.Host).Returns(PitchHostMock.Object);
            Pitch = ApplicationMock.Object;
            CommandsAccess = new PitchCommandsAccess((IPitchCommandsAccessOwner)CommandsAccessOwnerMock.Object);

            
        }

        [TestMethod]
        public void MoveNextCommandEnabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.MoveNextCommand, true);
        }

        [TestMethod]
        public void MoveNextCommandDisabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandDisabledTest(Pitch.MoveNextCommand, true);
        }

        [TestMethod]
        public void MovePreviousCommandEnabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.MovePreviousCommand, true);
        }

        [TestMethod]
        public void MovePreviousCommandDisabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandDisabledTest(Pitch.MovePreviousCommand, true);
        }

        [TestMethod]
        public void ReturnToStartCommandEnabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.ReturnToStartCommand, true);
        }

        [TestMethod]
        public void ReturnToStartCommandDisabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandDisabledTest(Pitch.ReturnToStartCommand, true);
        }

        [TestMethod]
        public void SkipNextMoveCommandEnabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.SkipNextMoveCommand, true);
        }

        [TestMethod]
        public void SkipNextMoveCommandDisabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandDisabledTest(Pitch.SkipNextMoveCommand, true);
        }

        [TestMethod]
        public void RunCommandEnabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.RunCommand, true);
        }

        [TestMethod]
        public void RunCommandDisabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandDisabledTest(Pitch.RunCommand, true);
        }

        [TestMethod]
        public void JumpCommandEnabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.JumpCommand, true);
        }

        [TestMethod]
        public void JumpCommandDisabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandDisabledTest(Pitch.JumpCommand, true);
        }

        private void SetupApplicationMock()
        {
            var applicationMock = new PitchMock<IPitch>();
            ApplicationMock = applicationMock.Create(Pitch);
            //ApplicationMock.Setup(o => o.CanMove).Returns(true);
            ApplicationMock.Setup(o => o.CanRun).Returns(true);
            ApplicationMock.Setup(o => o.CanJump).Returns(true);
            SetupCommonPitchHostMock(true, true, true);
        }

        private void SetupCommonPitchHostMock(bool isInFocus, bool isOnline, bool isRunning) {
            var commonPitchHostMock = new CommonPitchHostMock<ICommonPitchHost>();
            CommonPitchHostMock = commonPitchHostMock.Create(CommonPitchHost);
            CommonPitchHostMock.Setup(o => o.IsInFocus).Returns(isInFocus);
            CommonPitchHostMock.Setup(o => o.IsOnLine).Returns(isOnline);
            CommonPitchHostMock.Setup(o => o.IsRunning).Returns(isRunning);
        }

        private void SetupApplicationCommandsAccessOwnerMock(bool isInFocus, bool isRunning, bool isOnline) {
            CommandsAccessOwnerMock.Setup(o => o.IsInFocus).Returns(isInFocus);
            CommandsAccessOwnerMock.Setup(o => o.IsRunning).Returns(isRunning);
            CommandsAccessOwnerMock.Setup(o => o.IsOnLine).Returns(isOnline);

            //CommandsAccessOwnerMock.Setup(o => o.).Returns(isOnline);
        }

        private void AllowCommands(bool commandsAllowed) {
            PitchCommandsAccessOwnerMock.Setup(o => o.AllowCommands).Returns(commandsAllowed);
        }

        private void PitchCommandsAccessOwnerMockSetupCommandsEnabledMethods(bool commandsEnabled) {
            PitchCommandsAccessOwnerMock.Setup(o => o.EnabledMoveNextCommand()).Returns(commandsEnabled);
            PitchCommandsAccessOwnerMock.Setup(o => o.EnabledMovePreviousCommand()).Returns(commandsEnabled);
            PitchCommandsAccessOwnerMock.Setup(o => o.EnabledReturnToStartCommand()).Returns(commandsEnabled);
            PitchCommandsAccessOwnerMock.Setup(o => o.EnabledSkipNextMoveCommand()).Returns(commandsEnabled);
            PitchCommandsAccessOwnerMock.Setup(o => o.EnabledRunCommand()).Returns(commandsEnabled);
            PitchCommandsAccessOwnerMock.Setup(o => o.EnabledJumpCommand()).Returns(commandsEnabled);
        }

        private void CommandDisabledTest(ICommand command, bool disabled) {
            CommandDisabledTest(command, disabled, b => {}, true);
        }

        private void CommandDisabledTest(ICommand command, bool disabled, Action<bool> settingDisableAction) {
            CommandDisabledTest(command, disabled, b => { }, true);
        }

        private void CommandDisabledTest(ICommand command, bool disabled, Action<bool> settingDisableAction, bool settingDisabled) {
            settingDisableAction?.Invoke(settingDisabled);
            CallDisableCommands();
            Assert.AreEqual(disabled, !command.Enabled);
        }

        private void CommandEnabledTest(ICommand command, bool enabled) {
            CommandEnabledTest(command, enabled, b => { }, true);
        }

        private void CommandEnabledTest(ICommand command, bool enabled, Action<bool> settingEnableAction) {
            CommandEnabledTest(command, enabled, b => { }, true);
        }

        private void CommandEnabledTest(ICommand command, bool enabled, Action<bool> settingEnableAction, bool settingEnabled) {
            settingEnableAction?.Invoke(settingEnabled);
            CallRefreshCommandAccess();
            Assert.AreEqual(enabled, command.Enabled);
        }

        private void CallRefreshCommandAccess() {
            CommandsAccess.RefreshCommandsAccess(false);
        }
        private void CallDisableCommands() {
            CommandsAccess.RefreshCommandsAccess(true);
        }
    }
}
