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

        [TestInitialize]
        public void TestInitialize()
        {
            SetupApplicationMock();
            CommandsAccessOwnerMock = ApplicationMock.As<ICommandsAccessOwner>();
            PitchCommandsAccessOwnerMock = ApplicationMock.As<IPitchCommandsAccessOwner>();
            CommandsAccessOwnerMock = ApplicationMock.As<ICommandsAccessOwner>();
            CommonPitchHostMock = ApplicationMock.As<ICommonPitchHost>();
            Pitch = ApplicationMock.Object;
            CommandsAccess = new PitchCommandsAccess((IPitchCommandsAccessOwner)CommandsAccessOwnerMock.Object);

            
        }

        [TestMethod]
        public void MoveNextCommandEnabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true);
            CommandEnabledTest(Pitch.MoveNextCommand, true);

        }

        private void SetupApplicationMock()
        {
            var applicationMock = new PitchMock<IPitch>();
            ApplicationMock = applicationMock.Create(Pitch);
            SetupCommonPitchHostMock();
        }

        private void SetupCommonPitchHostMock() {
            var commonPitchHostMock = new CommonPitchHostMock<ICommonPitchHost>();
            CommonPitchHostMock = commonPitchHostMock.Create(CommonPitchHost);

        }

        private void SetupApplicationCommandsAccessOwnerMock(bool isInFocus, bool isRunning) {
            CommandsAccessOwnerMock.Setup(o => o.IsInFocus).Returns(isInFocus);
            CommandsAccessOwnerMock.Setup(o => o.IsRunning).Returns(isRunning);
        }

        private void CommandEnabledTest(ICommand command, bool enabled) {
            CommandEnabledTest(command, enabled, b => {}, true);
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
