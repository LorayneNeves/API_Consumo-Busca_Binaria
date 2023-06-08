using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace API_ListaDadosPaises
{
    public class DadosPais

    {
        public Name name { get; set; }
        public List<string> capital { get; set; }
        public Currencies currencies { get; set; }
        public string recebeMoeda { get; set; }
        public string recebeRegiao { get; set; }


    }
}