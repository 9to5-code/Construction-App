using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignUp.Tests
{


public class StringTests
{
    [Fact]
    public void StringLength_ShouldBeCorrect()
    {
        Assert.Equal(5, "Hello".Length);
    }
}

}