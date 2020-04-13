namespace proyectoFormacion
{
    partial class PantallaSuperUser
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
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listaUsuarios = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(375, 334);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 85);
            this.button3.TabIndex = 5;
            this.button3.Text = "Eliminar Usuarios";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(158, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 85);
            this.button1.TabIndex = 3;
            this.button1.Text = "Agregar Usuarios";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Usuarios ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listaUsuarios
            // 
            this.listaUsuarios.CheckOnClick = true;
            this.listaUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaUsuarios.FormattingEnabled = true;
            this.listaUsuarios.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listaUsuarios.Location = new System.Drawing.Point(60, 116);
            this.listaUsuarios.Name = "listaUsuarios";
            this.listaUsuarios.ScrollAlwaysVisible = true;
            this.listaUsuarios.Size = new System.Drawing.Size(603, 175);
            this.listaUsuarios.TabIndex = 7;
            // 
            // PantallaSuperUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 473);
            this.Controls.Add(this.listaUsuarios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Name = "PantallaSuperUser";
            this.Text = "PantallaSuperUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox listaUsuarios;
    }
}