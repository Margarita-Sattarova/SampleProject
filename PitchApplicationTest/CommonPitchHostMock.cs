using System;
using System.Collections.Generic;
using System.Text;
using Framework;
using Moq;
using PitchApplication;

namespace PitchApplicationTest {
    public class CommonPitchHostMock<T> where T : class, ICommonPitchHost {
        public Mock<T> Create(T host) {
            var commonPitchHostMock = new Mock<T>();
            SetupProperties(commonPitchHostMock);

            return commonPitchHostMock;
        }

        protected virtual void SetupProperties(Mock<T> commonPitchHostMock) {
            commonPitchHostMock.Setup(o => o.IsSkipNextMove).Returns(true);
            commonPitchHostMock.Setup(o => o.IsOnLine).Returns(true);
            commonPitchHostMock.Setup(o => o.IsInFocus).Returns(true);
            commonPitchHostMock.Setup(o => o.IsNextMove).Returns(true);
            commonPitchHostMock.Setup(o => o.IsPreviousMove).Returns(true);
            commonPitchHostMock.Setup(o => o.IsReturnToStart).Returns(true);
            commonPitchHostMock.Setup(o => o.IsRunning).Returns(true);
        }
    }
}
