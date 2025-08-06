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
}