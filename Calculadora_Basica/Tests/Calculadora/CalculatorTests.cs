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
                //Assert.That(calculator.ValidarIngresoCorrecto(), "La validación de ingreso correcto falló.");
                //Assert.That(calculator.LogoutButtom.Displayed, "El botón de logout no se mostró correctamente.");
               //test.Log(Status.Pass, "Se ingreso correctamente");

                //page.ElementoEsActivo(calculator.LogoutButtom);
                //calculator.ClickBotonLogout();
                //test.Log(Status.Pass, "Se dio click en el botón Logout");
            }
            catch (NoSuchElementException ex)
            {
                //test.AddScreenCaptureFromBase64String(captura.CapturarPantalla(driver));
                Assert.Fail($"No se encontró el elemento: {ex.Message}");
            }
            catch (AssertionException ex)
            {
                //test.Log(Status.Fail, $"Fallo de aserción: {ex.Message}");
                //test.AddScreenCaptureFromBase64String(captura.CapturarPantalla(driver));
                Assert.Fail($"Fallo de aserción: {ex.Message}");
            }
            catch (Exception ex)
            {
                //test.Log(Status.Fail, $"Error en la ejecución del test: {ex.Message}");
                //test.AddScreenCaptureFromBase64String(captura.CapturarPantalla(driver));
                Assert.Fail($"Error en la ejecución del test: {ex.Message}");
                throw;
            }

        }
    }
}