using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V135.Browser;

public class CheckoutPage
{
    protected IWebDriver driver;
    protected BaseActions baseActions;

    public CheckoutPage(IWebDriver driver)
    {
        this.driver = driver;
        baseActions = new BaseActions(driver);
    }

    protected IWebElement pageTitle => driver.FindElement(By.XPath("//h3[contains(text(), 'SHOPPING CART')]"));
    protected string titleItemQuantity => driver.FindElement(By.XPath("//span[@ng-show='cart.productsInCart.length > 0']")).Text;
    protected IWebElement removeItemBtn => driver.FindElement(By.XPath("//a[text()='REMOVE']"));
    public IWebElement emptyCartText => driver.FindElement(By.XPath("//label[text()='Your shopping cart is empty']"));

    public string trimmedQuantity => titleItemQuantity.Trim('(', ')').Trim();
}