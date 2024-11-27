using Calculadora_Basica.Genericos;
using Calculadora_Basica.Tests.Calculadora.Tests;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System.Collections;

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
                return json.Calcular_data().Select(data => new TestCaseData(data.valorDos, data.valorUno));
            }
        }
        [Test]
        [TestCaseSource(nameof(TestData))]
        public void RealizarOperacion(double num1, double num2 )
        {
            //test = reports.CreateTest("Validando ingreso correcto");

            try
            {
                calculator.IngresarNumeros(num1, num2);
                //page.ElementoEsVisible(calculator.LoginButtom);
                //page.ElementoEsActivo(calculator.LoginButtom);
                //page.ElementoNoVacio(calculator.UsernameField);
                calculator.DarClickBotonCalcular();
                //test.Log(Status.Pass, "Se le dio click el boton login");

                // Assertions
                //Assert.That(driver.Url.Equals("https://the-internet.herokuapp.com/secure"), "La URL no corresponde a la pagina de inicio esperada");
                //Assert.That(calculator.ValidarIngresoCorrecto(), "La validaci�n de ingreso correcto fall�.");
                //Assert.That(calculator.LogoutButtom.Displayed, "El bot�n de logout no se mostr� correctamente.");
               //test.Log(Status.Pass, "Se ingreso correctamente");

                //page.ElementoEsActivo(calculator.LogoutButtom);
                //calculator.ClickBotonLogout();
                //test.Log(Status.Pass, "Se dio click en el bot�n Logout");
            }
            catch (NoSuchElementException ex)
            {
                //test.AddScreenCaptureFromBase64String(captura.CapturarPantalla(driver));
                Assert.Fail($"No se encontr� el elemento: {ex.Message}");
            }
            catch (AssertionException ex)
            {
                //test.Log(Status.Fail, $"Fallo de aserci�n: {ex.Message}");
                //test.AddScreenCaptureFromBase64String(captura.CapturarPantalla(driver));
                Assert.Fail($"Fallo de aserci�n: {ex.Message}");
            }
            catch (Exception ex)
            {
                //test.Log(Status.Fail, $"Error en la ejecuci�n del test: {ex.Message}");
                //test.AddScreenCaptureFromBase64String(captura.CapturarPantalla(driver));
                Assert.Fail($"Error en la ejecuci�n del test: {ex.Message}");
                throw;
            }

        }
    }
}