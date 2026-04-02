using Newtonsoft.Json;
using System.CodeDom;
using System.Threading.Tasks;
using Winform_ConsultaCEP.Models;
using Winform_ConsultaCEP.Services;

namespace Winform_ConsultaCEP
{
    public partial class ConsultadorCepIHM : Form
    {
        private readonly List<Endereco> Enderecos = new List<Endereco>();
        ConsultadorCep consultadorCep = new ConsultadorCep();
        public ConsultadorCepIHM()
        {
            InitializeComponent();
        }
        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                string cep = mskCEP.Text.Replace("-","");

                // Validando Entrada
                if (cep.Length != 8 || string.IsNullOrEmpty(cep) || string.IsNullOrWhiteSpace(cep) || !mskCEP.MaskCompleted)
                {
                    throw new Exception("Digite um Cep válido antes de prosseguir.");
                }

                // Validando se já foi cadastrado anteriormente
                if (Enderecos.Any(e => e.Cep!.Replace("-", "") == cep))
                {
                    throw new Exception("Cep já foi cadastrado anteriormente.");
                }

                // Feedback ao usuário referente ao status da requisição
                Application.UseWaitCursor = true;
                lvCep.Cursor = Cursors.WaitCursor;
                btnConsultar.Enabled = false;

                // Consulta e retorno do objeto / exceção
                var end = await consultadorCep.ConsultaCEP(cep);

                // Armazenamento e Visualização
                Enderecos.Add(end);
                lvCep.Items.Add(new ListViewItem([end.Cep, end.Logradouro, end.Bairro, end.Localidade, end.Uf]));
                MessageBox.Show($"Cep({end.Cep}) cadastrado com sucesso!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Default na aplicação para novas requisições
                btnConsultar.Enabled = true;
                Application.UseWaitCursor = false;
                lvCep.Cursor = Cursors.Default;
                mskCEP.Text = "";
                mskCEP.Focus();
            }

        }

        private void mskCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConsultar_Click(sender, e);
            }
        }
    }
}
