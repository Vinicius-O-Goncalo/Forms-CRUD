namespace CRUD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnInserir = new Button();
            btnListar = new Button();
            btnAtualizar = new Button();
            btnExcluir = new Button();
            txtId = new TextBox();
            txtDescricao = new TextBox();
            label1 = new Label();
            Descrição = new Label();
            dtpData = new DateTimePicker();
            dgvLancamentos = new DataGridView();
            cbTipo = new ComboBox();
            groupBox1 = new GroupBox();
            Valor = new Label();
            txtValor = new TextBox();
            label4 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLancamentos).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnInserir
            // 
            btnInserir.Location = new Point(119, 250);
            btnInserir.Name = "btnInserir";
            btnInserir.Size = new Size(75, 23);
            btnInserir.TabIndex = 0;
            btnInserir.Text = "Inserir";
            btnInserir.UseVisualStyleBackColor = true;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(241, 250);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(75, 23);
            btnListar.TabIndex = 1;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = true;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(362, 250);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(76, 23);
            btnAtualizar.TabIndex = 2;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(487, 250);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(33, 54);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 4;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(213, 54);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(124, 99);
            txtDescricao.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 27);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 6;
            label1.Text = "ID";
            // 
            // Descrição
            // 
            Descrição.AutoSize = true;
            Descrição.Location = new Point(213, 27);
            Descrição.Name = "Descrição";
            Descrição.Size = new Size(58, 15);
            Descrição.TabIndex = 7;
            Descrição.Text = "Descrição";
            // 
            // dtpData
            // 
            dtpData.Location = new Point(402, 54);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(200, 23);
            dtpData.TabIndex = 9;
            // 
            // dgvLancamentos
            // 
            dgvLancamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLancamentos.Location = new Point(213, 301);
            dgvLancamentos.Name = "dgvLancamentos";
            dgvLancamentos.Size = new Size(240, 150);
            dgvLancamentos.TabIndex = 10;
            // 
            // cbTipo
            // 
            cbTipo.FormattingEnabled = true;
            cbTipo.Location = new Point(33, 130);
            cbTipo.Name = "cbTipo";
            cbTipo.Size = new Size(121, 23);
            cbTipo.TabIndex = 11;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Valor);
            groupBox1.Controls.Add(txtValor);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtDescricao);
            groupBox1.Controls.Add(dgvLancamentos);
            groupBox1.Controls.Add(cbTipo);
            groupBox1.Controls.Add(dtpData);
            groupBox1.Controls.Add(txtId);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(Descrição);
            groupBox1.Controls.Add(btnInserir);
            groupBox1.Controls.Add(btnExcluir);
            groupBox1.Controls.Add(btnListar);
            groupBox1.Controls.Add(btnAtualizar);
            groupBox1.Location = new Point(48, 23);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(682, 471);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // Valor
            // 
            Valor.AutoSize = true;
            Valor.Location = new Point(407, 100);
            Valor.Name = "Valor";
            Valor.Size = new Size(33, 15);
            Valor.TabIndex = 15;
            Valor.Text = "Valor";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(408, 131);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(100, 23);
            txtValor.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 100);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 13;
            label4.Text = "Tipo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(402, 27);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 12;
            label2.Text = "Data";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 532);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvLancamentos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnInserir;
        private Button btnListar;
        private Button btnAtualizar;
        private Button btnExcluir;
        private TextBox txtId;
        private TextBox txtDescricao;
        private Label label1;
        private Label Descrição;
        private DateTimePicker dtpData;
        private DataGridView dgvLancamentos;
        private ComboBox cbTipo;
        private GroupBox groupBox1;
        private Label label2;
        private Label label4;
        private Label Valor;
        private TextBox txtValor;
    }
}
