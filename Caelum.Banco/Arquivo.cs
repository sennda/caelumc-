using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caelum.Banco
{
    public partial class FrmArquivo : Form
    {
        private string nomeTxt = "c:\\caelum\\contas.txt";
        public FrmArquivo()
        {
            InitializeComponent();
        }

        private void FrmArquivo_Load(object sender, EventArgs e)
        {
            Lertxt();
        }

        private void Lertxt() {
            if (!File.Exists(nomeTxt))
            {
                Console.WriteLine("Arquivo inexistente!");
                return ;
            }
            Stream conteudoTxt = File.Open(nomeTxt, FileMode.Open, FileAccess.Read);
            StreamReader linhatxt = new StreamReader(conteudoTxt);
            string conteudolinha = linhatxt.ReadLine();
            while (conteudolinha != null)
            {
                Console.WriteLine(conteudolinha);
                txtEditor.Text += conteudolinha = linhatxt.ReadLine();
            }
            linhatxt.Close();
            conteudoTxt.Close();
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            if (txtEditor.Text.Trim() == "") {
                MessageBox.Show("Preencha as informações a serem gravadas!");
                txtEditor.Focus();
                return;
            }

            File.AppendAllText(nomeTxt, txtEditor.Text.Trim());
        }
    }
}
