using NUnit.Framework;
using OpenQA.Selenium;


public class BaseCheckoutPage : BaseCommon
{
    [SetUp]
    public void SetUp()
    {
        homePageActions.GoToHome();
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            //homePageActions.GoToCheckoutPage();
            checkoutPageActions.RemoveAllItems();
        }
        catch (Exception ex)
        {
            Console.WriteLine("TearDown error: " + ex.Message);
        }

    }
}