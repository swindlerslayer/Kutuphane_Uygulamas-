
namespace Kutuphane_Uygulaması
{
    partial class YayineviEkleForm
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
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.YayineviEkleButton = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YayineviGuncelleButton = new DevExpress.XtraEditors.SimpleButton();
            this.YayineviSilButton = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(117, 22);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(130, 22);
            this.textEdit1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Yayınevi Adı ";
            // 
            // YayineviEkleButton
            // 
            this.YayineviEkleButton.Location = new System.Drawing.Point(12, 59);
            this.YayineviEkleButton.Name = "YayineviEkleButton";
            this.YayineviEkleButton.Size = new System.Drawing.Size(235, 46);
            this.YayineviEkleButton.TabIndex = 2;
            this.YayineviEkleButton.Text = "Yayınevi Ekle ";
            this.YayineviEkleButton.Click += new System.EventHandler(this.YayineviEkleButton_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(262, -6);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(491, 228);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Adı";
            this.gridColumn1.FieldName = "Adi";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 780;
            // 
            // YayineviGuncelleButton
            // 
            this.YayineviGuncelleButton.Location = new System.Drawing.Point(12, 111);
            this.YayineviGuncelleButton.Name = "YayineviGuncelleButton";
            this.YayineviGuncelleButton.Size = new System.Drawing.Size(235, 46);
            this.YayineviGuncelleButton.TabIndex = 4;
            this.YayineviGuncelleButton.Text = "Yayınevi Güncelle ";
            this.YayineviGuncelleButton.Click += new System.EventHandler(this.YayineviGuncelleButton_Click);
            // 
            // YayineviSilButton
            // 
            this.YayineviSilButton.Location = new System.Drawing.Point(12, 163);
            this.YayineviSilButton.Name = "YayineviSilButton";
            this.YayineviSilButton.Size = new System.Drawing.Size(235, 46);
            this.YayineviSilButton.TabIndex = 5;
            this.YayineviSilButton.Text = "Yayınevi Sil";
            this.YayineviSilButton.Click += new System.EventHandler(this.YayineviSilButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "ID";
            this.gridColumn2.FieldName = "ID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 32;
            // 
            // YayineviEkleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 221);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.YayineviSilButton);
            this.Controls.Add(this.YayineviGuncelleButton);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.YayineviEkleButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "YayineviEkleForm";
            this.Text = "YayineviEkleForm";
            this.Load += new System.EventHandler(this.YayineviEkleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton YayineviEkleButton;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton YayineviGuncelleButton;
        private DevExpress.XtraEditors.SimpleButton YayineviSilButton;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}