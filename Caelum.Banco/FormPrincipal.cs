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
using Caelum.Banco.Negocio;

namespace Caelum.Banco
{
    public partial class FormPrincipal : Form
    {
        IList<Conta> contas;
        IDictionary<string, Conta> contasPorTitular;
        string nomeArquivo = "c:\\caelum\\contas.txt"; 

        public FormPrincipal()
        {
            InitializeComponent();
        }

        public void AdicionaConta(Conta conta)
        {
            contas.Add(conta);
            contasPorTitular.Add(conta.Titular.Nome, conta);
            comboContas.Items.Add(conta);


        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            contas = new List<Conta>();
            contasPorTitular = new Dictionary<string, Conta>();

            if (File.Exists(nomeArquivo)) {
                Stream conteudoTxt = File.Open(nomeArquivo, FileMode.Open, FileAccess.Read);
                StreamReader linhatxt = new StreamReader(conteudoTxt);
                string conteudolinha = linhatxt.ReadLine();
                while (conteudolinha != null)
                {
                    AdicionaConta(convertelinha(conteudolinha));
                    conteudolinha = linhatxt.ReadLine();
                }
                linhatxt.Close();
                conteudoTxt.Close();

            }

        }

        private void btnNova_Click(object sender, EventArgs e)
        {
            var form = new FormCadastroConta(this);
            form.ShowDialog();
        }

        private void AtualizaContaSelecionada()
        {
            var contaSelecionada = comboContas.SelectedItem as Conta;
            textoNumero.Text = contaSelecionada.Numero.ToString("000");
            textoTipo.Text = contaSelecionada.GetType().Name;
            textoTitular.Text = contaSelecionada.Titular.Nome;
            textoSaldo.Text = contaSelecionada.Saldo.ToString("0.00");
        }

        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AtualizaContaSelecionada();
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            var parseOk = Double.TryParse(textoValor.Text, out double valorOperacao);
            if (!parseOk)
            {
                MessageBox.Show("Valor inválido (esperado: número)");
                return;
            }
            var contaSelecionada = comboContas.SelectedItem as Conta;
            contaSelecionada.Deposita(valorOperacao);
            this.AtualizaContaSelecionada();
        }

        private void btnSaque_Click(object sender, EventArgs e)
        {
            var parseOk = Double.TryParse(textoValor.Text, out double valorOperacao);
            if (!parseOk)
            {
                MessageBox.Show("Valor inválido (esperado: número)");
                return;
            }
            var contaSelecionada = comboContas.SelectedItem as Conta;
            contaSelecionada.Saca(valorOperacao);
            this.AtualizaContaSelecionada();
        }

        private void btnBuscaTitular_Click(object sender, EventArgs e)
        {
            string nomeTitular = textoBuscaTitular.Text;
            if (string.IsNullOrWhiteSpace(nomeTitular))
            {
                MessageBox.Show("Preencha o titular");
                return;
            }
            
            if (contasPorTitular.ContainsKey(nomeTitular))
            {
                comboContas.SelectedItem = contasPorTitular[nomeTitular];
            } else
            {
                MessageBox.Show("Titular não encontrado!");
                return;
            }
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            var form = new FormRelatorios(this.contas);
            form.ShowDialog();
        }

        private void cmdEditordeTexto_Click(object sender, EventArgs e)
        {
            Form frmArquiv = new FrmArquivo();
            frmArquiv.ShowDialog();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        public Conta convertelinha(string linha)
        {
            string[] lista = linha.Split(';');
            Conta conta = null;
            if (lista[3] == "CC")
            {
                conta = new ContaCorrente(lista[1]);
            }
            else
            {
                conta = new ContaPoupanca(lista[1]);
            }
            conta.Deposita(Convert.ToDouble(lista[2]));
            return conta;
        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (File.Exists(nomeArquivo))
            {
                Stream conteudoTxt = File.Open(nomeArquivo, FileMode.Open, FileAccess.ReadWrite);
                StreamWriter linhatxt = new StreamWriter(conteudoTxt);
                foreach (Conta conta in contas) {
                    string tipo = (conta is ContaCorrente) ? "CC" : "CP";
                    string linha = $"{conta.Numero};{conta.Titular.Nome};{conta.Saldo};{tipo}";
                    linhatxt.WriteLine(linha);
                }
                linhatxt.Close();
                conteudoTxt.Close();

            }
        }
    }
}



