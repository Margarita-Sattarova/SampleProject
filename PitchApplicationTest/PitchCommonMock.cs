using Moq;
using PitchApplication;

namespace PitchApplicationTest {
    public class PitchCommonMock<T> where T : class, IPitchCommon {
        public Mock<T> Create(T application) {
            var applicationCommonMock = new Mock<T>();
            SetupCommands(applicationCommonMock, application);

            return applicationCommonMock;
        }

        protected virtual void SetupCommands(Mock<T> applicationMock, T application) {

        }
    }
}
