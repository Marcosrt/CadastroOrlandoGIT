using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Agenda.Formularios
{
    public partial class frmProdutos : Form
    {
        public frmProdutos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tstSalvar_Click(object sender, EventArgs e)
        {
            // validação do conteúdo
            if (txtDescricao.Text == "")
            {
                errError.SetError(lblDescricao, "Campo Obrigatório");
                return;
            }
            else
            {
                errError.SetError(lblDescricao, "");
            }
            //pergunta para o usário se ele confirma a inclusão do cadastro
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma a Inclusão?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (resposta.Equals(DialogResult.No))
            {
                return;
            }

            //instancia a classe de negócio
            clProdutos clProdutos = new clProdutos();

            //carrega as propriedades
            clProdutos.proDescricao = txtDescricao.Text;
            clProdutos.proMarca = txtMarca.Text;

            //tratamento de campo numérico
            decimal Preco;
            if(decimal.TryParse(txtPreco.Text, out Preco))
            {
                clProdutos.proPreco = Convert.ToString(Preco);
            }
            else
            {
                clProdutos.proPreco = "0";
            }

            //tratamento de campo data
            clProdutos.proData = String.Format("{0:yyyy-MM-dd}", dtpData.Value);

            //variável com a string de conexão com o banco
            clProdutos.banco = Properties.Settings.Default.conexaoDB;
            //chama o metodo gravar
            clProdutos.Gravar();

            //mensagem de confirmação da inclusão
            MessageBox.Show("Cliente Incluído com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
