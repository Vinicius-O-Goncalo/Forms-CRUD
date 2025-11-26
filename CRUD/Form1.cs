using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        // String de conexão – 
        private string connectionString =
            "Server=localhost;Database=ClientesDB;Trusted_Connection=True;";

        public Form1()
        {
            InitializeComponent();
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
            Lancamento l = new Lancamento()
            {
                Descricao = txtDescricao.Text,
                Valor = decimal.Parse(txtValor.Text),
                Data = dtpData.Value,
                Tipo = cbTipo.SelectedItem.ToString()
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
            CarregarGrid();
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
                dgvLancamentos.DataSource = dt;
            }
        }

        // BOTÃO: ATUALIZAR
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Lancamento l = new Lancamento()
            {
                Id = int.Parse(txtId.Text),
                Descricao = txtDescricao.Text,
                Valor = decimal.Parse(txtValor.Text),
                Data = dtpData.Value,
                Tipo = cbTipo.SelectedItem.ToString()
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
            int id = int.Parse(txtId.Text);

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
                txtId.Text = dgvLancamentos.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtDescricao.Text = dgvLancamentos.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
                txtValor.Text = dgvLancamentos.Rows[e.RowIndex].Cells["Valor"].Value.ToString();
                dtpData.Value = Convert.ToDateTime(dgvLancamentos.Rows[e.RowIndex].Cells["DataLancamento"].Value);
                cbTipo.Text = dgvLancamentos.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();
            }
        }

       
    }
}
