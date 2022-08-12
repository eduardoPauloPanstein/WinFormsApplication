using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    //Depois mudar para o BLL ithk
    public class Usuario
    {
        //Usuarios serão funcionarios e o login é o email
        public Usuario(string login, string password)
        {
            Email = login;
            Senha = password;
        }

        public Usuario()
        {
        }

        public string Email { get;set; }
        public string Senha { get;set; }

        readonly string _loginADM = "admin";
        readonly string _passwordADM = "admin";

        /// <summary>
        /// se as credencias do login foram iguais a do adm retorna true
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ConferirLoginADM()
        {
            return _loginADM.Equals(this.Email) && _passwordADM.Equals(this.Senha);
        }

    }
    //public class UsuarioAdmin

}
