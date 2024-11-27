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
        private readonly By _cbxSelccionar = By.Id("selectOperationDropdown");
        private readonly By _btnLimpiar = By.Id("clearButton");
        private readonly By _chkIntegerOnly = By.Id("integerSelect");
        private readonly By _txtResultado = By.Id("numberAnswerField");

        // Actions
        public IWebElement PrimerNumero => _driver.FindElement(_txtprimerNumero);
        public IWebElement SegundoNumero => _driver.FindElement(_txtsegundoNumero);
        public IWebElement CalcularButtom => _driver.FindElement(_btnCalcular);
        public IWebElement SeleccionarOp => _driver.FindElement(_cbxSelccionar);
        public IWebElement LimpiarButtom => _driver.FindElement(_btnLimpiar);
        public IWebElement IntegerOnlyComp => _driver.FindElement(_chkIntegerOnly);
        public IWebElement Resultado => _driver.FindElement(_txtResultado);

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

       public bool ValidarBoton()
        {
            bool seMuestra = CalcularButtom.Displayed;
            return seMuestra;
        } 
        public bool ValidarResultado(double result)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            bool isResult = Resultado.GetAttribute("value").Equals(result.ToString(nfi));
            return isResult;
        }

        public void DarClickBotonLimpiar()
        {
            LimpiarButtom.Click();
        }
    }
}
