using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class SpeakersCatalogPage
{
    private IWebDriver driver;
    private HomePageActions homePageActions;

    public SpeakersCatalogPage(IWebDriver driver)
    {
        this.driver = driver;
        homePageActions = new HomePageActions(driver);
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    protected IWebElement speakersCatalogHeaderTitle => driver.FindElement(By.XPath("//h1[normalize-space(text())='ENJOY PREMIUM SOUND']"));
    protected IWebElement speakersCatalogHeaderText => driver.FindElement(By.XPath("//h2[normalize-space(text())='Colorful style meets serious sound']"));
    protected IWebElement speakersCatalogHeaderSubtext => driver.FindElement(By.XPath("//h3[normalize-space(text())='HP S9500 Bluetooth Wireless Speaker | Starting at $200']"));

}