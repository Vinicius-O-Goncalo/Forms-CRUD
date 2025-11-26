using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        // Inicializa a connectionString usada nos métodos do Form1
        private string connectionString = "Data Source=localhost;Initial Catalog=FinanceiroDB;User ID=usuario;Password=senha;Language=Portuguese;TrustServerCertificate=True;";

        // BindingSource para facilitar atualização do DataGridView
        private BindingSource lancamentosBinding = new BindingSource();

        // Conexão 
        internal class Banco
        {
            // Fonte de dados
            private string stringConnection = "Data Source=localhost;Initial Catalog=FinanceiroDB;User ID=usuario;Password=senha;Language=Portuguese;TrustServerCertificate=True;";

            private SqlConnection cn;
            public SqlConnection Cn { get => cn; set => cn = value; }

            private void Connection()
            {
                cn = new SqlConnection(stringConnection);
            }

            public SqlConnection openConnection()
            {
                try
                {
                    Connection();
                    cn.Open();

                    return cn;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public void closeConnection()
            {
                try
                {
                    cn.Close();
                }
                catch (Exception)
                {
                }
            }

            public DataTable executeQuery(string sql)
            {
                try
                {
                    openConnection();

                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    return dt;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    closeConnection();
                }
            }
        }

        public Form1()
        {
            InitializeComponent();

            // Ligar handlers aos controles criados pelo Designer
            btnInserir.Click += btnInserir_Click;
            btnListar.Click += btnListar_Click;
            btnAtualizar.Click += btnAtualizar_Click;
            btnExcluir.Click += btnExcluir_Click;
            dgvLancamentos.CellClick += dgvLancamentos_CellClick;

            // Habilitar o combobox se estiver desabilitado no Designer
            cbTipo.Enabled = true;

            // Configurar BindingSource e mapeamento das colunas para atualizar automaticamente
            // Garantir que as colunas já existam (InitializeComponent cria as colunas)
            dgvLancamentos.AutoGenerateColumns = false;
            try
            {
                // Mapear as colunas do DataTable para as colunas do DataGridView
                if (dgvLancamentos.Columns["ID"] != null) dgvLancamentos.Columns["ID"].DataPropertyName = "Id";
                if (dgvLancamentos.Columns["Descricao"] != null) dgvLancamentos.Columns["Descricao"].DataPropertyName = "Descricao";
                if (dgvLancamentos.Columns["Column1"] != null) dgvLancamentos.Columns["Column1"].DataPropertyName = "Valor";
                if (dgvLancamentos.Columns["Column2"] != null) dgvLancamentos.Columns["Column2"].DataPropertyName = "DataLancamento";
                if (dgvLancamentos.Columns["Column3"] != null) dgvLancamentos.Columns["Column3"].DataPropertyName = "Tipo";
            }
            catch {  }

            // Usar BindingSource como ponte entre DataTable e DataGridView
            dgvLancamentos.DataSource = lancamentosBinding;

        }

        //  CLASSE DE OBJETO: Lançamento
        public class Lancamento
        {
            public int Id { get; set; }
            public string Descricao { get; set; }
            public decimal Valor { get; set; }
            public DateTime Data { get; set; }
            public string Tipo { get; set; } // Entrada / Saida
        }

        // BOTÃO: INSERIR
        private void btnInserir_Click(object sender, EventArgs e)
        {
            // Validações básicas
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("Informe a descrição.");
                txtDescricao.Focus();
                return;
            }

            if (!decimal.TryParse(txtValor.Text, out decimal valor))
            {
                MessageBox.Show("Valor inválido.");
                txtValor.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cbTipo.Text))
            {
                MessageBox.Show("Informe o tipo (Entrada ou Saida).");
                cbTipo.Focus();
                return;
            }

            Lancamento l = new Lancamento()
            {
                Descricao = txtDescricao.Text.Trim(),
                Valor = valor,
                Data = dtpData.Value,
                // usar Text evita null quando SelectedItem for null
                Tipo = cbTipo.Text.Trim()
            };

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql =
                    "INSERT INTO Lancamentos (Descricao, Valor, DataLancamento, Tipo) " +
                    "VALUES (@Descricao, @Valor, @Data, @Tipo)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Descricao", l.Descricao);
                cmd.Parameters.AddWithValue("@Valor", l.Valor);
                cmd.Parameters.AddWithValue("@Data", l.Data);
                cmd.Parameters.AddWithValue("@Tipo", l.Tipo);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Lançamento inserido com sucesso!");
            CarregarGrid(); // garante que o BindingSource receba o DataTable atualizado
        }

        // BOTÃO: LISTAR / CONSULTAR
        private void btnListar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Lancamentos";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Atualiza o BindingSource: DataGridView atualiza automaticamente
                lancamentosBinding.DataSource = dt;
            }
        }

        // BOTÃO: ATUALIZAR
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Id inválido.");
                txtId.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("Informe a descrição.");
                txtDescricao.Focus();
                return;
            }

            if (!decimal.TryParse(txtValor.Text, out decimal valor))
            {
                MessageBox.Show("Valor inválido.");
                txtValor.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cbTipo.Text))
            {
                MessageBox.Show("Informe o tipo (Entrada ou Saida).");
                cbTipo.Focus();
                return;
            }

            Lancamento l = new Lancamento()
            {
                Id = id,
                Descricao = txtDescricao.Text.Trim(),
                Valor = valor,
                Data = dtpData.Value,
                Tipo = cbTipo.Text.Trim()
            };

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql =
                    "UPDATE Lancamentos SET Descricao=@D, Valor=@V, DataLancamento=@Data, Tipo=@T " +
                    "WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@D", l.Descricao);
                cmd.Parameters.AddWithValue("@V", l.Valor);
                cmd.Parameters.AddWithValue("@Data", l.Data);
                cmd.Parameters.AddWithValue("@T", l.Tipo);
                cmd.Parameters.AddWithValue("@Id", l.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Lançamento atualizado!");
            CarregarGrid();
        }
        // BOTÃO: EXCLUIR
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Id inválido.");
                txtId.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Lancamentos WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Lançamento excluído!");
            CarregarGrid();
        }

        // AO CLICAR EM UMA LINHA DO GRID – CARREGA NOS TEXTBOXES
        private void dgvLancamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                object idObj = dgvLancamentos.Rows[e.RowIndex].Cells["Id"].Value;
                object descObj = dgvLancamentos.Rows[e.RowIndex].Cells["Descricao"].Value;
                object valorObj = dgvLancamentos.Rows[e.RowIndex].Cells["Column1"].Value;
                object dataObj = dgvLancamentos.Rows[e.RowIndex].Cells["Column2"].Value;
                object tipoObj = dgvLancamentos.Rows[e.RowIndex].Cells["Column3"].Value;

                txtId.Text = idObj == null || idObj == DBNull.Value ? string.Empty : idObj.ToString();
                txtDescricao.Text = descObj == null || descObj == DBNull.Value ? string.Empty : descObj.ToString();
                txtValor.Text = valorObj == null || valorObj == DBNull.Value ? string.Empty : valorObj.ToString();

                if (dataObj == null || dataObj == DBNull.Value)
                    dtpData.Value = DateTime.Today;
                else
                    dtpData.Value = Convert.ToDateTime(dataObj);

                // usar Text porque SelectedItem pode ser null
                cbTipo.Text = tipoObj == null || tipoObj == DBNull.Value ? string.Empty : tipoObj.ToString();
            }
        }
    }
}
