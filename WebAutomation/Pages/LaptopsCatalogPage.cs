using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LaptopsCatalogPage
{
    private IWebDriver driver;
    private HomePage homePage;

    public LaptopsCatalogPage(IWebDriver driver)
    {
        this.driver = driver;
        homePage = new HomePage(driver);
    }

    public void OpenLaptopsCatalog() => homePage.LaptopsCatalog();

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