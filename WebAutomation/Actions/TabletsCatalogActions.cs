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

    public void ChooseTabletById(string tabletId)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(e => e.FindElement(By.Id(tabletId)).Displayed);
        driver.FindElement(By.Id(tabletId)).Click();
    }
}