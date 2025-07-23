
namespace ProjetoPessoalFIlaPrioridae.Models
{
    public class Celula
    {
        private Paciente elemento;
        private Celula prox;
        public Celula(Paciente elemento)
        {
            this.elemento = elemento;
            this.prox = null;
        }
        public Celula()
        {
            this.elemento = null;
            this.prox = null;
        }
        public Celula Prox
        {
            get { return prox; }
            set { prox = value; }
        }
        public Paciente Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }
    }
}
