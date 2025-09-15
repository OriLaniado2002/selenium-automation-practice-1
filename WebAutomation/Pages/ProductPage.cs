using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V135.Target;
using OpenQA.Selenium.Support.UI;

public class ProductPage
{
    private IWebDriver driver;
    private BaseActions baseActions;

    public ProductPage(IWebDriver driver)
    {
        this.driver = driver;
        baseActions = new BaseActions(driver);

        baseActions.JustWait();
    }

    protected IWebElement addQuantityBtn => driver.FindElement(By.XPath("//*[@id='productProperties']/div[2]/e-sec-plus-minus/div/div[1]"));
    protected IWebElement substractQuantityBtn => driver.FindElement(By.XPath("//*[@id='productProperties']/div[2]/e-sec-plus-minus/div/div[3]"));
    protected IWebElement addToCartBtn => driver.FindElement(By.Name("save_to_cart"));
    protected IWebElement topTitleProductName => driver.FindElement(By.XPath("/html/body//h1[text()=' GAME OF THRONES ']"));
    protected IWebElement topTitleProductPrice => driver.FindElement(By.XPath("//h2[contains(normalize-space(.), '$10,000.00')]"));

}