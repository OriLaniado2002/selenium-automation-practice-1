using OpenQA.Selenium;

public class TabletsCatalogPage
{
    private IWebDriver driver;

    public TabletsCatalogPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    protected IWebElement tabletsCatalogHeaderTitle => driver.FindElement(By.XPath("//h1[normalize-space(text())='TRAVEL CONFIDENTLY AND IN STYLE']"));
    protected IWebElement tabletsCatalogHeaderText => driver.FindElement(By.XPath("//h2[normalize-space(text())='Built for durability and mobility']"));
    protected IWebElement tabletsCatalogHeaderSubtext => driver.FindElement(By.XPath("//h3[normalize-space(text())='HP ElitePad 1000 G2 Tablet | Starting at $1429']"));

}