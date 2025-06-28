using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;


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
        for (int i = 0; i < numberOfAddsToCart; i++)
        {
            WebDriverWait wait = new WebDriverWait (driver, TimeSpan.FromSeconds(10));

            wait.Until(e => e.FindElement(By.Name("save_to_cart")).Displayed);
            addToCartBtn.Click();
        }
    }

}