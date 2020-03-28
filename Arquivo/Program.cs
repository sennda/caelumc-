using System;
using System.IO;
namespace Arquivo
{
    class Program
    {
        static void Main(string[] args)
        {
            string nomeTxt = "c:\\caelum\\contas.txt";
            if (!File.Exists(nomeTxt)) {
                Console.WriteLine("Arquivo inexistente!");
                return;
            }
            Stream conteudoTxt = File.Open(nomeTxt, FileMode.Open, FileAccess.Read);
            StreamReader linhatxt = new StreamReader(conteudoTxt);
            string conteudolinha = linhatxt.ReadLine();
            while (conteudolinha !=null) {
                Console.WriteLine(conteudolinha);
                conteudolinha = linhatxt.ReadLine();
            }
            linhatxt.Close();
            conteudoTxt.Close();    
        }
    }
}
