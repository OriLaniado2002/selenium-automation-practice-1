using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V135.Browser;

public class CartWindowPage
{
    protected IWebDriver driver;

    public CartWindowPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    protected IWebElement removeItemFromWindowBtn => driver.FindElement(By.XPath("//*[@id='product']/td[3]/div/div"));
    protected IWebElement totalOfItemsInWindow => driver.FindElement(By.XPath("//*[@id='toolTipCart']/div/table/tfoot/tr[1]/td[1]/span/label"));
    protected IWebElement checkOutBtn => driver.FindElement(By.Id("checkOutPopUp"));

    public bool IsCartWindowDisplayed()
    {
        if (checkOutBtn.Displayed)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}