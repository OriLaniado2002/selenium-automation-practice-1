using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Reflection.PortableExecutable;
using OpenQA.Selenium.BiDi.Modules.Session;


namespace WebAutomation.tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.advantageonlineshopping.com/#/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        // 1. לאחר בחירה של לפחות שני מוצרים, בכמויות שונות, לבדוק שכמות המוצרים הסופית מופיעה נכון ומדוייקת בחלונית עגלת הקניות בצד ימין למעלה של המסך
        [Test]
        public void Test1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.FindElement(By.Id("miceImg")).Click();
            wait.Until(e => e.FindElement(By.Id("28")).Displayed);
            driver.FindElement(By.Id("28")).Click();
            wait.Until(e => e.FindElement(By.Name("save_to_cart")).Displayed);
            driver.FindElement(By.Name("save_to_cart")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.Name("save_to_cart")).Click();
            driver.Navigate().Back();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Navigate().Back();
            driver.FindElement(By.Id("speakersImg")).Click();
            driver.FindElement(By.Id("24")).Click();
            driver.FindElement(By.Name("save_to_cart")).Click();
            string cartNumber = driver.FindElement(By.XPath("/html/body/header/nav/ul/li[2]/a/span")).Text;
            string expectedCartNumber = "3";
            
            Assert.That(expectedCartNumber, Is.EqualTo(cartNumber));

        }

        // 2. לאחר בחירה של 3 מוצרים, בכמויות שונות, יש בלדוק שהמוצרים מופיעים נכון: כולל שם, צבע, כמות ומחיר בחלונית עגלת הקניות בצד ימין למעלה של המסך
        [Test]
        public void Test2()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement cartIcon = driver.FindElement(By.Id("menuCart"));

            driver.FindElement(By.Id("headphonesImg")).Click();
            wait.Until(e => e.FindElement(By.Id("15")).Displayed);
            driver.FindElement(By.Id("15")).Click();
            wait.Until(e => e.FindElement(By.Name("save_to_cart")).Displayed);
            driver.FindElement(By.Name("save_to_cart")).Click();
            driver.Navigate().Back();

            driver.FindElement(By.Id("124")).Click();
            wait.Until(e => e.FindElement(By.Name("save_to_cart")).Displayed);
            driver.FindElement(By.Name("save_to_cart")).Click();
            driver.Navigate().Back();
            driver.Navigate().Back();

            driver.FindElement(By.Id("tabletsImg")).Click();
            wait.Until(e => e.FindElement(By.Id("18")).Displayed);
            driver.FindElement(By.Id("18")).Click();
            wait.Until(e => e.FindElement(By.Name("save_to_cart")).Displayed);
            driver.FindElement(By.Name("save_to_cart")).Click();

            Actions actions = new Actions(driver);
            actions.MoveToElement(cartIcon).Build().Perform();

            string firstProductName = driver.FindElement(By.XPath("//h3[text()='HP PRO TABLET 608 G1']")).Text;
            string firstProductColor = driver.FindElement(By.XPath("//span[text()='BLACK']")).Text;
            string firstProductQuantity = driver.FindElement(By.XPath("//label[text()='QTY: 1']")).Text;
            string firstProductPrice = driver.FindElement(By.XPath("//p[text()='$479.00']")).Text;
            string _firstProductExpectedName = "HP PRO TABLET 608 G1";
            string _firstProductExpectedColor = "BLACK";
            string _firstProductExpectedQuantity = "QTY: 1";
            string _firstProductExpectedPrice = "$479.00";

            Assert.That(firstProductName , Is.EqualTo(_firstProductExpectedName));
            Assert.That(firstProductColor , Is.EqualTo(_firstProductExpectedColor));
            Assert.That(firstProductQuantity , Is.EqualTo(_firstProductExpectedQuantity));
            Assert.That(firstProductPrice , Is.EqualTo(_firstProductExpectedPrice));


            string secondProductName = driver.FindElement(By.XPath("//h3[text()='GAME OF THRONES']")).Text;
            string secondProductColor = driver.FindElement(By.XPath("//span[text()='PURPLE']")).Text;
            string secondProductQuantity = driver.FindElement(By.XPath("//label[text()='QTY: 1']")).Text;
            string secondProductPrice = driver.FindElement(By.XPath("//p[text()='$10,000.00']")).Text;
            string _secondProductExpectedName = "GAME OF THRONES";
            string _secondProductExpectedColor = "PURPLE";
            string _secondProductExpectedQuantity = "QTY: 1";
            string _secondProductExpectedPrice = "$10,000.00";

            Assert.That(secondProductName , Is.EqualTo(_secondProductExpectedName));
            Assert.That(secondProductColor , Is.EqualTo(_secondProductExpectedColor));
            Assert.That(secondProductQuantity , Is.EqualTo(_secondProductExpectedQuantity));
            Assert.That(secondProductPrice , Is.EqualTo(_secondProductExpectedPrice));



            string thirdProductName = driver.FindElement(By.XPath("//h3[contains(text(),'BEATS STUDIO 2')]")).Text;
            string thirdProductColor = driver.FindElement(By.XPath("//span[text()='BLACK']")).Text;
            string thirdProductQuantity = driver.FindElement(By.XPath("//label[text()='QTY: 1']")).Text;
            string thirdProductPrice = driver.FindElement(By.XPath("//p[text()='$179.99']")).Text;
            string _thirdProductExpectedName = "BEATS STUDIO 2 OVER-EAR MAT...";
            string _thirdProductExpectedColor = "BLACK";
            string _thirdProductExpectedQuantity = "QTY: 1";
            string _thirdProductExpectedPrice = "$179.99";

            Assert.That(thirdProductName , Is.EqualTo(_thirdProductExpectedName));
            Assert.That(thirdProductColor , Is.EqualTo(_thirdProductExpectedColor));
            Assert.That(thirdProductQuantity , Is.EqualTo(_thirdProductExpectedQuantity));
            Assert.That(thirdProductPrice , Is.EqualTo(_thirdProductExpectedPrice));
        }


        // 3. לאחר בחירה של לפחות שני מוצרים והסרה של מוצר אחד ע"י שימוש בחלונית עגלת הקניות למעלה מימון, יש לבדוק שהמוצר אכן נעלם מחלונית העגלה
        [Test]
        public void Test3()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(e => e.FindElement(By.Id("laptopsImg")).Displayed);
            driver.FindElement(By.Id("laptopsImg")).Click();
            wait.Until(e => e.FindElement(By.Id("9")).Displayed);
            driver.FindElement(By.Id("9")).Click();
            wait.Until(e => e.FindElement(By.Name("save_to_cart")).Displayed);
            driver.FindElement(By.Name("save_to_cart")).Click();
            driver.Navigate().Back();

            driver.FindElement(By.Id("10")).Click();
            wait.Until(e => e.FindElement(By.Name("save_to_cart")).Displayed);
            driver.FindElement(By.Name("save_to_cart")).Click();

            IWebElement cartIcon = driver.FindElement(By.Id("menuCart"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(cartIcon).Build().Perform();

            string itemToRemoveTitle = driver.FindElement(By.XPath("//h3[text()='HP CHROMEBOOK 14 G1(ES)']")).Text;
            string numberOfItemsInCart = driver.FindElement(By.XPath("//label[text()='(2 Items)']")).Text;

            driver.FindElement(By.XPath("//div[@class='removeProduct iconCss iconX']")).Click();
            string expectedNumberOfItemsAfterX = "1 Item";
            Assert.That(numberOfItemsInCart , Is.Not.EqualTo(expectedNumberOfItemsAfterX));
            string expectedTitleOfCartItem = driver.FindElement(By.XPath("//h3[contains(text(), 'HP CHROMEBOOK 14 G1')]")).Text;
            Assert.That(expectedTitleOfCartItem , Is.Not.EqualTo(itemToRemoveTitle));
        }



        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
