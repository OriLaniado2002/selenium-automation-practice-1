using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class TabletsCatalogPage
{
    private IWebDriver driver;
    private HomePage homePage;

    public TabletsCatalogPage(IWebDriver driver)
    {
        this.driver = driver;
        homePage = new HomePage(driver);
    }

    public void OpenTabletsCatalog() => homePage.TabletsCatalog();

    public void ChooseTablet18()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(e => e.FindElement(By.Id("18")).Displayed);
        driver.FindElement(By.Id("18")).Click();
    }
}