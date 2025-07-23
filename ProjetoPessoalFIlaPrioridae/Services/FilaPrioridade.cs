using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPessoalFIlaPrioridae.Models;

namespace ProjetoPessoalFIlaPrioridae.Services
{
    class FilaPrioridade
    {
        private Celula primeiro, ultimo;
        public FilaPrioridade()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }
        public void Infileirar(Paciente paciente)
        {
            ultimo.Prox = new Celula(paciente);
            ultimo = ultimo.Prox;

        }
        public Paciente Remover()
        {
            if (primeiro == ultimo)
            {
                throw new Exception("Erro!");
            }
            Celula tmp = primeiro;
            primeiro = primeiro.Prox;
            Paciente elemento = primeiro.Elemento;
            tmp.Prox = null;
            tmp = null;
            return elemento;
        }
        public void Ordenar()
        {

            List<Paciente> pacientes = new List<Paciente>();
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                pacientes.Add(i.Elemento);
            }
            pacientes = pacientes.OrderBy(p => p.pesoFinal).ToList();
            primeiro.Prox = null;
            ultimo = primeiro;

            foreach (Paciente paciente in pacientes)
            {
                Infileirar(paciente);
            }


        }
        public void Mostrar()
        {
            Console.WriteLine();
            if (primeiro.Prox == null)
            {
                Console.WriteLine("Não a pacientes cadastrados");
            }
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                Console.Write(i.Elemento.nome + " -- " + "(" + i.Elemento.gravidade.tipo + ")" + " Idade :   " + i.Elemento.idade.valor);
                Console.WriteLine();
            }

        }

    }
}
