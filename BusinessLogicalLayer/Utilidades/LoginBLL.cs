using DataAccessLayer;
using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Utilidades
{
    public  class LoginBLL
    {
        FuncionarioDAL funcionarioDAL = new();
        ClienteDAL clienteDAL = new();

        public Response Login(Usuario usuario)
        {
            usuario.Senha = HashGenerator.ComputeSha256Hash(usuario.Senha);
            return funcionarioDAL.Login(usuario.Email, usuario.Senha);
        }

        /// <summary>
        /// Ao fazer login verifica se já existe um funcionario(admin) e um Cliente Padrão, se não, cria
        /// </summary>
        public void ConferirDefault()
        {
            string senha = HashGenerator.ComputeSha256Hash("admin");
            funcionarioDAL.ConferirDefault(senha);

            clienteDAL.ConferirDefault();
        }
    }
}
