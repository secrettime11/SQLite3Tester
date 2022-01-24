namespace SQLite3Tester
{
    partial class IndexForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_apartment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Drop = new System.Windows.Forms.Button();
            this.cb_table = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Location = new System.Drawing.Point(91, 12);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.RowTemplate.Height = 24;
            this.dgv_data.Size = new System.Drawing.Size(335, 319);
            this.dgv_data.TabIndex = 0;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(10, 12);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 1;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(10, 44);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "id";
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(10, 150);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(75, 22);
            this.txt_id.TabIndex = 4;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(10, 190);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(75, 22);
            this.txt_name.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "name";
            // 
            // txt_apartment
            // 
            this.txt_apartment.Location = new System.Drawing.Point(10, 230);
            this.txt_apartment.Name = "txt_apartment";
            this.txt_apartment.Size = new System.Drawing.Size(75, 22);
            this.txt_apartment.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "apartment";
            // 
            // btn_Drop
            // 
            this.btn_Drop.Location = new System.Drawing.Point(10, 74);
            this.btn_Drop.Name = "btn_Drop";
            this.btn_Drop.Size = new System.Drawing.Size(75, 23);
            this.btn_Drop.TabIndex = 9;
            this.btn_Drop.Text = "Drop";
            this.btn_Drop.UseVisualStyleBackColor = true;
            this.btn_Drop.Click += new System.EventHandler(this.btn_Drop_Click);
            // 
            // cb_table
            // 
            this.cb_table.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_table.FormattingEnabled = true;
            this.cb_table.Location = new System.Drawing.Point(10, 107);
            this.cb_table.Name = "cb_table";
            this.cb_table.Size = new System.Drawing.Size(75, 20);
            this.cb_table.TabIndex = 10;
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 343);
            this.Controls.Add(this.cb_table);
            this.Controls.Add(this.btn_Drop);
            this.Controls.Add(this.txt_apartment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.dgv_data);
            this.Name = "IndexForm";
            this.Text = "SQLite";
            this.Load += new System.EventHandler(this.IndexForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_apartment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Drop;
        private System.Windows.Forms.ComboBox cb_table;
    }
}

