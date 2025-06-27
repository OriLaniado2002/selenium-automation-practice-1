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
    private HomePage homepage;
    private MiceCatalogPage miceCatalogPage;
    private ProductPage productPage;
    private GetDetailsActions getDetailsActions;
    private SpeakerCatalogPage speakerCatalogPage;
    private HeadphonesCatalogPage headphonesCatalogPage;
    private TabletsCatalogPage tabletCatalogPage;
    private LaptopsCatalogPage laptopsCatalogPage;
    private CartWindowPage cartWindowPage;
    private NavigationActions navigationActions;
    private ComparisonActions comparisonActions;


    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        homepage = new HomePage(driver);
        miceCatalogPage = new MiceCatalogPage(driver);
        productPage = new ProductPage(driver);
        getDetailsActions = new GetDetailsActions(driver);
        speakerCatalogPage = new SpeakerCatalogPage(driver);
        headphonesCatalogPage = new HeadphonesCatalogPage(driver);
        tabletCatalogPage = new TabletsCatalogPage(driver);
        laptopsCatalogPage = new LaptopsCatalogPage(driver);
        cartWindowPage = new CartWindowPage(driver);
        navigationActions = new NavigationActions(driver);
        comparisonActions = new ComparisonActions(driver);

        driver.Navigate().GoToUrl("https://www.advantageonlineshopping.com/#/");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Manage().Window.Maximize();
    }

    // 1. לאחר בחירה של לפחות שני מוצרים, בכמויות שונות, לבדוק שכמות המוצרים הסופית מופיעה נכון ומדוייקת בחלונית עגלת הקניות בצד ימין למעלה של המסך
    [Test]
    public void AddItemsInDifferentQuantitiesAndCheckOverallQuantity()
    {
        homepage.MiceCatalog();
        miceCatalogPage.ChooseMiceWithId28();
        productPage.AddToCart(2);
        homepage.GoToHome();
        homepage.SpeakersCatalog();
        speakerCatalogPage.ChooseSpeakerWithId24();
        productPage.AddToCart(1);

        int cartNumber = homepage.FindTotalAboveCartIcon();
        int expectedCartNumber = 3;
        Assert.That(expectedCartNumber, Is.EqualTo(cartNumber));

    }

    // 2. לאחר בחירה של 3 מוצרים, בכמויות שונות, יש בלדוק שהמוצרים מופיעים נכון: כולל שם, צבע, כמות ומחיר בחלונית עגלת הקניות בצד ימין למעלה של המסך
    [Test]
    public void VerifyDetailsForDifferentItemsInCartWindow()
    {
        homepage.HeadphonesCatalog();
        headphonesCatalogPage.ChooseHeadphone15();
        productPage.AddToCart(1);
        navigationActions.NavigateBack(1);
        headphonesCatalogPage.ChooseHeadphone55();
        productPage.AddToCart(1);
        homepage.GoToHome();
        homepage.TabletsCatalog();
        tabletCatalogPage.ChooseTablet18();
        productPage.AddToCart(1);
        homepage.ShowCartItemWindow();

        string firstProductName = getDetailsActions.GetProductName("//h3[text()='HP PRO TABLET 608 G1']");
        string firstProductColor = getDetailsActions.GetProductColor("//span[text()='BLACK']");
        string firstProductQuantity = getDetailsActions.GetProductQuantity("//label[text()='QTY: 1']");
        string firstProductPrice = getDetailsActions.GetProductPrice("//p[text()='$479.00']");
        comparisonActions.AreEqual(firstProductName, "HP PRO TABLET 608 G1");
        comparisonActions.AreEqual(firstProductColor, "BLACK");
        comparisonActions.AreEqual(firstProductQuantity, "QTY: 1");
        comparisonActions.AreEqual(firstProductPrice, "$479.00");

        string secondProductName = getDetailsActions.GetProductName("//h3[text()='GAME OF THRONES']");
        string secondProductColor = getDetailsActions.GetProductColor("//span[text()='PURPLE']");
        string secondProductQuantity = getDetailsActions.GetProductQuantity("//label[text()='QTY: 1']");
        string secondProductPrice = getDetailsActions.GetProductPrice("//p[text()='$10,000.00']");
        comparisonActions.AreEqual(secondProductName, "GAME OF THRONES");
        comparisonActions.AreEqual(secondProductColor, "PURPLE");
        comparisonActions.AreEqual(secondProductQuantity, "QTY: 1");
        comparisonActions.AreEqual(secondProductPrice, "$10,000.00");

        string thirdProductName = getDetailsActions.GetProductName("//h3[contains(text(),'BEATS STUDIO 2')]");
        string thirdProductColor = getDetailsActions.GetProductColor("//span[text()='BLACK']");
        string thirdProductQuantity = getDetailsActions.GetProductQuantity("//label[text()='QTY: 1']");
        string thirdProductPrice = getDetailsActions.GetProductPrice("//p[text()='$179.99']");
        comparisonActions.AreEqual(thirdProductName, "BEATS STUDIO 2 OVER-EAR MAT...");
        comparisonActions.AreEqual(thirdProductColor, "BLACK");
        comparisonActions.AreEqual(thirdProductQuantity, "QTY: 1");
        comparisonActions.AreEqual(thirdProductPrice, "$179.99");
    }

    // 3. לאחר בחירה של לפחות שני מוצרים והסרה של מוצר אחד ע"י שימוש בחלונית עגלת הקניות למעלה מימון, יש לבדוק שהמוצר אכן נעלם מחלונית העגלה
    [Test]
    public void RemoveAnItemFromCartAndVerifyItsRemoval()
    {
        laptopsCatalogPage.OpenLaptopsCatalog();
        laptopsCatalogPage.ChooseLaptop9();
        productPage.AddToCart(1);
        navigationActions.NavigateBack(1);
        laptopsCatalogPage.ChooseLaptop10();
        productPage.AddToCart(1);
        homepage.ShowCartItemWindow();

        string itemToRemove = getDetailsActions.GetProductName("//h3[text()='HP CHROMEBOOK 14 G1(ES)']");
        string numberOfItemsInCart = cartWindowPage.FindTotalInCartWindow();
        cartWindowPage.ClickRemoveFromWindow();

        string expectedNumberOfItemsAfterX = "1 Item";
        comparisonActions.AreNotEqual(numberOfItemsInCart, expectedNumberOfItemsAfterX);
        string expectedTitleOfCartItem = getDetailsActions.GetProductName("//h3[contains(text(), 'HP CHROMEBOOK 14 G1')]");
        comparisonActions.AreNotEqual(expectedTitleOfCartItem, itemToRemove);
    }

    [TearDown]
    public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
}