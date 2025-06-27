using OpenQA.Selenium;
using System;


public class ProductActions : ProductPage
{
    private IWebDriver driver;
    private ProductPage productPage;
    public ProductActions(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
        productPage = new ProductPage(driver);
    }

    public void AddQuantity() => addQuantityBtn.Click();

    public void SubstractQuantity() => substractQuantityBtn.Click();

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