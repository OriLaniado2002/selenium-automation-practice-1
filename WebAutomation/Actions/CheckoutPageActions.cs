using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class CheckoutPageActions : CheckoutPage
{
    private CheckoutPage checkoutPage;
    private CartWindowPage cartWindowPage;

    public CheckoutPageActions(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
        checkoutPage = new CheckoutPage(driver);
        cartWindowPage = new CartWindowPage(driver);
    }

    public void ClickRemoveBtn() => removeItemBtn.Click();

    public void WaitForCartWindowToDisappear()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.Id("checkOutPopUp")));

    }

    public void RemoveAllItems()
    {
        int itemsToRemove = Convert.ToInt32(trimmedQuantity);
        int baseIndex = 0;

        WaitForCartWindowToDisappear();
    
           while (baseIndex < itemsToRemove)
        {
            if (checkoutPage.emptyCartText.Displayed)
            {
                Console.WriteLine("Cart is already empty.");
                break;
            }
            else
            {
                ClickRemoveBtn();
                baseIndex++;
            }
        }
    }

    public bool IsCheckoutPageDisplayed()
    {
        return pageTitle.Displayed;
    }
}