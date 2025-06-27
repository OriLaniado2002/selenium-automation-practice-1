using OpenQA.Selenium;

public class ComparisonActions
{
    public void AreEqual(string actualString, string expectedString)
    {
        Assert.That(actualString, Is.EqualTo(expectedString));
    }

    public void AreNotEqual(string actualString, string expectedString)
    {
        Assert.That(actualString, Is.Not.EqualTo(expectedString));
    }
}