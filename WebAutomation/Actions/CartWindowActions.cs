using OpenQA.Selenium;
using System;

public class CartWindowActions : CartWindowPage
{

    private CartWindowPage cartWindowPage;
    public CartWindowActions(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
        cartWindowPage = new CartWindowPage(driver);
    }

    public void ClickRemoveFromWindow() => removeItemFromWindowBtn.Click();
    public string FindTotalInCartWindow() => totalOfItemsInWindow.Text;
    public void ClickCheckoutBtn() => checkOutBtn.Click();

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