namespace Entities
{
    public class Cliente
    {
        public Cliente(string nome, string cPF, string rG, string telefoneUm, string telefoneDois, string email)
        {
            Nome = nome;
            CPF = cPF;
            RG = rG;
            Telefone_Um = telefoneUm;
            Telefone_Dois = telefoneDois;
            Email = email;
        }

        public Cliente()
        {
        }

        public int ID { get; set; }
        public int Pontos { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone_Um { get; set; }
        public string Telefone_Dois { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        //Endereco endereco
    }

}