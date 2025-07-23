
namespace ProjetoPessoalFIlaPrioridae.Models
{
    public class Idade
    {
        public int valor;
        public int peso;
        public Idade(int valor)
        {
            this.valor = valor;
            if (valor > 0 && valor < 12)
            {
                this.peso = -1;
            }
            else if (valor > 12 && valor < 60)
            {
                this.peso = 0;
            }
            else
            {
                this.peso = -1;
            }

            this.valor = valor;

        }
    }
}
