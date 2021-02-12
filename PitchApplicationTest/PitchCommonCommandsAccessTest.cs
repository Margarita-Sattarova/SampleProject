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
            PitchCommandsAccessOwnerMock.Setup(o => o.AllowCommands).Returns(true);
            PitchCommandsAccessOwnerMock.Setup(o => o.EnabledMoveNextCommand()).Returns(true);
            PitchCommandsAccessOwnerMock.Setup(o => o.EnabledMovePreviousCommand()).Returns(true);
            //PitchCommandsAccessOwnerMock.Setup(o => o.EnabledMoveNextCommand()).Returns(true);

            CommandsAccessOwnerMock = ApplicationMock.As<ICommandsAccessOwner>();
            CommonPitchHostMock = ApplicationMock.As<ICommonPitchHost>();
            PitchHostMock = new Mock<IPitchHost>();
            PitchHostMock.Setup(o => o.CanMove).Returns(true);
            var commonPitchHost = PitchHostMock.As<ICommonPitchHost>();
            commonPitchHost.Setup(o => o.IsInFocus).Returns(true);
            commonPitchHost.Setup(o => o.IsOnLine).Returns(true);
            commonPitchHost.Setup(o => o.IsRunning).Returns(true);

            ApplicationMock.Setup(o => o.Host).Returns(PitchHostMock.Object);
            Pitch = ApplicationMock.Object;
            CommandsAccess = new PitchCommandsAccess((IPitchCommandsAccessOwner)CommandsAccessOwnerMock.Object);

            
        }

        [TestMethod]
        public void MoveNextCommandEnabledTest() {
            SetupApplicationCommandsAccessOwnerMock(true, true, true);
            CommandEnabledTest(Pitch.MoveNextCommand, true);

        }

        private void SetupApplicationMock()
        {
            var applicationMock = new PitchMock<IPitch>();
            ApplicationMock = applicationMock.Create(Pitch);
            SetupCommonPitchHostMock();

        }

        //private method of type void "AllowCommands()"
        //other private methods for props and so on
        //For 2 or more test methods for every command

        private void SetupCommonPitchHostMock() {
            var commonPitchHostMock = new CommonPitchHostMock<ICommonPitchHost>();
            CommonPitchHostMock = commonPitchHostMock.Create(CommonPitchHost);
            commonPitchHostMock.IsOnLine = true;
            commonPitchHostMock.IsRunning = true;
            commonPitchHostMock.IsInFocus = true;
        }

        private void SetupApplicationCommandsAccessOwnerMock(bool isInFocus, bool isRunning, bool isOnline) {
            CommandsAccessOwnerMock.Setup(o => o.IsInFocus).Returns(isInFocus);
            CommandsAccessOwnerMock.Setup(o => o.IsRunning).Returns(isRunning);
            CommandsAccessOwnerMock.Setup(o => o.IsOnLine).Returns(isOnline);
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
