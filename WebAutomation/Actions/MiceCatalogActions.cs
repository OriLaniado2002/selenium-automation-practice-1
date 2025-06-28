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

    public void ChooseMiceWithById(string miceId)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        OpenMiceCatalog();
        wait.Until(e => e.FindElement(By.Id(miceId)));
        driver.FindElement(By.Id(miceId)).Click();
    }
}