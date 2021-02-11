using System;
using System.Collections.Generic;
using System.Text;
using Framework;
using Moq;
using PitchApplication;

namespace PitchApplicationTest {
    public class PitchMock<T> : PitchCommonMock<T> where T : class, IPitch {
        protected override void SetupCommands(Mock<T> applicationMock) {
            base.SetupCommands(applicationMock);
            applicationMock.Setup(o => o.JumpCommand).Returns(new Command());
            applicationMock.Setup(o => o.RunCommand).Returns(new Command());
        }
    }
}
