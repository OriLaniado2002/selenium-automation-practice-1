using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V135.Debugger;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;


[TestFixture]
public class CartWindowTests
{
    private IWebDriver driver;
    private HomePage homepage;
    private MiceCatalogPage miceCatalogPage;
    private ProductPage productPage;
    private BaseActions baseActions;
    private SpeakerCatalogPage speakerCatalogPage;
    private HeadphonesCatalogPage headphonesCatalogPage;
    private TabletsCatalogPage tabletCatalogPage;


    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        homepage = new HomePage(driver);
        miceCatalogPage = new MiceCatalogPage(driver);
        productPage = new ProductPage(driver);
        baseActions = new BaseActions(driver);
        speakerCatalogPage = new SpeakerCatalogPage(driver);
        headphonesCatalogPage = new HeadphonesCatalogPage(driver);
        tabletCatalogPage = new TabletsCatalogPage(driver);

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
        baseActions.NavigateBack(1);
        headphonesCatalogPage.ChooseHeadphone124();
        productPage.AddToCart(1);
        homepage.GoToHome();
        homepage.TabletsCatalog();
        tabletCatalogPage.ChooseTablet18();
        productPage.AddToCart(1);
        homepage.ShowCartItemWindow();

        string firstProductName = productPage.GetProductName("//h3[text()='HP PRO TABLET 608 G1']");
        string firstProductColor = productPage.GetProductColor("//span[text()='BLACK']");
        string firstProductQuantity = productPage.GetProductQuantity("//label[text()='QTY: 1']");
        string firstProductPrice = productPage.GetProductPrice("//p[text()='$479.00']");
        baseActions.AssertEqual(firstProductName, "HP PRO TABLET 608 G1");
        baseActions.AssertEqual(firstProductColor, "BLACK");
        baseActions.AssertEqual(firstProductQuantity, "QTY: 1");
        baseActions.AssertEqual(firstProductPrice, "$479.00");

        string secondProductName = productPage.GetProductName("//h3[text()='GAME OF THRONES']");
        string secondProductColor = productPage.GetProductColor("//span[text()='PURPLE']");
        string secondProductQuantity = productPage.GetProductQuantity("//label[text()='QTY: 1']");
        string secondProductPrice = productPage.GetProductPrice("//p[text()='$10,000.00']");
        baseActions.AssertEqual(secondProductName, "GAME OF THRONES");
        baseActions.AssertEqual(secondProductColor, "PURPLE");
        baseActions.AssertEqual(secondProductQuantity, "QTY: 1");
        baseActions.AssertEqual(secondProductPrice, "$10,000.00");

        string thirdProductName = productPage.GetProductName("//h3[contains(text(),'BEATS STUDIO 2')]");
        string thirdProductColor = productPage.GetProductColor("//span[text()='BLACK']");
        string thirdProductQuantity = productPage.GetProductQuantity("//label[text()='QTY: 1']");
        string thirdProductPrice = productPage.GetProductPrice("//p[text()='$179.99']");
        baseActions.AssertEqual(thirdProductName, "BEATS STUDIO 2 OVER-EAR MAT...");
        baseActions.AssertEqual(thirdProductColor, "BLACK");
        baseActions.AssertEqual(thirdProductQuantity, "QTY: 1");
        baseActions.AssertEqual(thirdProductPrice, "$179.99");
    }

    [TearDown]
    public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
}