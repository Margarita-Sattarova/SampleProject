using Framework;
using Moq;
using PitchApplication;

namespace PitchApplicationTest {
    public class PitchCommonMock<T> where T : class, IPitchCommon {
        public Mock<T> Create(T application) {
            var applicationCommonMock = new Mock<T>();
            SetupCommands(applicationCommonMock);

            return applicationCommonMock;
        }

        protected virtual void SetupCommands(Mock<T> applicationMock)
        {
            applicationMock.Setup(o => o.MoveNextCommand).Returns(new Command());
            applicationMock.Setup(o => o.MovePreviousCommand).Returns(new Command());
            applicationMock.Setup(o => o.ReturnToStartCommand).Returns(new Command());
            applicationMock.Setup(o => o.SkipNextMoveCommand).Returns(new Command());
        }
    }
}
