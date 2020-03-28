using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caelum.Banco.Negocio;

namespace Caelum.Banco
{
    public partial class FormRelatorios : Form
    {
        IEnumerable<Conta> contas;

        public FormRelatorios(IEnumerable<Conta> contas)
        {
            InitializeComponent();
            this.contas = contas;
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            listBoxContas.Items.Clear();
            var resultado = this.contas
                .Where(c => c.Saldo > 5000)
                .OrderBy(c => c.Titular.Nome);
            listBoxContas.Items.AddRange(resultado.ToArray());
            lblSaldoTotal.Text = resultado.Sum(c => c.Saldo).ToString("0,0.00");
            lblMaiorSaldo.Text = resultado.Max(c => c.Saldo).ToString("0,0.00");
        }
    }
}
