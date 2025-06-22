using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V135.Debugger;
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


    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        homepage = new HomePage(driver);
        miceCatalogPage = new MiceCatalogPage(driver);
        productPage = new ProductPage(driver);
        baseActions = new BaseActions(driver);
        speakerCatalogPage = new SpeakerCatalogPage(driver);

        driver.Navigate().GoToUrl("https://www.advantageonlineshopping.com/#/");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Manage().Window.Maximize();
    }

    // 1. לאחר בחירה של לפחות שני מוצרים, בכמויות שונות, לבדוק שכמות המוצרים הסופית מופיעה נכון ומדוייקת בחלונית עגלת הקניות בצד ימין למעלה של המסך
    [Test]
    public void AddItemsInDifferentQuantitiesAndCheckOverallQuantity()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        homepage.MiceCatalog();
        miceCatalogPage.ChooseMiceWithId28();
        productPage.AddToCart(2);
        homepage.GoToHome();
        homepage.SpeakersCatalog();
        speakerCatalogPage.ChooseSpeakerWithId24();
        productPage.AddToCart(1);

        //driver.FindElement(By.Name("save_to_cart")).Click();

        string cartNumber = driver.FindElement(By.XPath("/html/body/header/nav/ul/li[2]/a/span")).Text;
        string expectedCartNumber = "3";

        Assert.That(expectedCartNumber, Is.EqualTo(cartNumber));

    }

    [TearDown]
    public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
}