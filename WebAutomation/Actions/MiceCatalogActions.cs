using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class MiceCatalogActions : MiceCatalogPage
{
    private IWebDriver driver;
    private MiceCatalogPage miceCatalogPage;
    private HomePageActions homePageActions;

    public MiceCatalogActions(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
        miceCatalogPage = new MiceCatalogPage(driver);
        homePageActions = new HomePageActions(driver);
    }

    public void OpenMiceCatalog() => homePageActions.MiceCatalog();
    public void ChooseMiceWithId28()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        OpenMiceCatalog();
        wait.Until(e => e.FindElement(By.Id("28")));
        driver.FindElement(By.Id("28")).Click();
    }
}