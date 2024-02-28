using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("3 - Deletar arquivo");
            Console.WriteLine("0 - Sair");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Edit(); break;
                case 3: Delete(); break;
                default: Menu(); break;
            }
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path)) {

                // ReadToEnd lê o arquivo inteiro até o final
                string text = file.ReadToEnd();
                Console.WriteLine(text);
                Console.ReadLine();
                Menu();
            }
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("-----------------------");

            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            // Enquanto o usuário não pressionar o ESC
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Save(text);
        }

static void Delete() {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo que deseja deletar?");
            var path = Console.ReadLine();

            // Se o arquivo existir, ele deleta
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine($"Arquivo {path} deletado com sucesso!");
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado!");
            }

            Console.ReadLine();
            Menu();
}
        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");

            var path = Console.ReadLine();

            // Ele cria, usa, abre e já fecha o objeto
            // O using não deixa o arquivo aberto para não gerar problema de memória.
            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}