using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace API_ListaDadosPaises
{
    public class Currencies
    {
        public RSD RSD { get; set; }
        public USD USD { get; set; }
        public BBD BBD { get; set; }
        public MWK MWK { get; set; }
        public JOD JOD { get; set; }
    }
}