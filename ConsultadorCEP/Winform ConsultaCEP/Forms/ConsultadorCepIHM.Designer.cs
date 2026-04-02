namespace Winform_ConsultaCEP
{
    partial class ConsultadorCepIHM
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
            lvCep = new ListView();
            Cep = new ColumnHeader();
            Logradouro = new ColumnHeader();
            Bairro = new ColumnHeader();
            Cidade = new ColumnHeader();
            Uf = new ColumnHeader();
            lblCEP = new Label();
            btnConsultar = new Button();
            label1 = new Label();
            mskCEP = new MaskedTextBox();
            SuspendLayout();
            // 
            // lvCep
            // 
            lvCep.Columns.AddRange(new ColumnHeader[] { Cep, Logradouro, Bairro, Cidade, Uf });
            lvCep.Location = new Point(24, 94);
            lvCep.Name = "lvCep";
            lvCep.Size = new Size(690, 141);
            lvCep.TabIndex = 0;
            lvCep.UseCompatibleStateImageBehavior = false;
            lvCep.View = View.Details;
            // 
            // Cep
            // 
            Cep.Text = "Cep";
            Cep.Width = 65;
            // 
            // Logradouro
            // 
            Logradouro.Text = "Logradouro";
            Logradouro.Width = 250;
            // 
            // Bairro
            // 
            Bairro.Text = "Bairro";
            Bairro.Width = 170;
            // 
            // Cidade
            // 
            Cidade.Text = "Cidade";
            Cidade.Width = 150;
            // 
            // Uf
            // 
            Uf.Text = "Uf";
            Uf.Width = 50;
            // 
            // lblCEP
            // 
            lblCEP.AutoSize = true;
            lblCEP.Font = new Font("Segoe UI", 13F);
            lblCEP.Location = new Point(487, 18);
            lblCEP.Name = "lblCEP";
            lblCEP.Size = new Size(42, 25);
            lblCEP.TabIndex = 1;
            lblCEP.Text = "CEP";
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.Gray;
            btnConsultar.BackgroundImageLayout = ImageLayout.None;
            btnConsultar.Cursor = Cursors.Hand;
            btnConsultar.Font = new Font("Segoe UI", 12F);
            btnConsultar.ForeColor = SystemColors.ButtonFace;
            btnConsultar.Location = new Point(610, 18);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(104, 59);
            btnConsultar.TabIndex = 2;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = false;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Italic);
            label1.Location = new Point(24, 18);
            label1.Name = "label1";
            label1.Size = new Size(202, 30);
            label1.TabIndex = 4;
            label1.Text = "Consultador de CEP";
            // 
            // mskCEP
            // 
            mskCEP.Font = new Font("Segoe UI", 13F);
            mskCEP.Location = new Point(487, 46);
            mskCEP.Margin = new Padding(3, 2, 3, 2);
            mskCEP.Mask = "00000-000";
            mskCEP.Name = "mskCEP";
            mskCEP.Size = new Size(106, 31);
            mskCEP.TabIndex = 5;
            mskCEP.KeyDown += mskCEP_KeyDown;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 258);
            Controls.Add(mskCEP);
            Controls.Add(label1);
            Controls.Add(btnConsultar);
            Controls.Add(lblCEP);
            Controls.Add(lvCep);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvCep;
        private Label lblCEP;
        private Button btnConsultar;
        private Label label1;
        private MaskedTextBox mskCEP;
        private ColumnHeader Cep;
        private ColumnHeader Logradouro;
        private ColumnHeader Bairro;
        private ColumnHeader Cidade;
        private ColumnHeader Uf;
    }
}
