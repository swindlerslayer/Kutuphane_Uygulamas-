
namespace Kutuphane_Uygulaması
{
    partial class YazarEkleForm
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.YazarEkleButton = new DevExpress.XtraEditors.SimpleButton();
            this.YazarGuncelleButton = new DevExpress.XtraEditors.SimpleButton();
            this.YazarSilButton = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(261, -2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(491, 209);
            this.gridControl1.TabIndex = 0;
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
            // gridColumn2
            // 
            this.gridColumn2.Caption = "ID";
            this.gridColumn2.FieldName = "ID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 28;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "AdıSoyadı";
            this.gridColumn1.FieldName = "AdiSoyadi";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 784;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(112, 12);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(133, 22);
            this.textEdit1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Yazar İsmi";
            // 
            // YazarEkleButton
            // 
            this.YazarEkleButton.Location = new System.Drawing.Point(12, 51);
            this.YazarEkleButton.Name = "YazarEkleButton";
            this.YazarEkleButton.Size = new System.Drawing.Size(233, 44);
            this.YazarEkleButton.TabIndex = 3;
            this.YazarEkleButton.Text = "Yazar Ekle ";
            this.YazarEkleButton.Click += new System.EventHandler(this.YazarEkleButton_Click);
            // 
            // YazarGuncelleButton
            // 
            this.YazarGuncelleButton.Location = new System.Drawing.Point(12, 101);
            this.YazarGuncelleButton.Name = "YazarGuncelleButton";
            this.YazarGuncelleButton.Size = new System.Drawing.Size(233, 44);
            this.YazarGuncelleButton.TabIndex = 4;
            this.YazarGuncelleButton.Text = "Yazar Güncelle";
            this.YazarGuncelleButton.Click += new System.EventHandler(this.YazarGuncelleButton_Click);
            // 
            // YazarSilButton
            // 
            this.YazarSilButton.Location = new System.Drawing.Point(12, 151);
            this.YazarSilButton.Name = "YazarSilButton";
            this.YazarSilButton.Size = new System.Drawing.Size(233, 44);
            this.YazarSilButton.TabIndex = 5;
            this.YazarSilButton.Text = "Yazar Sil";
            this.YazarSilButton.Click += new System.EventHandler(this.YazarSilButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // YazarEkleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 196);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.YazarSilButton);
            this.Controls.Add(this.YazarGuncelleButton);
            this.Controls.Add(this.YazarEkleButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "YazarEkleForm";
            this.Text = "YazarEkleForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton YazarEkleButton;
        private DevExpress.XtraEditors.SimpleButton YazarGuncelleButton;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton YazarSilButton;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Label label2;
    }
}