namespace InterfazFruta
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.UrlText = new System.Windows.Forms.TextBox();
            this.URL = new System.Windows.Forms.TextBox();
            this.Body = new System.Windows.Forms.TextBox();
            this.Envio = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(524, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(78, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // UrlText
            // 
            this.UrlText.Location = new System.Drawing.Point(684, 57);
            this.UrlText.Multiline = true;
            this.UrlText.Name = "UrlText";
            this.UrlText.Size = new System.Drawing.Size(271, 27);
            this.UrlText.TabIndex = 1;
            // 
            // URL
            // 
            this.URL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.URL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.URL.Location = new System.Drawing.Point(632, 57);
            this.URL.Multiline = true;
            this.URL.Name = "URL";
            this.URL.ReadOnly = true;
            this.URL.Size = new System.Drawing.Size(46, 28);
            this.URL.TabIndex = 2;
            this.URL.Text = "URL";
            // 
            // Body
            // 
            this.Body.Location = new System.Drawing.Point(335, 198);
            this.Body.Multiline = true;
            this.Body.Name = "Body";
            this.Body.Size = new System.Drawing.Size(466, 293);
            this.Body.TabIndex = 3;
            // 
            // Envio
            // 
            this.Envio.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Envio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Envio.Location = new System.Drawing.Point(820, 169);
            this.Envio.Name = "Envio";
            this.Envio.Size = new System.Drawing.Size(88, 71);
            this.Envio.TabIndex = 4;
            this.Envio.Text = "SEND";
            this.Envio.UseVisualStyleBackColor = false;
            this.Envio.Click += new System.EventHandler(this.Envio_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::InterfazFruta.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(24, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 555);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Envio);
            this.Controls.Add(this.Body);
            this.Controls.Add(this.URL);
            this.Controls.Add(this.UrlText);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "AlmacenFruta";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox UrlText;
        private System.Windows.Forms.TextBox URL;
        private System.Windows.Forms.TextBox Body;
        private System.Windows.Forms.Button Envio;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

