using Calculadora_Basica.Genericos;
using Calculadora_Basica.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Calculadora_Basica.Pages.Calculadora;

namespace Calculadora_Basica.Tests.Calculadora.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;
        public CalculatorPage calculator;
        public LeerJson json;
        public string baseURL = "https://testsheepnz.github.io/BasicCalculator.html";
        public WebDriverWait wait;
        public BasePage page;
        public TomarCaptura captura;

        /* reportes
        public static ExtentTest test;
        public static ExtentReports reports;*/


        [SetUp]
        public void IniciarNavegador()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);
            calculator = new CalculatorPage(driver, wait);
            page = new BasePage(driver, wait);
            captura = new TomarCaptura();

        }
        [TearDown]
        public void CerrarNavegador()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
