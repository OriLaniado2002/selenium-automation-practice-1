using OpenQA.Selenium;
using System;


public class ProductPageActions : ProductPage
{
    private IWebDriver driver;
    private ProductPage productPage;
    public ProductPageActions(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
        productPage = new ProductPage(driver);
    }

    public void AddQuantity() => addQuantityBtn.Click();
    public void SubtractQuantity() => substractQuantityBtn.Click();

    public string GetTopTitleProductName() => topTitleProductName.Text;
    public string GetTopTitleProductPrice() => topTitleProductPrice.Text;

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