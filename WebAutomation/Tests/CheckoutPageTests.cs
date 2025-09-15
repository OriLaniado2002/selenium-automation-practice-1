[TestFixture]
[Description("Tests related to the checkout page")]
public class CheckoutPageTests : BaseCheckoutPage
{
    [Test]
    [Description("4. לאחר בחירה של מוצר כלשהו ומעבר למסך עגלת הקניות על ידי לחיצה על לחצן עגלת הקניות בצד ימין למעלה, יש לוודא מעבר לעמוד עגלת הקניות")]
    public void ValidateCheckoutPageNavigationAfterAddingAProduct()
    {
        homePageActions.MiceCatalog();
        miceCatalogActions.ChooseMiceById("29");
        productPageActions.AddToCart(1);
        homePageActions.GoToCheckoutPage();
        checkoutPageActions.IsCheckoutPageDisplayed();
    }

    [Test]
    [Description("5. לאחר בחירה של 3 מוצרים בכמויות שונות ומעבר לעמוד עגלת הקניות, יש לבדוק שהסכום הכולל של ההזמנה תואם את מחירי המוצרים והכמויות שהוזמנו, על פי סיכום המחירים שהופיעו בעת בחירת המוצרים. בטסט זה, יש להדפיס בצורה ברורה עבור כל מוצר בעגלת הקניות: את שם המוצר, כמות ומחיר שלו")]
    public void AddThreeItemsAndValidateTotalPriceInCheckoutPage()
    {
        homePageActions.MiceCatalog();
        miceCatalogActions.ChooseMiceById("29");
        double firstProductSingularPrice = productPageActions.ReturnProductPriceAsDouble();
        string firstProductSingularPriceSTR = productPageActions.ReturnProductPriceAsString();
        productPageActions.AddToCart(1);
        baseActions.NavigateBack(1);

        miceCatalogActions.ChooseMiceById("28");
        double secondProductSingularPrice = productPageActions.ReturnProductPriceAsDouble();
        string secondProductSingularPriceSTR = productPageActions.ReturnProductPriceAsString();
        productPageActions.AddToCart(2);
        baseActions.NavigateBack(1);

        miceCatalogActions.ChooseMiceById("27");
        double thirdProductSingularPrice = productPageActions.ReturnProductPriceAsDouble();
        string thirdProductSingularPriceSTR = productPageActions.ReturnProductPriceAsString();
        productPageActions.AddToCart(3);
        homePageActions.GoToCheckoutPage();
        checkoutPageActions.WaitForCartWindowToDisappear();

        Dictionary <string , string> firstProductDictionary = new Dictionary <string , string>
        {
            {"Name: " , cartWindowActions.GetProductName("//label[text()='HP USB 3 BUTTON OPTICAL MOUSE']")},
            {"Quantity: " , cartWindowActions.GetProductQuantity("(//label[@class='ng-binding'])[1]")},
            {"Price: " , firstProductSingularPriceSTR}
        };

        Dictionary <string , string> secondProductDictionary = new Dictionary <string , string>
        {
            {"Name: " , cartWindowActions.GetProductName("//label[text()='HP Z3200 WIRELESS MOUSE']")},
            {"Quantity: " , cartWindowActions.GetProductQuantity("//label[@class='ng-binding' and text()='2']")},
            {"Price: " , secondProductSingularPriceSTR}
        };

        Dictionary <string , string> thirdProductDictionary = new Dictionary <string , string>
        {
            {"Name: " , cartWindowActions.GetProductName("//label[text()='HP USB 3 BUTTON OPTICAL MOUSE']")},
            {"Quantity: " , cartWindowActions.GetProductQuantity("(//label[@class='ng-binding'])[1]")},
            {"Price: " , thirdProductSingularPriceSTR}
        };

        Console.WriteLine("First products details- ");
        foreach (var kvp in firstProductDictionary)
        {
            Console.WriteLine($"{kvp.Key} {kvp.Value}");
        }

        Console.WriteLine("Second products details- ");
        foreach (var kvp in secondProductDictionary)
        {
            Console.WriteLine($"{kvp.Key} {kvp.Value}");
        }

        Console.WriteLine("Third products details- ");
        foreach (var kvp in thirdProductDictionary)
        {
            Console.WriteLine($"{kvp.Key} {kvp.Value}");
        }

        double expectedCheckoutPageTotalPrice = ((firstProductSingularPrice) + (secondProductSingularPrice * 2) + (thirdProductSingularPrice * 3));
        double actualCheckoutPageTotalPrice = checkoutPageActions.ReturnCheckoutPageTotalPriceAsDouble();
        baseActions.IsDoubleEqual(expectedCheckoutPageTotalPrice, actualCheckoutPageTotalPrice);
    }
}