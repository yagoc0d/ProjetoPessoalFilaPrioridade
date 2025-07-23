
namespace ProjetoPessoalFIlaPrioridae.Models
{
    public class Paciente
    {
        public string nome;
        public Idade idade;
        public Gravidade gravidade;
        public int pesoFinal;
        public Paciente(string nome, Idade idade, Gravidade gravidade)
        {
            this.nome = nome;
            this.idade = idade;
            this.gravidade = gravidade;
            this.pesoFinal = gravidade.peso + idade.peso;
        }
    }
}
