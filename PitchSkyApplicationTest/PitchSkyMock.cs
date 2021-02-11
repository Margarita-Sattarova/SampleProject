using Moq;
using PitchApplicationTest;
using PitchSkyApplication;

namespace PitchSkyApplicationTest {
    public class PitchSkyMock<T> : PitchCommonMock<T> where T : class, IPitchSky {
        protected override void SetupCommands(Mock<T> applicationMock) {

        }
    }
}
