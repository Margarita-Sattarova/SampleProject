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
        private ICommonPitchHost CommonPitchHost;

        private Mock<IPitchHost> PitchHostMock;


        [TestInitialize]
        public void TestInitialize()
        {
            SetupApplicationMock();
            var pitchMovement = ApplicationMock.As<IPitchMovement>();
            pitchMovement.Setup(o => o.CanRun).Returns(true);
            pitchMovement.Setup(o => o.CanJump).Returns(true);
            CommandsAccessOwnerMock = ApplicationMock.As<ICommandsAccessOwner>();
            PitchCommandsAccessOwnerMock = ApplicationMock.As<IPitchCommandsAccessOwner>();
            PitchCommandsAccessOwnerMock.Setup(o => o.CanJump).Returns(true);
            PitchCommandsAccessOwnerMock.Setup(o => o.CanRun).Returns(true);
            AllowCommands(true);
            PitchCommandsAccessOwnerMockSetupCommandsEnabledMethods(true);

            CommandsAccessOwnerMock = ApplicationMock.As<ICommandsAccessOwner>();
            CommonPitchHostMock = ApplicationMock.As<ICommonPitchHost>();
            PitchHostMock = new Mock<IPitchHost>();
            PitchHostMock.Setup(o => o.CanMove).Returns(true);

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
            CommandEnabledTest(Pitch.MoveNextCommand, false);
        }

        [TestMethod]
        public void MovePreviousCommandEnabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.MovePreviousCommand, true);
        }

        [TestMethod]
        public void MovePreviousCommandDisabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.MovePreviousCommand, false);
        }

        [TestMethod]
        public void ReturnToStartCommandEnabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.ReturnToStartCommand, true);
        }

        [TestMethod]
        public void ReturnToStartCommandDisabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.ReturnToStartCommand, false);
        }

        [TestMethod]
        public void SkipNextMoveCommandEnabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.SkipNextMoveCommand, true);
        }

        [TestMethod]
        public void SkipNextMoveCommandDisabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.SkipNextMoveCommand, false);
        }

        [TestMethod]
        public void RunCommandEnabledTest() {

            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.RunCommand, false);
        }

        [TestMethod]
        public void RunCommandDisabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.RunCommand, true);
        }

        [TestMethod]
        public void JumpCommandEnabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.JumpCommand, true);
        }

        [TestMethod]
        public void JumpCommandDisabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.JumpCommand, false);
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

        private void CommandEnabledTest(ICommand command, bool disabled) {
            CommandEnabledTest(command, disabled, b => { }, true);
        }

        private void CommandEnabledTest(ICommand command, bool disabled, Action<bool> settingEnableAction) {
            CommandEnabledTest(command, disabled, b => { }, true);
        }

        private void CommandEnabledTest(ICommand command, bool disabled, Action<bool> settingEnableAction, bool settingEnabled) {
            settingEnableAction?.Invoke(settingEnabled);
            CallRefreshCommandAccess(disabled);
            Assert.AreEqual(!disabled, command.Enabled);
        }

        private void CallRefreshCommandAccess(bool disabled) {
            CommandsAccess.RefreshCommandsAccess(disabled);
        }
    }
}
