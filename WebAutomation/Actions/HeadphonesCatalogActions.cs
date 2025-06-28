using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

public class HeadphonesCatalogActions : HeadphonesCatalogPage
{
    private IWebDriver driver;
    private HeadphonesCatalogPage headphonesCatalogPage;
    private HomePageActions homePageActions;

    public HeadphonesCatalogActions(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
        headphonesCatalogPage = new HeadphonesCatalogPage(driver);
        homePageActions = new HomePageActions(driver);
    }

    public void OpenHeadphonesCatalog() => homePageActions.HeadphonesCatalog();

    public void ChooseHeadphoneById(string headphoneId)
    {
        WebDriverWait wait = new WebDriverWait (driver, TimeSpan.FromSeconds(10));

        wait.Until(e => e.FindElement(By.Id(headphoneId)).Displayed);
        driver.FindElement(By.Id(headphoneId)).Click();
    }
}