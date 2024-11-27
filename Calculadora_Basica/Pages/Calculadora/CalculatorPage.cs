using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Globalization;

namespace Calculadora_Basica.Pages.Calculadora
{
    public class CalculatorPage : BasePage
    {
        public CalculatorPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        // Elements locators
        private readonly By _txtprimerNumero = By.Id("number1Field");
        private readonly By _txtsegundoNumero = By.Id("number2Field");
        private readonly By _btnCalcular = By.Id("calculateButton");
        private readonly By _cbxSelccionar = By.Id("numberAnswerField");
        private readonly By _btnLimpiar = By.Id("clearButton");
        private readonly By _chkIntegerOnly = By.Id("integerSelect");

        // Actions
        public IWebElement PrimerNumero => _driver.FindElement(_txtprimerNumero);
        public IWebElement SegundoNumero => _driver.FindElement(_txtsegundoNumero);
        public IWebElement CalcularButtom => _driver.FindElement(_btnCalcular);
        public IWebElement SeleccionarOp => _driver.FindElement(_cbxSelccionar);
        public IWebElement LimpiarButtom => _driver.FindElement(_btnLimpiar);
        public IWebElement IntegerOnlyComp => _driver.FindElement(_chkIntegerOnly);

        public void IngresarNumeros(double num1, double num2)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            PrimerNumero.SendKeys("" + num1.ToString(nfi));
            SegundoNumero.SendKeys("" + num2.ToString(nfi));

        }
        public void Seleccionar(string select)
        {
            CalcularButtom.Click();
            new SelectElement(SeleccionarOp).SelectByText(select);

        }
        public void IntegerOnly()
        {
            IntegerOnlyComp.Click();
        }

        public void DarClickBotonCalcular()
        {
            CalcularButtom.Click();
        }

        /*public bool ValidarBoton()
        {
            bool seMuestra = LogoutButtom.Displayed;
            return seMuestra;
        }
        public bool ValidarIngresoCorrecto()
        {
            bool isLogged = LoginMessage.Text.Contains("You logged into a secure area!") && PageMessage.Text.Equals("Welcome to the Secure Area. When you are done click logout below.");
            return isLogged;
        }*/

        public void DarClickBotonLimpiar()
        {
            LimpiarButtom.Click();
        }
    }
}
