using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio_Consulta_Api
{
    public class CotacaoDolar
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        public List<Value> value { get; set; }
    }

    public class Value
    {
        public double cotacaoCompra { get; set; }
        public double cotacaoVenda { get; set; }
        public string dataHoraCotacao { get; set; }
    }
}
