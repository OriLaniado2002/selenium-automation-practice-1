using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V135.Debugger;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Runtime.CompilerServices;


[TestFixture]
public class CartWindowTests
{
    private IWebDriver driver;
    private NavigationActions navigationActions;
    private ComparisonActions comparisonActions;
    private ProductPageActions productPageActions;
    private CartWindowActions cartWindowActions;
    private HeadphonesCatalogActions headphonesCatalogActions;
    private HomePageActions homePageActions;
    private LaptopsCatalogActions laptopsCatalogActions;
    private MiceCatalogActions miceCatalogActions;
    private SpeakersCatalogActions speakersCatalogActions;
    private TabletsCatalogActions tabletsCatalogActions;


    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        navigationActions = new NavigationActions(driver);
        comparisonActions = new ComparisonActions();
        productPageActions = new ProductPageActions(driver);
        cartWindowActions = new CartWindowActions(driver);
        headphonesCatalogActions = new HeadphonesCatalogActions(driver);
        homePageActions = new HomePageActions(driver);
        laptopsCatalogActions = new LaptopsCatalogActions(driver);
        miceCatalogActions = new MiceCatalogActions(driver);
        speakersCatalogActions = new SpeakersCatalogActions(driver);
        tabletsCatalogActions = new TabletsCatalogActions(driver);

        driver.Navigate().GoToUrl("https://www.advantageonlineshopping.com/#/");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Manage().Window.Maximize();
    }

    // 1. לאחר בחירה של לפחות שני מוצרים, בכמויות שונות, לבדוק שכמות המוצרים הסופית מופיעה נכון ומדוייקת בחלונית עגלת הקניות בצד ימין למעלה של המסך
    [Test]
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

    // 2. לאחר בחירה של 3 מוצרים, בכמויות שונות, יש בלדוק שהמוצרים מופיעים נכון: כולל שם, צבע, כמות ומחיר בחלונית עגלת הקניות בצד ימין למעלה של המסך
    [Test]
    public void VerifyDetailsForDifferentItemsInCartWindow()
    {
        homePageActions.HeadphonesCatalog();
        headphonesCatalogActions.ChooseHeadphoneById("15");
        productPageActions.AddToCart(1);
        navigationActions.NavigateBack(1);
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
        comparisonActions.AreEqual(firstProductName, "HP PRO TABLET 608 G1");
        comparisonActions.AreEqual(firstProductColor, "BLACK");
        comparisonActions.AreEqual(firstProductQuantity, "QTY: 1");
        comparisonActions.AreEqual(firstProductPrice, "$479.00");

        string secondProductName = cartWindowActions.GetProductName("//h3[text()='GAME OF THRONES']");
        string secondProductColor = cartWindowActions.GetProductColor("//span[text()='PURPLE']");
        string secondProductQuantity = cartWindowActions.GetProductQuantity("//label[text()='QTY: 1']");
        string secondProductPrice = cartWindowActions.GetProductPrice("//p[text()='$10,000.00']");
        comparisonActions.AreEqual(secondProductName, "GAME OF THRONES");
        comparisonActions.AreEqual(secondProductColor, "PURPLE");
        comparisonActions.AreEqual(secondProductQuantity, "QTY: 1");
        comparisonActions.AreEqual(secondProductPrice, "$10,000.00");

        string thirdProductName = cartWindowActions.GetProductName("//h3[contains(text(),'BEATS STUDIO 2')]");
        string thirdProductColor = cartWindowActions.GetProductColor("//span[text()='BLACK']");
        string thirdProductQuantity = cartWindowActions.GetProductQuantity("//label[text()='QTY: 1']");
        string thirdProductPrice = cartWindowActions.GetProductPrice("//p[text()='$179.99']");
        comparisonActions.AreEqual(thirdProductName, "BEATS STUDIO 2 OVER-EAR MAT...");
        comparisonActions.AreEqual(thirdProductColor, "BLACK");
        comparisonActions.AreEqual(thirdProductQuantity, "QTY: 1");
        comparisonActions.AreEqual(thirdProductPrice, "$179.99");
    }

    // 3. לאחר בחירה של לפחות שני מוצרים והסרה של מוצר אחד ע"י שימוש בחלונית עגלת הקניות למעלה מימון, יש לבדוק שהמוצר אכן נעלם מחלונית העגלה
    [Test]
    public void RemoveAnItemFromCartAndVerifyItsRemoval()
    {
        laptopsCatalogActions.OpenLaptopsCatalog();
        laptopsCatalogActions.ChooseLaptopById("9");
        productPageActions.AddToCart(1);
        navigationActions.NavigateBack(1);
        laptopsCatalogActions.ChooseLaptopById("10");
        productPageActions.AddToCart(1);
        homePageActions.ShowCartItemWindow();

        string itemToRemove = cartWindowActions.GetProductName("//h3[text()='HP CHROMEBOOK 14 G1(ES)']");
        string numberOfItemsInCart = cartWindowActions.FindTotalInCartWindow();
        cartWindowActions.ClickRemoveFromWindow();

        string expectedNumberOfItemsAfterX = "1 Item";
        comparisonActions.AreNotEqual(numberOfItemsInCart, expectedNumberOfItemsAfterX);
        string expectedTitleOfCartItem = cartWindowActions.GetProductName("//h3[contains(text(), 'HP CHROMEBOOK 14 G1')]");
        comparisonActions.AreNotEqual(expectedTitleOfCartItem, itemToRemove);
    }

    [TearDown]
    public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
}