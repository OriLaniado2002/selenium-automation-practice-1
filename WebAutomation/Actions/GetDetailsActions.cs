using OpenQA.Selenium;

public class GetDetailsActions
{
    private IWebDriver driver;

    public GetDetailsActions(IWebDriver driver)
    {
        this.driver = driver;
    }

    public string GetProductName(string XPathVariable)
    {
        string productName = driver.FindElement(By.XPath(XPathVariable)).Text;
        return productName;
    }

    public string GetProductColor(string XPathVariable)
    {
        string productColor = driver.FindElement(By.XPath(XPathVariable)).Text;
        return productColor;
    }

    public string GetProductQuantity(string XPathVariable)
    {
        string productQuantity = driver.FindElement(By.XPath(XPathVariable)).Text;
        return productQuantity;
    }

    public string GetProductPrice(string XPathVariable)
    {
        string productPrice = driver.FindElement(By.XPath(XPathVariable)).Text;
        return productPrice;
    }
}