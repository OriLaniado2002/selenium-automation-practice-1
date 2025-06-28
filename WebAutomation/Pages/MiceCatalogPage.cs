using OpenQA.Selenium;

public class MiceCatalogPage
{
    private IWebDriver driver;

    public MiceCatalogPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    protected IWebElement miceCatalogHeaderTitle => driver.FindElement(By.XPath("//h1[normalize-space(text())='DISCOVER OUR WIRELESS MICE']"));
    protected IWebElement miceCatalogHeaderText => driver.FindElement(By.XPath("//h2[normalize-space(text())='designed to work and ready to play']"));
    protected IWebElement miceCatalogHeaderSubtext => driver.FindElement(By.XPath("//h3[normalize-space(.)='HP Z3200 Wireless Mouse | Starting at $29.99']"));

}