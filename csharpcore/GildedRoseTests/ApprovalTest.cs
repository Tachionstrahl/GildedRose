using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using Xunit;

namespace GildedRoseTests;

[UseReporter(typeof(DiffReporter))]
[TestFixture]
public class ApprovalTest
{
    [Fact]
    public void ThirtyDays()
    {
        StringBuilder fakeOutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeOutput));
        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        TextTestFixture.Main(new string[] { });
        var output = fakeOutput.ToString();

        Approvals.Verify(output);
    }
}