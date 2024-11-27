using AventStack.ExtentReports;
using Calculadora_Basica.Genericos;
using Calculadora_Basica.Tests.Calculadora.Tests;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System.Collections;
using System.Globalization;

namespace Calculadora_Basica.Tests.Calculadora
{
    [TestFixture]
    public class CalculatorTests : BaseTest
    {
        public static IEnumerable TestData
        {
            get
            {
                var json = new LeerJson();
                return json.Calcular_data().Select(data => new TestCaseData(data.valorUno, data.valorDos,data.resultado, data.operacion));
            }
        }
        [Test]
        [TestCaseSource(nameof(TestData))]
        public void RealizarOperacion(double num1, double num2, double result, string operecion)
        {
            test = reports.CreateTest("Validando Cálculo");

            try
            {
                calculator.IngresarNumeros(num1, num2);
                
                calculator.Seleccionar(operecion);
                page.ElementoEsVisible(calculator.CalcularButtom);
                page.ElementoEsActivo(calculator.CalcularButtom);
                page.ElementoNoVacio(calculator.PrimerNumero);
                page.ElementoNoVacio(calculator.SegundoNumero);
                calculator.DarClickBotonCalcular();
                test.Log(Status.Pass, "Se le dio click el boton Calcular");
                page.ElementoEsVisible(calculator.Resultado);
                page.ElementoEsActivo(calculator.Resultado);
                page.ElementoNoVacio(calculator.Resultado);
                // Assertions
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";
                test.Log(Status.Pass, $"valor uno {num1.ToString(nfi)} valor dos {num2.ToString(nfi)} operacion {operecion} resultado {result.ToString(nfi)} ");
                //Assert.That(driver.Url.Equals("https://the-internet.herokuapp.com/secure"), "La URL no corresponde a la pagina de inicio esperada");
                Assert.That(calculator.ValidarResultado(result), "El resultado esta correcto");
                //Assert.That(calculator.LogoutButtom.Displayed, "El botón de logout no se mostró correctamente.");
               test.Log(Status.Pass, "Se realizo la operacion");

                //page.ElementoEsActivo(calculator.LogoutButtom);
                //calculator.ClickBotonLogout();
                //test.Log(Status.Pass, "Se dio click en el botón Logout");
            }
            catch (NoSuchElementException ex)
            {
                test.AddScreenCaptureFromBase64String(captura.CapturarPantalla(driver));
                Assert.Fail($"No se encontró el elemento: {ex.Message}");
            }
            catch (AssertionException ex)
            {
                test.Log(Status.Fail, $"Fallo de aserción: {ex.Message}");
                test.AddScreenCaptureFromBase64String(captura.CapturarPantalla(driver));
                Assert.Fail($"Fallo de aserción: {ex.Message}");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"Error en la ejecución del test: {ex.Message}");
                test.AddScreenCaptureFromBase64String(captura.CapturarPantalla(driver));
                Assert.Fail($"Error en la ejecución del test: {ex.Message}");
                throw;
            }

        }
    }
}