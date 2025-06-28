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

    protected IWebElement home => driver.FindElement(By.XPath("/html/body/header/nav/div/a/span[1]"));
    protected IWebElement headphones => driver.FindElement(By.Id("headphonesImg"));
    protected IWebElement tablets => driver.FindElement(By.Id("tabletsImg"));
    protected IWebElement mice => driver.FindElement(By.Id("miceImg"));
    protected IWebElement speakers => driver.FindElement(By.Id("speakersImg"));
    protected IWebElement laptops => driver.FindElement(By.Id("laptopsImg"));
    protected IWebElement menuCart => driver.FindElement(By.Id("menuCart"));

}