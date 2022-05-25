
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace Exercicio_Consulta_Api
{
    class Program
    {
        static void Main(string[] args)
        {
            string data;

            HttpClient client = new HttpClient();

            HttpResponseMessage respostaHttp;

            Console.WriteLine("Informe a data no formato MM-DD-AAAA");
            data = Console.ReadLine();


            respostaHttp = client.GetAsync($"https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoDolarDia(dataCotacao=@dataCotacao)?@dataCotacao=%27{data}%27&$top=100&$format=json").Result;

            string JsonCovertido = respostaHttp.Content.ReadAsStringAsync().Result;

            CotacaoDolar cotacaoDolar = JsonConvert.DeserializeObject<CotacaoDolar>(JsonCovertido);


            Console.WriteLine($"Cotação Compra{cotacaoDolar.value[0].cotacaoCompra}");
            Console.WriteLine($"Cotação Venda{cotacaoDolar.value[0].cotacaoVenda}");
            Console.WriteLine($"Data Hora Cotação{cotacaoDolar.value[0].dataHoraCotacao}");

            Console.ReadKey();
        }
    }
}