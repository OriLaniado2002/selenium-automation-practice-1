using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

public class HomePage
{
    private IWebDriver driver;
    private BaseActions baseActions;

    public HomePage(IWebDriver driver)
    {
        this.driver = driver;
        baseActions = new BaseActions(driver);

        baseActions.JustWait();
    }

    protected IWebElement home => driver.FindElement(By.XPath("//span[text()='dvantage']"));
    protected IWebElement headphones => driver.FindElement(By.Id("headphonesImg"));
    protected IWebElement tablets => driver.FindElement(By.Id("tabletsImg"));
    protected IWebElement mice => driver.FindElement(By.Id("miceImg"));
    protected IWebElement speakers => driver.FindElement(By.Id("speakersImg"));
    protected IWebElement laptops => driver.FindElement(By.Id("laptopsImg"));
    protected IWebElement menuCart => driver.FindElement(By.Id("menuCart"));

}