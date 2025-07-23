# 🏥 Projeto: Fila de Prioridade para Pacientes

Este é um sistema de gerenciamento de fila de prioridade desenvolvido em **C#**, com base em regras específicas de atendimento, como **idade** e **gravidade clínica**. O objetivo é simular uma triagem inteligente, priorizando pacientes de forma organizada.

## 🛠 Funcionalidades

* Sistema de **login com validação de e-mail e senha**.
* Diferenciação entre **médico e enfermeiro** ao logar, definindo permissões:

  * Enfermeiros têm acesso ao **cadastro de pacientes**.
  * Médicos têm acesso ao **atendimento e chamada de pacientes**.
* Verificação da validade do e-mail e da senha informados.
* Armazenamento dos dados de login em um arquivo `.txt`.
* Cadastro de pacientes com dados como nome, idade e gravidade.
* Organização automática da fila com base em critérios de prioridade.
* Menu interativo no terminal (console).
* Armazenamento dos dados em arquivo `.txt`.

## 📁 Estrutura

```
ProjetoPessoalFIlaPrioridae/
├── Models/
│   ├── Paciente.cs
│   ├── Gravidade.cs
│   ├── Idade.cs
│   └── ...
├── Services/
│   └── FilaPrioridade.cs
├── Menus/
│   └── Menu.cs
├── usuario.txt
├── Program.cs
└── App.config
```

## 🚀 Como Executar

1. Clone este repositório:

   ```bash
   git clone https://github.com/seu-usuario/ProjetoPessoalFilaPrioridade.git
   ```

2. Abra o projeto no **Visual Studio** (ou Rider/VS Code com suporte .NET).

3. Compile e execute (`Ctrl + F5`).

> ✔️ Requer .NET Framework 4.7.2 ou superior.

## 🧠 O que se aprende com esse projeto?

* Estrutura de dados personalizada com **listas encadeadas**.
* Lógica de **prioridade em filas**.
* Manipulação de arquivos `.txt` em C#.
* Princípios de **POO** (Programação Orientada a Objetos).
* Validação de **login com controle de perfil** (médico ou enfermeiro).

## 👨‍💻 Autor

**Yago Marques**
Estudante de Análise e Desenvolvimento de Sistemas na PUC Minas
📍 Minas Gerais, Brasil
🔗 [GitHub](https://github.com/yagoc0d)

---
