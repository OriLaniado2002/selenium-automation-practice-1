using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;


public class HomePageActions : HomePage
{
    private IWebDriver driver;
    private HomePage homePage;

    public HomePageActions(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
        homePage = new HomePage(driver);
    }

    public void HeadphonesCatalog() => headphones.Click();
    public void TabletsCatalog() => tablets.Click();
    public void MiceCatalog()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementToBeClickable(mice));
        mice.Click();
    }
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