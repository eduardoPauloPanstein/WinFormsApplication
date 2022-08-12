using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class FuncionarioLogado
    {
        //Caso precisar de mais infos do funcionario logado setar no loginBLL - tirar o login do funcionarioDAL ithk

        public static int ID { get; set; }
        public static string Nome { get; set; }
        public static bool ISADM { get; set; }

        //public static bool IsADM(Usuario usuario)
        //{
        //    if (usuario.ConferirLoginADM())
        //        ISADM = true;
        //    else ISADM = false;
        //    return ISADM;
        //}
    }
}
