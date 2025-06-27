using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

public class HomePage
{
    protected IWebDriver driver;
    private NavigationActions navigationActions;

    public HomePage(IWebDriver driver)
    {
        this.driver = driver;
        navigationActions = new NavigationActions(driver);

        navigationActions.JustWait();
    }

    IWebElement home => driver.FindElement(By.XPath("/html/body/header/nav/div/a/span[1]"));
    IWebElement headphones => driver.FindElement(By.Id("headphonesImg"));
    IWebElement tablets => driver.FindElement(By.Id("tabletsImg"));
    IWebElement mice => driver.FindElement(By.Id("miceImg"));
    IWebElement speakers => driver.FindElement(By.Id("speakersImg"));
    IWebElement laptops => driver.FindElement(By.Id("laptopsImg"));
    IWebElement menuCart => driver.FindElement(By.Id("menuCart"));


    public void HeadphonesCatalog() => headphones.Click();
    public void TabletsCatalog() => tablets.Click();
    public void MiceCatalog() => mice.Click();
    public void SpeakersCatalog() => speakers.Click();
    public void LaptopsCatalog() => laptops.Click();
    public void GoToCheckoutPage() => menuCart.Click();
    public void GoToHome() => home.Click();
    public void ShowCartItemWindow()
    {
        Actions actions = new Actions(driver);
        actions.MoveToElement(menuCart).Build().Perform();
    }

    public int FindTotalAboveCartIcon()
    {
        IWebElement numAboveCartIcon = driver.FindElement(By.XPath("//*[@id='shoppingCartLink']/span"));
        int totalNum = Convert.ToInt32(numAboveCartIcon.Text);
        return totalNum;
    }
}