using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DataFiltro
    {
        //pegar registros de x dias atras até o momento

        public DateTime DtInicio {get; set;}
        public DateTime DtFim => DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d">quantidade de dias atras</param>
        public DataFiltro(int d)
        {
            this.DtInicio = DateTime.Now.AddDays(-d);
        }
    }
}
