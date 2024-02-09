using SeleniumBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit;

namespace seleniumBasic.Widgets
{
    public class Progressbar : TestBase
    {
        public Progressbar(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void ProgressbarV1() { }
        [Fact]
        public void ProgressbarV2() { }
    }
}
