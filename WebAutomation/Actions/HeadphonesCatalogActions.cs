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

    public void ChooseHeadphone15()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(e => e.FindElement(By.Id("15")).Displayed);
        driver.FindElement(By.Id("15")).Click();
    }

    public void ChooseHeadphone55()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(e => e.FindElement(By.Id("55")).Displayed);
        driver.FindElement(By.Id("55")).Click();
    }
}