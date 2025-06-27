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

    protected IWebElement addQuantityBtn => driver.FindElement(By.XPath("//*[@id='productProperties']/div[2]/e-sec-plus-minus/div/div[1]"));
    protected IWebElement substractQuantityBtn => driver.FindElement(By.XPath("//*[@id='productProperties']/div[2]/e-sec-plus-minus/div/div[3]"));
    protected IWebElement addToCartBtn => driver.FindElement(By.Name("save_to_cart"));
    protected IWebElement topTitleProductName => driver.FindElement(By.XPath("/html/body//h1[text()=' GAME OF THRONES ']"));
    protected IWebElement topTitleProductPrice => driver.FindElement(By.XPath("//h2[contains(normalize-space(.), '$10,000.00')]"));


    public string GetTopTitleProductName() => topTitleProductName.Text;
    public string GetTopTitleProductPrice() => topTitleProductPrice.Text;

}