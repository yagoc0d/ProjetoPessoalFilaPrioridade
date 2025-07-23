
namespace ProjetoPessoalFIlaPrioridae.Models
{
    public class Gravidade
    {
        public string tipo;
        public int peso;
        public Gravidade(string tipo)
        {
            this.tipo = tipo;
            if (tipo == "vermelho")
            {
                this.peso = 1;
            }
            else if (tipo == "laranja")
            {
                this.peso = 2;
            }
            else if (tipo == "amarelo")
            {
                this.peso = 3;
            }
            else if (tipo == "verde")
            {
                this.peso = 4;
            }
            else
            {
                this.peso = 5;
            }
        }


    }

}
