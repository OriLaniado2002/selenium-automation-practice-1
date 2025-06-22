using OpenQA.Selenium;

public class ComparisonActions
{
    private IWebDriver driver;

    public ComparisonActions(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void AreEqual(string actualString, string expectedString)
    {
        Assert.That(actualString, Is.EqualTo(expectedString));
    }

    public void AreNotEqual(string actualString, string expectedString)
    {
        Assert.That(actualString, Is.Not.EqualTo(expectedString));
    }
}