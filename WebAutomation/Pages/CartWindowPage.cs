using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V135.Browser;

public class CartWindowPage
{
    protected IWebDriver driver;

    public CartWindowPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    IWebElement removeItemFromWindowBtn => driver.FindElement(By.XPath("//*[@id='product']/td[3]/div/div"));
    IWebElement totalOfItemsInWindow => driver.FindElement(By.XPath("//*[@id='toolTipCart']/div/table/tfoot/tr[1]/td[1]/span/label"));
    IWebElement checkOutBtn => driver.FindElement(By.Id("checkOutPopUp"));

    public void ClickRemoveFromWindow() => removeItemFromWindowBtn.Click();
    public string FindTotalInCartWindow() => totalOfItemsInWindow.Text;
    public void ClickCheckoutBtn() => checkOutBtn.Click();

}