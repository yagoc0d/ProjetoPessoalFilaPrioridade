using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
namespace ProjetoPessoalFIlaPrioridae.Models
{
    public class Usuario
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string tipoAcesso { get; set; }
        public string caminhoUsuario = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usuario.txt");
       

        List<Usuario> usuarios = new List<Usuario>();
        public Usuario(string nome, string email, string senha, string tipoAcesso)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.tipoAcesso = tipoAcesso;

        }
        public Usuario()
        {
            this.nome = "";
            this.email = "";
            this.senha = "";
            this.tipoAcesso = "";

        }
        void CarregarUsuario()
        {
            if (!File.Exists(this.caminhoUsuario))
            {

            }
            else
            {
                StreamReader arquivo = new StreamReader(this.caminhoUsuario);
                arquivo.Close();
                List<string> linhas = File.ReadAllLines(this.caminhoUsuario).ToList();
                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split(';');
                    if (partes.Length == 4)
                    {
                        string nome = partes[0];
                        string email = partes[1];
                        string senha = partes[2];
                        string tipoAcesso = partes[3];
                        usuarios.Add(new Usuario(nome, email, senha, tipoAcesso));
                    }
                }
            }


        }
        bool VerificarUsuarioExistente(string newemail)
        {
            bool teste = false;
            if (!File.Exists(this.caminhoUsuario))
            {

            }
            else
            {

                

                StreamReader arquivo = new StreamReader(this.caminhoUsuario);
                arquivo.Close();
                List<string> linhas = File.ReadAllLines(this.caminhoUsuario).ToList();
                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split(';');
                    string email = partes[1];
                    if (newemail == email)
                    {
                        teste = true;
                        return teste;
                    }

                }
            }
            return teste;
        }
        void GravarNovosUsuarios()
        {
            StreamWriter arquivo = new StreamWriter(this.caminhoUsuario);

            foreach (Usuario usuario in usuarios)
            {
                arquivo.WriteLine(usuario.nome + ";" + usuario.email + ";" + usuario.senha + ";" + usuario.tipoAcesso);
            }
            arquivo.Close();


        }
        public bool EmailValido(string email)
        {
            string padrao = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, padrao);
        }
        public bool SenhaValida(string senha)
        {
            string padrao = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%&*!^])[A-Za-z\d@#$%&*!^]{8,}$";
            return Regex.IsMatch(senha, padrao);
        }

        public string[] verificarLogin()
        {
            CarregarUsuario();
            Console.Clear();
            bool test = false;
            Console.WriteLine("========= TELA DE LOGIN =========");
            Console.Write("Usuário: ");
            string usuario = Console.ReadLine();
            StreamReader arquivo = new StreamReader(this.caminhoUsuario);
            arquivo.Close();
            string[] linhaAcessoinfo = new string[4];
            while (!test)
            {
                List<string> linhas = File.ReadAllLines(this.caminhoUsuario).ToList();
                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split(';');
                    string usuarioArq = partes[1];
                    if (usuario == usuarioArq)
                    {
                        linhaAcessoinfo = linha.Split(';');
                        test = true;
                        break;
                    }
                }
                if (!test)
                {
                    EnderecoInvalido();
                    usuario = Console.ReadLine();
                }

            }
            test = false;
            Console.Write("Senha: ");
            string senha = Console.ReadLine();
            while (!test)
            {
                string senhaArq = linhaAcessoinfo[2];
                if (senha == senhaArq)
                {
                    test = true;
                    break;
                }
                else if (!test)
                {
                    Console.WriteLine("Senha Incorreta");
                    senha = Console.ReadLine();
                }
            }
            return linhaAcessoinfo;
        }
        public void EnderecoInvalido()
        {
            Console.WriteLine("Endereço invalido, Digite novamente:");
        }
        public void FuncaoUsuario()
        {
            Console.WriteLine("Digite a função do usuario");
            Console.WriteLine("1.Medico(a)");
            Console.WriteLine("2.Enfermeiro(a)-TRIAGEM");

        }
        public Usuario CriarUsuario()
        {
            CarregarUsuario();
            string tipoAcesso;
            Console.WriteLine("Digite seu nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o endereço de email do novo usuario");
            string email = Console.ReadLine();
            while (!EmailValido(email))
            {
                EnderecoInvalido();
                email = Console.ReadLine();
            }
            while (VerificarUsuarioExistente(email))
            {
                Console.WriteLine("Usuario já existente");
                EnderecoInvalido();
                email = Console.ReadLine();
            }
            Console.WriteLine("Digite a senha");
            string senha = Console.ReadLine();
            while (!SenhaValida(senha))
            {
                Console.WriteLine("Senha Invalida o padrão da senha é : Mínimo 8 caracteres\r\n\r\nPelo menos 1 letra maiúscula\r\n\r\nPelo menos 1 letra minúscula\r\n\r\nPelo menos 1 número\r\n\r\nPelo menos 1 caractere especial (@#$%&*!, etc)");
                Console.WriteLine("Digite novamente");
                senha = Console.ReadLine();
            }
            FuncaoUsuario();
            int tipoUsuario = int.Parse(Console.ReadLine());
            while (tipoUsuario < 1 || tipoUsuario > 2)
            {
                FuncaoUsuario();
                tipoUsuario=int.Parse(Console.ReadLine());
            }
            if (tipoUsuario == 1)
            {
                tipoAcesso = "medico";
            }
            else
            {
                tipoAcesso = "enfermeiro";
            }
            Usuario novousuario = new Usuario(nome, email, senha, tipoAcesso);
            return novousuario;
        }
        public void InserirNovoUsuario()
        {
            this.usuarios.Add(CriarUsuario());
            GravarNovosUsuarios();
        }

    }
}
