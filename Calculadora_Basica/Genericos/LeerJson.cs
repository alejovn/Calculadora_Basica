using Newtonsoft.Json;

namespace Calculadora_Basica.Genericos
{
    public class LeerJson
    {
        public List<POCO.CalculadoraData> Calcular_data()
        {
            try
            {
                var json = JsonConvert.DeserializeObject<Dictionary<String, List<POCO.CalculadoraData>>>(File.ReadAllText(@"..\..\..\Data\Calculadora.json"));
                return json["Datos"];
            }
            catch (FileNotFoundException)
            {
                throw new Exception("No se encontro el archivo json");
            }
            catch (JsonException ex)
            {
                throw new JsonException($"El archivo json esta corrupto: {ex}");
            }
        }
    }
}
