using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V135.Network;
using OpenQA.Selenium.Support.UI;


public class MiceCatalogPage
{
    private IWebDriver driver;
    private HomePage homepage;

    public MiceCatalogPage(IWebDriver driver)
    {
        this.driver = driver;
        homepage = new HomePage(driver);
    }
    public void OpenMiceCatalog() => homepage.MiceCatalog();
    public void ChooseMiceWithId28()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        OpenMiceCatalog();
        wait.Until(e => e.FindElement(By.Id("28")));
        driver.FindElement(By.Id("28")).Click();
    }

}