using NUnit.Framework;
using System.Collections;

namespace ShopLife.Shared.Tests;

[TestFixture]
public class ExampleTests
{
    public ExampleTests()
    {

    }

    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    [TestCaseSource(typeof(MyDataClass), nameof(MyDataClass.AddTestCases))]
    public void AddTest(int? input, int expected)
    {
        //Arrange
        input ??= 0;

        //Act
        int actual = input.Value + 1;

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestCaseSource(typeof(MyDataClass), nameof(MyDataClass.DivideTestCases))]
    public int DivideTest(int n, int d)
    {
        return n / d;
    }
}

public class MyDataClass
{
    public static IEnumerable AddTestCases
    {
        get
        {
            yield return new TestCaseData(null, 1);
            yield return new TestCaseData(1, 2);
            yield return new TestCaseData(5, 6);
        }
    }

    public static IEnumerable DivideTestCases
    {
        get
        {
            yield return new TestCaseData(12, 3).Returns(4);
            yield return new TestCaseData(12, 2).Returns(6);
            yield return new TestCaseData(12, 4).Returns(3);
        }
    }
}