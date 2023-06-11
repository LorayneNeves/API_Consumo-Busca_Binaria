using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotacaoMoedas_API
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Root
    {
        public int quantidade;
        public string moeda1;
        public string moeda2;
        public string startDate;
        public string endDate;
        public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string varBid { get; set; }
        public string pctChange { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string timestamp { get; set; }
        public string create_date { get; set; }
        public USDBRL USDBRL { get; set; }
        public EURBRL EURBRL { get; set; }
        public BTCBRL BTCBRL { get; set; }


    }


}
