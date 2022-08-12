
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IEntradaProdutos
    {
        public Response EfetuarEntrada(Entrada entrada);
        public DataResponse<EntradaView> LerEntradas(DateTime inicio, DateTime fim);
    }

    public interface ISaidaProdutos
    {
        public Response EfetuarSaida(Saida saida);
        public DataResponse<SaidaView> LerSaidas(DateTime inicio, DateTime fim);
    }
}
