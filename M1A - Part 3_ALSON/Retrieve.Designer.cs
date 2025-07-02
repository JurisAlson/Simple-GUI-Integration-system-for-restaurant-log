namespace M1A___Part_3_ALSON
{
    partial class Retrieve
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
            this.dataGridViewCustomer = new System.Windows.Forms.DataGridView();
            this.ProductDataGridView = new System.Windows.Forms.DataGridView();
            this.OrderDataGridView = new System.Windows.Forms.DataGridView();
            this.OrderItemDataGridView = new System.Windows.Forms.DataGridView();
            this.PaymentDataGridView = new System.Windows.Forms.DataGridView();
            this.EXIT = new System.Windows.Forms.Button();
            this.UPDATE = new System.Windows.Forms.Button();
            this.INSERT = new System.Windows.Forms.Button();
            this.DELETE = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderItemDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCustomer
            // 
            this.dataGridViewCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomer.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewCustomer.Name = "dataGridViewCustomer";
            this.dataGridViewCustomer.Size = new System.Drawing.Size(240, 437);
            this.dataGridViewCustomer.TabIndex = 0;
            // 
            // ProductDataGridView
            // 
            this.ProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDataGridView.Location = new System.Drawing.Point(286, 12);
            this.ProductDataGridView.Name = "ProductDataGridView";
            this.ProductDataGridView.Size = new System.Drawing.Size(240, 437);
            this.ProductDataGridView.TabIndex = 1;
            // 
            // OrderDataGridView
            // 
            this.OrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderDataGridView.Location = new System.Drawing.Point(591, 12);
            this.OrderDataGridView.Name = "OrderDataGridView";
            this.OrderDataGridView.Size = new System.Drawing.Size(240, 437);
            this.OrderDataGridView.TabIndex = 2;
            // 
            // OrderItemDataGridView
            // 
            this.OrderItemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderItemDataGridView.Location = new System.Drawing.Point(12, 464);
            this.OrderItemDataGridView.Name = "OrderItemDataGridView";
            this.OrderItemDataGridView.Size = new System.Drawing.Size(240, 437);
            this.OrderItemDataGridView.TabIndex = 3;
            // 
            // PaymentDataGridView
            // 
            this.PaymentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PaymentDataGridView.Location = new System.Drawing.Point(286, 464);
            this.PaymentDataGridView.Name = "PaymentDataGridView";
            this.PaymentDataGridView.Size = new System.Drawing.Size(240, 437);
            this.PaymentDataGridView.TabIndex = 4;
            // 
            // EXIT
            // 
            this.EXIT.Location = new System.Drawing.Point(591, 625);
            this.EXIT.Name = "EXIT";
            this.EXIT.Size = new System.Drawing.Size(126, 23);
            this.EXIT.TabIndex = 81;
            this.EXIT.Text = "EXIT";
            this.EXIT.UseVisualStyleBackColor = true;
            // 
            // UPDATE
            // 
            this.UPDATE.Location = new System.Drawing.Point(591, 584);
            this.UPDATE.Name = "UPDATE";
            this.UPDATE.Size = new System.Drawing.Size(126, 23);
            this.UPDATE.TabIndex = 80;
            this.UPDATE.Text = "UPDATE";
            this.UPDATE.UseVisualStyleBackColor = true;
            // 
            // INSERT
            // 
            this.INSERT.Location = new System.Drawing.Point(591, 534);
            this.INSERT.Name = "INSERT";
            this.INSERT.Size = new System.Drawing.Size(126, 23);
            this.INSERT.TabIndex = 79;
            this.INSERT.Text = "INSERT";
            this.INSERT.UseVisualStyleBackColor = true;
            // 
            // DELETE
            // 
            this.DELETE.Location = new System.Drawing.Point(591, 485);
            this.DELETE.Name = "DELETE";
            this.DELETE.Size = new System.Drawing.Size(126, 23);
            this.DELETE.TabIndex = 78;
            this.DELETE.Text = "DELETE";
            this.DELETE.UseVisualStyleBackColor = true;
            // 
            // Retrieve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 925);
            this.Controls.Add(this.EXIT);
            this.Controls.Add(this.UPDATE);
            this.Controls.Add(this.INSERT);
            this.Controls.Add(this.DELETE);
            this.Controls.Add(this.PaymentDataGridView);
            this.Controls.Add(this.OrderItemDataGridView);
            this.Controls.Add(this.OrderDataGridView);
            this.Controls.Add(this.ProductDataGridView);
            this.Controls.Add(this.dataGridViewCustomer);
            this.Name = "Retrieve";
            this.Text = "Retrieve";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderItemDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCustomer;
        private System.Windows.Forms.DataGridView ProductDataGridView;
        private System.Windows.Forms.DataGridView OrderDataGridView;
        private System.Windows.Forms.DataGridView OrderItemDataGridView;
        private System.Windows.Forms.DataGridView PaymentDataGridView;
        private System.Windows.Forms.Button EXIT;
        private System.Windows.Forms.Button UPDATE;
        private System.Windows.Forms.Button INSERT;
        private System.Windows.Forms.Button DELETE;
    }
}