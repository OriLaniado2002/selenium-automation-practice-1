using OpenQA.Selenium;

public class HeadphonesCatalogPage
{
    private IWebDriver driver;

    public HeadphonesCatalogPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    protected IWebElement headphonesCatalogPageTitle => driver.FindElement(By.XPath("//h3[contains(@class, 'categoryTitle') and normalize-space(text())='HEADPHONES']"));

}