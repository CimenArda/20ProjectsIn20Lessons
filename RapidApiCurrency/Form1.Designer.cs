namespace RapidApiCurrency
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbldolar = new System.Windows.Forms.Label();
            this.lbleuro = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtunitprice = new System.Windows.Forms.TextBox();
            this.rdrDolar = new System.Windows.Forms.RadioButton();
            this.rdrEuro = new System.Windows.Forms.RadioButton();
            this.rdrsterlin = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.txttotalprice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblpound = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbldolar
            // 
            this.lbldolar.AutoSize = true;
            this.lbldolar.Location = new System.Drawing.Point(65, 57);
            this.lbldolar.Name = "lbldolar";
            this.lbldolar.Size = new System.Drawing.Size(44, 16);
            this.lbldolar.TabIndex = 0;
            this.lbldolar.Text = "label1";
            // 
            // lbleuro
            // 
            this.lbleuro.AutoSize = true;
            this.lbleuro.Location = new System.Drawing.Point(181, 57);
            this.lbleuro.Name = "lbleuro";
            this.lbleuro.Size = new System.Drawing.Size(44, 16);
            this.lbleuro.TabIndex = 2;
            this.lbleuro.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Birim Tutar:";
            // 
            // txtunitprice
            // 
            this.txtunitprice.Location = new System.Drawing.Point(184, 140);
            this.txtunitprice.Name = "txtunitprice";
            this.txtunitprice.Size = new System.Drawing.Size(141, 22);
            this.txtunitprice.TabIndex = 5;
            // 
            // rdrDolar
            // 
            this.rdrDolar.AutoSize = true;
            this.rdrDolar.Location = new System.Drawing.Point(48, 100);
            this.rdrDolar.Name = "rdrDolar";
            this.rdrDolar.Size = new System.Drawing.Size(61, 20);
            this.rdrDolar.TabIndex = 6;
            this.rdrDolar.TabStop = true;
            this.rdrDolar.Text = "Dolar";
            this.rdrDolar.UseVisualStyleBackColor = true;
            // 
            // rdrEuro
            // 
            this.rdrEuro.AutoSize = true;
            this.rdrEuro.Location = new System.Drawing.Point(157, 100);
            this.rdrEuro.Name = "rdrEuro";
            this.rdrEuro.Size = new System.Drawing.Size(56, 20);
            this.rdrEuro.TabIndex = 7;
            this.rdrEuro.TabStop = true;
            this.rdrEuro.Text = "Euro";
            this.rdrEuro.UseVisualStyleBackColor = true;
            // 
            // rdrsterlin
            // 
            this.rdrsterlin.AutoSize = true;
            this.rdrsterlin.Location = new System.Drawing.Point(280, 100);
            this.rdrsterlin.Name = "rdrsterlin";
            this.rdrsterlin.Size = new System.Drawing.Size(81, 25);
            this.rdrsterlin.TabIndex = 8;
            this.rdrsterlin.TabStop = true;
            this.rdrsterlin.Text = "Sterlin";
            this.rdrsterlin.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 25);
            this.button1.TabIndex = 9;
            this.button1.Text = "İşlemi Yap";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txttotalprice
            // 
            this.txttotalprice.Location = new System.Drawing.Point(184, 179);
            this.txttotalprice.Name = "txttotalprice";
            this.txttotalprice.Size = new System.Drawing.Size(141, 22);
            this.txttotalprice.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ödenecek Tutar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "DOLAR";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "EURO";
            // 
            // lblpound
            // 
            this.lblpound.AutoSize = true;
            this.lblpound.Location = new System.Drawing.Point(281, 57);
            this.lblpound.Name = "lblpound";
            this.lblpound.Size = new System.Drawing.Size(44, 16);
            this.lblpound.TabIndex = 14;
            this.lblpound.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "STERLİN";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 355);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblpound);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txttotalprice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rdrsterlin);
            this.Controls.Add(this.rdrEuro);
            this.Controls.Add(this.rdrDolar);
            this.Controls.Add(this.txtunitprice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbleuro);
            this.Controls.Add(this.lbldolar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbldolar;
        private System.Windows.Forms.Label lbleuro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtunitprice;
        private System.Windows.Forms.RadioButton rdrDolar;
        private System.Windows.Forms.RadioButton rdrEuro;
        private System.Windows.Forms.RadioButton rdrsterlin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txttotalprice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblpound;
        private System.Windows.Forms.Label label5;
    }
}

