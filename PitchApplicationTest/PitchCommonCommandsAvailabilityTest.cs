using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PitchApplication;
using System;

namespace PitchApplicationTest {
    [TestClass]
    public class PitchCommonCommandsAvailabilityTest {
        private Mock<IPitch> ApplicationMock;
        private IPitch Pitch;
        private Mock<IPitchCommandsAccessOwner> PitchCommandsAccessOwnerMock;
        private PitchCommandsAccess CommandsAccess;

        private Mock<ICommandsAvailability> CommandsAvailabilityMock;
        private PitchCommandsAvailability CommandsAvailability;

        private Mock<ICommonPitchHost> CommonPitchHostMock;
        private ICommonPitchHost CommonPitchHost;

        private Mock<IPitchHost> PitchHostMock;

        [TestInitialize]
        public void TestInitialize() {
            SetupApplicationMock();
            var pitchMovement = ApplicationMock.As<IPitchMovement>();
            pitchMovement.Setup(o => o.CanRun).Returns(true);
            pitchMovement.Setup(o => o.CanJump).Returns(true);
            CommandsAvailabilityMock = ApplicationMock.As<ICommandsAvailability>();

            PitchCommandsAccessOwnerMock = ApplicationMock.As<IPitchCommandsAccessOwner>();
            PitchCommandsAccessOwnerMock.Setup(o => o.CanJump).Returns(true);
            PitchCommandsAccessOwnerMock.Setup(o => o.CanRun).Returns(true);
            AllowCommands(true);
            PitchCommandsAccessOwnerMockSetupCommandsEnabledMethods(true);

            CommonPitchHostMock = ApplicationMock.As<ICommonPitchHost>();
            PitchHostMock = new Mock<IPitchHost>();
            PitchHostMock.Setup(o => o.CanMove).Returns(true);

            ApplicationMock.Setup(o => o.Host).Returns(PitchHostMock.Object);
            Pitch = ApplicationMock.Object;
            CommandsAvailability = new PitchCommandsAvailability(Pitch);
        }

        [TestMethod]
        public void MoveNextCommandAvailableTest() {
            //SetupApplicationCommandsAccessOwnerMock(true, true, true);
            //ApplicationMock.Setup(o => o.CanMove).Returns(false);
            CommandAvailableTest(Pitch.MoveNextCommand, true);
        }

        private void SetupApplicationMock()
        {
            var applicationMock = new PitchMock<IPitch>();
            ApplicationMock = applicationMock.Create(Pitch);
            ApplicationMock.Setup(o => o.CanMove).Returns(true); //command availability must depend on the setup of this field, but that actually never happens
            ApplicationMock.Setup(o => o.CanRun).Returns(true);
            ApplicationMock.Setup(o => o.CanJump).Returns(true);
            SetupCommonPitchHostMock(true, true, true);
        }

        private void SetupCommonPitchHostMock(bool isInFocus, bool isOnline, bool isRunning)
        {
            var commonPitchHostMock = new CommonPitchHostMock<ICommonPitchHost>();
            CommonPitchHostMock = commonPitchHostMock.Create(CommonPitchHost);
            CommonPitchHostMock.Setup(o => o.IsInFocus).Returns(isInFocus);
            CommonPitchHostMock.Setup(o => o.IsOnLine).Returns(isOnline);
            CommonPitchHostMock.Setup(o => o.IsRunning).Returns(isRunning);
        }

        private void AllowCommands(bool commandsAllowed)
        {
            PitchCommandsAccessOwnerMock.Setup(o => o.AllowCommands).Returns(commandsAllowed);
        }

        private void PitchCommandsAccessOwnerMockSetupCommandsEnabledMethods(bool commandsEnabled)
        {
            PitchCommandsAccessOwnerMock.Setup(o => o.EnabledMoveNextCommand()).Returns(commandsEnabled);
            PitchCommandsAccessOwnerMock.Setup(o => o.EnabledMovePreviousCommand()).Returns(commandsEnabled);
            PitchCommandsAccessOwnerMock.Setup(o => o.EnabledReturnToStartCommand()).Returns(commandsEnabled);
            PitchCommandsAccessOwnerMock.Setup(o => o.EnabledSkipNextMoveCommand()).Returns(commandsEnabled);
            PitchCommandsAccessOwnerMock.Setup(o => o.EnabledRunCommand()).Returns(commandsEnabled);
            PitchCommandsAccessOwnerMock.Setup(o => o.EnabledJumpCommand()).Returns(commandsEnabled);
        }

        private void CommandAvailableTest(ICommand command, bool available)
        {
            CommandAvailableTest(command, available, b => { }, true);
        }

        private void CommandAvailableTest(ICommand command, bool available, Action<bool> settingAvailableAction, bool settingAvailable)
        {
            settingAvailableAction?.Invoke(settingAvailable);
            CallRefreshCommandAvailability(available);
            Assert.AreEqual(available, command.Available);
        }

        private void CallRefreshCommandAvailability(bool available)
        {
            CommandsAvailability.InitializeCommandsAvailability();
        }
    }
}
