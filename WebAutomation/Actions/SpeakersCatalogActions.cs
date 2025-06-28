using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class SpeakersCatalogActions : SpeakersCatalogPage
{
    private IWebDriver driver;
    private SpeakersCatalogPage speakersCatalogPage;
    private HomePageActions homePageActions;

    public SpeakersCatalogActions(IWebDriver driver) : base (driver)
    {
        this.driver = driver;
        speakersCatalogPage = new SpeakersCatalogPage(driver);
        homePageActions = new HomePageActions(driver);
    }

    public void OpenSpeakersCatalog() => homePageActions.SpeakersCatalog();

    public void ChooseSpeakerWithById(string speakerId)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(e => e.FindElement(By.Id(speakerId)));
        driver.FindElement(By.Id(speakerId)).Click();
    }
}