using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class HeadphonesCatalogPage
{
    private IWebDriver driver;
    private HomePage homePage;

    public HeadphonesCatalogPage(IWebDriver driver)
    {
        this.driver = driver;
        homePage = new HomePage(driver);
    }

    public void OpenHeadphonesCatalog()
    {
        homePage.HeadphonesCatalog();
    }

    public void ChooseHeadphone15()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(e => e.FindElement(By.Id("15")).Displayed);
        driver.FindElement(By.Id("15")).Click();
    }

    public void ChooseHeadphone55()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(e => e.FindElement(By.Id("55")).Displayed);
        driver.FindElement(By.Id("55")).Click();
    }
}