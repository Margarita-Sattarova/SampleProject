using Moq;
using PitchApplicationTest;
using PitchUndergroundApplication;

namespace PitchUndergroundApplicationTest {
    public class PitchUndergroundMock<T> : PitchCommonMock<T> where T : class, IPitchUnderground {
        protected override void SetupCommands(Mock<T> applicationMock) {

        }
    }
}
