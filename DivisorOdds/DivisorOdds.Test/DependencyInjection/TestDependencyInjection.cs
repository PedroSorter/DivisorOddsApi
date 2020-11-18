using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DivisorOdds.Test.DependencyInjection
{
    public static class TestDependencyInjection
    {
        public static Mock<T> GetMock<T>(Mock[] mocks) where T : class
        {
            return mocks.Single(a => a is Mock<T>) as Mock<T>;
        }
    }
}
