using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class TabletsCatalogActions : TabletsCatalogPage
{
    private IWebDriver driver;
    private TabletsCatalogPage tabletsCatalogPage;
    private HomePageActions homePageActions;

    public TabletsCatalogActions(IWebDriver driver) : base (driver)
    {
        this.driver = driver;
        tabletsCatalogPage = new TabletsCatalogPage(driver);
        homePageActions = new HomePageActions(driver);
    }

    public void OpenTabletsCatalog() => homePageActions.TabletsCatalog();

    public void ChooseTablet18()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(e => e.FindElement(By.Id("18")).Displayed);
        driver.FindElement(By.Id("18")).Click();
    }
}