using NUnit.Framework;
using OpenQA.Selenium;


public class BaseCartWindow : BaseCommon
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
            checkoutPageActions.RemoveAllItems();
        }
        catch (Exception ex)
        {
            Console.WriteLine("TearDown error: " + ex.Message);
        }

    }
}