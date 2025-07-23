using System;
using ProjetoPessoalFIlaPrioridae.Services;
using ProjetoPessoalFIlaPrioridae.Models;
namespace ProjetoPessoalFIlaPrioridae.Menus
{
    public class Menu
    {
        Usuario usuarios = new Usuario();
        FilaPrioridade pacientes = new FilaPrioridade();
        public void telaInicial()
        {
            Console.WriteLine("========= BEM VINDO =========");
            Console.WriteLine("1.Fazer login");
            Console.WriteLine("2.Cadastrar novo Usuario");
            Console.WriteLine("3.SAIR");
            int op = int.Parse(Console.ReadLine());
            if (op == 1)
            {
                string[] linhaAcessoArq = usuarios.verificarLogin();
                telaPadrao(linhaAcessoArq);
                InterfaceMenu(linhaAcessoArq[3]);

            }
            else if (op == 2)
            {
                usuarios.InserirNovoUsuario();
                telaInicial();

            }
            else
            {

                Console.WriteLine("Good-Bye");
            }

        }
        void  menuGravidades()
        {
            Console.WriteLine();
            Console.WriteLine("De acordo com a gravidade do paciente escolha uma opção.");
            Console.WriteLine("1.Vermelho(EMERGENCIA)");
            Console.WriteLine("2.Laranja(MUITO - URGENTE)");
            Console.WriteLine("3.Amarelo(URGENTE)");
            Console.WriteLine("4.Verde(POUCO-URGENTE)");
            Console.WriteLine("5.Azul(NÃO-URGENTE)");
            Console.WriteLine();

        }
        Gravidade setGravidade()
        {
            menuGravidades();
            int valor = int.Parse(Console.ReadLine());
            while (valor < 0 && valor > 5)
            {
                menuGravidades();
                valor = int.Parse(Console.ReadLine());
            }
            string valorGravidade = "";
            switch (valor)
            {
                case 1:
                    {
                        valorGravidade = "vermelho";
                        break;


                    }
                case 2:
                    {
                        valorGravidade = "laranja";
                        break;

                    }
                case 3:
                    {
                        valorGravidade = "amarelo";
                        break;

                    }
                case 4:
                    {
                        valorGravidade = "verde";
                        break;
                    }
                case 5:
                    {
                        valorGravidade = "azul";
                        break;
                    }
            }
            Gravidade gravidade = new Gravidade(valorGravidade);
            return gravidade;

        }
        Idade setIdade()
        {
            Console.WriteLine("Digite a idade do paciente");
            int valorIdade = int.Parse(Console.ReadLine());
            while (valorIdade < 0 && valorIdade > 130)
            {
                Console.WriteLine("Idade invalida gentileza digitar um numero entre 1 e 130");
                valorIdade = int.Parse(Console.ReadLine());
            }
            Idade idade = new Idade(valorIdade);
            return idade;
        }
        public void telaPadrao(string[] linhaAcessoArq)
        {
            string nome = linhaAcessoArq[0];
            string tipoAcesso = linhaAcessoArq[3];
            Console.WriteLine($"Usuário: {nome}");
            Console.WriteLine($"Cargo: {tipoAcesso}");
            Console.WriteLine("\n--- Lista de Pacientes ---");
            pacientes.Mostrar();

            Console.WriteLine("\n--- Opções ---");
            Console.WriteLine(" ");
        }
        public void InterfaceMenu(string verificar)
        {

            int op = 0;
            if (verificar == "medico")
            {
                while (op != 3)
                {

                    Console.WriteLine("1.Atender Paciente");
                    Console.WriteLine("2.Mostrar Pacientes");
                    Console.WriteLine("3.Sair");
                    op = int.Parse(Console.ReadLine());
                    switch(op)
                    {
                        case 1:
                            {
                                pacientes.Remover();
                                break;
                            }
                        case 2:
                            {
                                pacientes.Mostrar();
                                break;
                            }
                       
                    }

                }
            }
            else
            {
                while (op != 3)
                {

                    Console.WriteLine("1.Inserir  Paciente na Fila");
                    Console.WriteLine("2.Sair");
                    op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            {
                                if (pacientes != null)
                                {
                                    pacientes.Ordenar();
                                }
                                Console.WriteLine("Digite o nome do paciente");
                                string nome = Console.ReadLine();
                                Idade idade = setIdade();
                                Gravidade gravidade = setGravidade();
                                Paciente paciente = new Paciente(nome, idade, gravidade);
                                pacientes.Infileirar(paciente);
                                pacientes.Ordenar();
                                pacientes.Mostrar();
                                break;
                            }
                        case 2:
                            {

                                telaInicial();
                                break;
                            }


                    }
                }
            }




        }

    }
}
