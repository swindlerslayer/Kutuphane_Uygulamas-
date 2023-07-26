
namespace Kutuphane_Uygulaması
{
    partial class KitapTurEkleForm
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
            this.KitapTurEkleButton = new DevExpress.XtraEditors.SimpleButton();
            this.KitapTurGuncelleButton = new DevExpress.XtraEditors.SimpleButton();
            this.KitapTurSilButton = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(261, -1);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(491, 200);
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
            this.gridColumn2.Width = 35;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Adı";
            this.gridColumn1.FieldName = "Adi";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 777;
            // 
            // KitapTurEkleButton
            // 
            this.KitapTurEkleButton.Location = new System.Drawing.Point(28, 60);
            this.KitapTurEkleButton.Name = "KitapTurEkleButton";
            this.KitapTurEkleButton.Size = new System.Drawing.Size(205, 37);
            this.KitapTurEkleButton.TabIndex = 1;
            this.KitapTurEkleButton.Text = "Kitap Türü Ekle";
            this.KitapTurEkleButton.Click += new System.EventHandler(this.KitapTurEkleButton_Click);
            // 
            // KitapTurGuncelleButton
            // 
            this.KitapTurGuncelleButton.Location = new System.Drawing.Point(28, 108);
            this.KitapTurGuncelleButton.Name = "KitapTurGuncelleButton";
            this.KitapTurGuncelleButton.Size = new System.Drawing.Size(205, 37);
            this.KitapTurGuncelleButton.TabIndex = 2;
            this.KitapTurGuncelleButton.Text = "Kitap Türü Güncelle";
            this.KitapTurGuncelleButton.Click += new System.EventHandler(this.KitapTurGuncelleButton_Click);
            // 
            // KitapTurSilButton
            // 
            this.KitapTurSilButton.Location = new System.Drawing.Point(28, 153);
            this.KitapTurSilButton.Name = "KitapTurSilButton";
            this.KitapTurSilButton.Size = new System.Drawing.Size(205, 37);
            this.KitapTurSilButton.TabIndex = 3;
            this.KitapTurSilButton.Text = "Kitap Türü Sil";
            this.KitapTurSilButton.Click += new System.EventHandler(this.KitapTurSilButton_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(90, 12);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(156, 22);
            this.textEdit1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tür Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // KitapTurEkleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 196);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.KitapTurSilButton);
            this.Controls.Add(this.KitapTurGuncelleButton);
            this.Controls.Add(this.KitapTurEkleButton);
            this.Controls.Add(this.gridControl1);
            this.Name = "KitapTurEkleForm";
            this.Text = "KitapTurEkleForm";
            this.Load += new System.EventHandler(this.KitapTurEkleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton KitapTurEkleButton;
        private DevExpress.XtraEditors.SimpleButton KitapTurGuncelleButton;
        private DevExpress.XtraEditors.SimpleButton KitapTurSilButton;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Label label2;
    }
}