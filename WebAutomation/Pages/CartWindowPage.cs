using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V135.Browser;

public class CartWindowPage : HomePage
{
    protected IWebDriver driver;

    public CartWindowPage(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
    }

    

}