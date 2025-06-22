using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class SpeakerCatalogPage
{
    private IWebDriver driver;
    private HomePage homePage;

    public SpeakerCatalogPage(IWebDriver driver)
    {
        this.driver = driver;
        homePage = new HomePage(driver);
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void OpenSpeakersCatalog()
    {
        homePage.SpeakersCatalog();
    }

    public void ChooseSpeakerWithId24()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(e => e.FindElement(By.Id("24")));
        driver.FindElement(By.Id("24")).Click();
    }
}