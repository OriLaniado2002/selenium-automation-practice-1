using OpenQA.Selenium.DevTools.V135.Debugger;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Runtime.CompilerServices;


[TestFixture]
[Description("Tests related to the cart window page")]
public class CartWindowTests : BaseCartWindow
{/*

    [Test]
    [Description("לאחר בחירה של לפחות שני מוצרים, בכמויות שונות, לבדוק שכמות המוצרים הסופית מופיעה נכון ומדוייקת בחלונית עגלת הקניות בצד ימין למעלה של המסך")]
    public void AddItemsInDifferentQuantitiesAndCheckOverallQuantity()
    {
        homePageActions.MiceCatalog();
        miceCatalogActions.ChooseMiceById("28");
        productPageActions.AddToCart(2);
        homePageActions.GoToHome();
        homePageActions.SpeakersCatalog();
        speakersCatalogActions.ChooseSpeakerWithById("24");
        productPageActions.AddToCart(1);

        int cartNumber = homePageActions.FindTotalAboveCartIcon();
        int expectedCartNumber = 3;
        Assert.That(expectedCartNumber, Is.EqualTo(cartNumber));

    }

    [Test]
    [Description("לאחר בחירה של 3 מוצרים, בכמויות שונות, יש בלדוק שהמוצרים מופיעים נכון: כולל שם, צבע, כמות ומחיר בחלונית עגלת הקניות בצד ימין למעלה של המסך")]
    public void VerifyDetailsForDifferentItemsInCartWindow()
    {
        homePageActions.HeadphonesCatalog();
        headphonesCatalogActions.ChooseHeadphoneById("15");
        productPageActions.AddToCart(1);
        baseActions.NavigateBack(1);
        headphonesCatalogActions.ChooseHeadphoneById("55");
        productPageActions.AddToCart(1);
        homePageActions.GoToHome();
        homePageActions.TabletsCatalog();
        tabletsCatalogActions.ChooseTabletById("18");
        productPageActions.AddToCart(1);
        homePageActions.ShowCartItemWindow();

        string firstProductName = cartWindowActions.GetProductName("//h3[text()='HP PRO TABLET 608 G1']");
        string firstProductColor = cartWindowActions.GetProductColor("//span[text()='BLACK']");
        string firstProductQuantity = cartWindowActions.GetProductQuantity("//label[text()='QTY: 1']");
        string firstProductPrice = cartWindowActions.GetProductPrice("//p[text()='$479.00']");
        baseActions.AreEqual(firstProductName, "HP PRO TABLET 608 G1");
        baseActions.AreEqual(firstProductColor, "BLACK");
        baseActions.AreEqual(firstProductQuantity, "QTY: 1");
        baseActions.AreEqual(firstProductPrice, "$479.00");

        string secondProductName = cartWindowActions.GetProductName("//h3[text()='GAME OF THRONES']");
        string secondProductColor = cartWindowActions.GetProductColor("//span[text()='PURPLE']");
        string secondProductQuantity = cartWindowActions.GetProductQuantity("//label[text()='QTY: 1']");
        string secondProductPrice = cartWindowActions.GetProductPrice("//p[text()='$10,000.00']");
        baseActions.AreEqual(secondProductName, "GAME OF THRONES");
        baseActions.AreEqual(secondProductColor, "PURPLE");
        baseActions.AreEqual(secondProductQuantity, "QTY: 1");
        baseActions.AreEqual(secondProductPrice, "$10,000.00");

        string thirdProductName = cartWindowActions.GetProductName("//h3[contains(text(),'BEATS STUDIO 2')]");
        string thirdProductColor = cartWindowActions.GetProductColor("//span[text()='BLACK']");
        string thirdProductQuantity = cartWindowActions.GetProductQuantity("//label[text()='QTY: 1']");
        string thirdProductPrice = cartWindowActions.GetProductPrice("//p[text()='$179.99']");
        baseActions.AreEqual(thirdProductName, "BEATS STUDIO 2 OVER-EAR MAT...");
        baseActions.AreEqual(thirdProductColor, "BLACK");
        baseActions.AreEqual(thirdProductQuantity, "QTY: 1");
        baseActions.AreEqual(thirdProductPrice, "$179.99");
    }

    [Test]
    [Description("לאחר בחירה של לפחות שני מוצרים והסרה של מוצר אחד על ידי שימוש בחלונית עגלת הקניות למעלה מימון, יש לבדוק שהמוצר אכן נעלם מחלונית העגלה")]
    public void RemoveAnItemFromCartAndVerifyItsRemoval()
    {
        laptopsCatalogActions.OpenLaptopsCatalog();
        laptopsCatalogActions.ChooseLaptopById("9");
        productPageActions.AddToCart(1);
        baseActions.NavigateBack(1);
        laptopsCatalogActions.ChooseLaptopById("10");
        productPageActions.AddToCart(1);
        homePageActions.ShowCartItemWindow();

        string itemToRemove = cartWindowActions.GetProductName("//h3[text()='HP CHROMEBOOK 14 G1(ES)']");
        string numberOfItemsInCart = cartWindowActions.FindTotalInCartWindow();
        cartWindowActions.ClickRemoveFromWindow();

        string expectedNumberOfItemsAfterX = "1 Item";
        baseActions.AreNotEqual(numberOfItemsInCart, expectedNumberOfItemsAfterX);
        string expectedTitleOfCartItem = cartWindowActions.GetProductName("//h3[contains(text(), 'HP CHROMEBOOK 14 G1')]");
        baseActions.AreNotEqual(expectedTitleOfCartItem, itemToRemove);
    }*/

}