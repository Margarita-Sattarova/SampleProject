using System;
using System.Collections.Generic;
using System.Text;
using Framework;
using Moq;
using PitchApplication;

namespace PitchApplicationTest {
    public class CommonPitchHostMock<T> where T : class, ICommonPitchHost
    {
        public bool IsSkipNextMove { get; set; } = true;
        public bool IsOnLine { get; set; } = true;
        public bool IsInFocus { get; set; } = true;
        public bool IsNextMove { get; set; } = true;
        public bool IsPreviousMove { get; set; } = true;
        public bool IsReturnToStart { get; set; } = true;
        public bool IsRunning { get; set; } = true;

        public Mock<T> Create(T host) {
            var commonPitchHostMock = new Mock<T>();
            SetupProperties(commonPitchHostMock);

            return commonPitchHostMock;
        }

        protected virtual void SetupProperties(Mock<T> commonPitchHostMock) {
            commonPitchHostMock.Setup(o => o.IsSkipNextMove).Returns(IsSkipNextMove);
            commonPitchHostMock.Setup(o => o.IsOnLine).Returns(IsOnLine);
            commonPitchHostMock.Setup(o => o.IsInFocus).Returns(IsInFocus);
            commonPitchHostMock.Setup(o => o.IsNextMove).Returns(IsNextMove);
            commonPitchHostMock.Setup(o => o.IsPreviousMove).Returns(IsPreviousMove);
            commonPitchHostMock.Setup(o => o.IsReturnToStart).Returns(IsReturnToStart);
            commonPitchHostMock.Setup(o => o.IsRunning).Returns(IsRunning);
        }
    }
}
