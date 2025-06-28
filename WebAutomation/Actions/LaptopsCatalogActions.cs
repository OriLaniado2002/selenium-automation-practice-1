using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LaptopsCatalogActions : LaptopsCatalogPage
{
    private IWebDriver driver;
    private LaptopsCatalogPage laptopsCatalogPage;
    private HomePageActions homePageActions;

    public LaptopsCatalogActions(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
        laptopsCatalogPage = new LaptopsCatalogPage(driver);
        homePageActions = new HomePageActions(driver);
    }

    public void OpenLaptopsCatalog() => homePageActions.LaptopsCatalog();

    public void ChooseLaptop9()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(e => e.FindElement(By.Id("9")).Displayed);
        driver.FindElement(By.Id("9")).Click();
    }

    public void ChooseLaptop10()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(e => e.FindElement(By.Id("10")).Displayed);
        driver.FindElement(By.Id("10")).Click();
    }
}