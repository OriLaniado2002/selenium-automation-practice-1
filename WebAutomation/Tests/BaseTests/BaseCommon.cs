using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


public class BaseCommon
{
    protected IWebDriver driver;
    protected BaseActions baseActions;
    protected ProductPageActions productPageActions;
    protected CartWindowActions cartWindowActions;
    protected HeadphonesCatalogActions headphonesCatalogActions;
    protected HomePageActions homePageActions;
    protected LaptopsCatalogActions laptopsCatalogActions;
    protected MiceCatalogActions miceCatalogActions;
    protected SpeakersCatalogActions speakersCatalogActions;
    protected TabletsCatalogActions tabletsCatalogActions;
    protected CheckoutPageActions checkoutPageActions;


    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        driver = new ChromeDriver();
        baseActions = new BaseActions(driver);
        productPageActions = new ProductPageActions(driver);
        cartWindowActions = new CartWindowActions(driver);
        headphonesCatalogActions = new HeadphonesCatalogActions(driver);
        homePageActions = new HomePageActions(driver);
        laptopsCatalogActions = new LaptopsCatalogActions(driver);
        miceCatalogActions = new MiceCatalogActions(driver);
        speakersCatalogActions = new SpeakersCatalogActions(driver);
        tabletsCatalogActions = new TabletsCatalogActions(driver);
        checkoutPageActions = new CheckoutPageActions(driver);

        driver.Navigate().GoToUrl("https://www.advantageonlineshopping.com/#/");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Manage().Window.Maximize();

    }      
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        driver.Quit();
        driver.Dispose();
    }    
    

}