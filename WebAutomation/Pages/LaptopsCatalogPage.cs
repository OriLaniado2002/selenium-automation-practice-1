using OpenQA.Selenium;

public class LaptopsCatalogPage
{
    private IWebDriver driver;

    public LaptopsCatalogPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    protected IWebElement laptopsCatalogHeaderTitle => driver.FindElement(By.XPath("//h1[normalize-space(text())='EXPLORE THE NEW DESIGN']"));
    protected IWebElement laptopsCatalogHeaderText => driver.FindElement(By.XPath("//h2[normalize-space(text())='Supremely thin, yet incredibly durable']"));
    protected IWebElement laptopsCatalogHeaderSubtext => driver.FindElement(By.XPath("//h3[normalize-space(.)='HP Pavilion 15z Touch Laptop | Starting at $650']"));
    protected IWebElement headerBuyNowBtn => driver.FindElement(By.Name("buy_now"));

}