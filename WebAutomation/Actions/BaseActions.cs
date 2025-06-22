using OpenQA.Selenium;

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
}