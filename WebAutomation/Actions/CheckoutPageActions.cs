using OpenQA.Selenium;
using System;

public class CheckoutPageActions : CheckoutPage
{
    private CheckoutPage checkoutPage;
    private BaseActions baseActions;
    private CartWindowPage cartWindowPage;

    public CheckoutPageActions(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
        checkoutPage = new CheckoutPage(driver);
        baseActions = new BaseActions(driver);
        cartWindowPage = new CartWindowPage(driver);
    }


    public void ClickRemoveBtn() => removeItemBtn.Click();

    public void RemoveAllItems()
    {
        int itemsToRemove = Convert.ToInt32(trimmedQuantity);
        int baseIndex = 0;
    
        baseActions.SleepWait(5); // Consider replacing this with an explicit wait
    
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
}