using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V135.Target;
using OpenQA.Selenium.Support.UI;

public class ProductPage
{
    private IWebDriver driver;
    private NavigationActions navigationActions;

    public ProductPage(IWebDriver driver)
    {
        this.driver = driver;
        navigationActions = new NavigationActions(driver);

        navigationActions.JustWait();
    }

    IWebElement addQuantityBtn => driver.FindElement(By.XPath("//*[@id='productProperties']/div[2]/e-sec-plus-minus/div/div[1]"));
    IWebElement substractQuantityBtn => driver.FindElement(By.XPath("//*[@id='productProperties']/div[2]/e-sec-plus-minus/div/div[3]"));
    IWebElement addToCartBtn => driver.FindElement(By.Name("save_to_cart"));

    public void AddQuantity()
    {
        addQuantityBtn.Click();
    }

    public void SubstractQuantity()
    {
        substractQuantityBtn.Click();
    }

    public void AddToCart(int numberOfAddsToCart)
    {
        int baseAddToCartIndex = 0;
        while (baseAddToCartIndex < numberOfAddsToCart)
        {
            addToCartBtn.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            baseAddToCartIndex++;
        }
    }
}