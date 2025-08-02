using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


public class BaseActions
{
    private IWebDriver driver;

    public BaseActions(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void NavigateBack(int numberOfBacks)
    {
        int baseIndex = 0;
        while (baseIndex < numberOfBacks)
        {
            driver.Navigate().Back();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            baseIndex++;
        }
    }

    public void JustWait()
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    public void AreEqual(string actualString, string expectedString)
    {
        Assert.That(actualString, Is.EqualTo(expectedString));
    }

    public void AreNotEqual(string actualString, string expectedString)
    {
        Assert.That(actualString, Is.Not.EqualTo(expectedString));
    }

    public void ExplicitWaitByXpath(string XPathVariable)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(e => e.FindElement(By.XPath(XPathVariable)).Displayed);
    }
}