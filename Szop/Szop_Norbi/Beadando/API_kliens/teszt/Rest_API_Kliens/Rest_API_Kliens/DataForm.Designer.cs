namespace Rest_API_Kliens
{
    partial class DataForm
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delete = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.price = new System.Windows.Forms.TextBox();
            this.adatok = new System.Windows.Forms.ListBox();
            this.logout = new System.Windows.Forms.Button();
            this.stock = new System.Windows.Forms.TextBox();
            this.labelforname = new System.Windows.Forms.Label();
            this.labelforprice = new System.Windows.Forms.Label();
            this.labelforstock = new System.Windows.Forms.Label();
            this.newProduct = new System.Windows.Forms.Button();
            this.productDelete = new System.Windows.Forms.Button();
            this.labelfordelete = new System.Windows.Forms.Label();
            this.labelfornewName = new System.Windows.Forms.Label();
            this.labelfornewPrice = new System.Windows.Forms.Label();
            this.labelfornewStock = new System.Windows.Forms.Label();
            this.newName = new System.Windows.Forms.TextBox();
            this.newPrice = new System.Windows.Forms.TextBox();
            this.newStock = new System.Windows.Forms.TextBox();
            this.update = new System.Windows.Forms.Button();
            this.productsFromDb = new System.Windows.Forms.Button();
            this.labelforNewProduct = new System.Windows.Forms.Label();
            this.laberforProductsById = new System.Windows.Forms.Label();
            this.productById = new System.Windows.Forms.TextBox();
            this.productFromDbByID = new System.Windows.Forms.Button();
            this.labelforUpdateID = new System.Windows.Forms.Label();
            this.updateID = new System.Windows.Forms.TextBox();
            this.labelforupdate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(160, 95);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(100, 20);
            this.delete.TabIndex = 5;
            this.delete.TextChanged += new System.EventHandler(this.delete_TextChanged);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(567, 95);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(197, 20);
            this.name.TabIndex = 6;
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(567, 125);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(197, 20);
            this.price.TabIndex = 7;
            // 
            // adatok
            // 
            this.adatok.FormattingEnabled = true;
            this.adatok.Location = new System.Drawing.Point(943, 107);
            this.adatok.Name = "adatok";
            this.adatok.Size = new System.Drawing.Size(359, 368);
            this.adatok.TabIndex = 8;
            this.adatok.SelectedIndexChanged += new System.EventHandler(this.adatok_SelectedIndexChanged);
            // 
            // logout
            // 
            this.logout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.logout.Location = new System.Drawing.Point(1209, 27);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(93, 23);
            this.logout.TabIndex = 9;
            this.logout.Text = "Kijelentkezés";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // stock
            // 
            this.stock.Location = new System.Drawing.Point(567, 151);
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(197, 20);
            this.stock.TabIndex = 10;
            // 
            // labelforname
            // 
            this.labelforname.AutoSize = true;
            this.labelforname.Location = new System.Drawing.Point(450, 98);
            this.labelforname.Name = "labelforname";
            this.labelforname.Size = new System.Drawing.Size(68, 13);
            this.labelforname.TabIndex = 11;
            this.labelforname.Text = "Megnevezés";
            // 
            // labelforprice
            // 
            this.labelforprice.AutoSize = true;
            this.labelforprice.Location = new System.Drawing.Point(450, 127);
            this.labelforprice.Name = "labelforprice";
            this.labelforprice.Size = new System.Drawing.Size(51, 13);
            this.labelforprice.TabIndex = 12;
            this.labelforprice.Text = "Egységár";
            // 
            // labelforstock
            // 
            this.labelforstock.AutoSize = true;
            this.labelforstock.Location = new System.Drawing.Point(450, 154);
            this.labelforstock.Name = "labelforstock";
            this.labelforstock.Size = new System.Drawing.Size(115, 13);
            this.labelforstock.TabIndex = 13;
            this.labelforstock.Text = "Készlet mennyiség (db)";
            // 
            // newProduct
            // 
            this.newProduct.Location = new System.Drawing.Point(567, 189);
            this.newProduct.Name = "newProduct";
            this.newProduct.Size = new System.Drawing.Size(197, 23);
            this.newProduct.TabIndex = 14;
            this.newProduct.Text = "Új termék rögzítése";
            this.newProduct.UseVisualStyleBackColor = true;
            this.newProduct.Click += new System.EventHandler(this.newProduct_Click);
            // 
            // productDelete
            // 
            this.productDelete.Location = new System.Drawing.Point(160, 121);
            this.productDelete.Name = "productDelete";
            this.productDelete.Size = new System.Drawing.Size(100, 23);
            this.productDelete.TabIndex = 15;
            this.productDelete.Text = "Termék törlése";
            this.productDelete.UseVisualStyleBackColor = true;
            this.productDelete.Click += new System.EventHandler(this.productDelete_Click);
            // 
            // labelfordelete
            // 
            this.labelfordelete.AutoSize = true;
            this.labelfordelete.Location = new System.Drawing.Point(12, 98);
            this.labelfordelete.Name = "labelfordelete";
            this.labelfordelete.Size = new System.Drawing.Size(83, 13);
            this.labelfordelete.TabIndex = 16;
            this.labelfordelete.Text = "ID alapján törlés";
            // 
            // labelfornewName
            // 
            this.labelfornewName.AutoSize = true;
            this.labelfornewName.Location = new System.Drawing.Point(71, 280);
            this.labelfornewName.Name = "labelfornewName";
            this.labelfornewName.Size = new System.Drawing.Size(80, 13);
            this.labelfornewName.TabIndex = 18;
            this.labelfornewName.Text = "Új megnevezés";
            // 
            // labelfornewPrice
            // 
            this.labelfornewPrice.AutoSize = true;
            this.labelfornewPrice.Location = new System.Drawing.Point(88, 315);
            this.labelfornewPrice.Name = "labelfornewPrice";
            this.labelfornewPrice.Size = new System.Drawing.Size(63, 13);
            this.labelfornewPrice.TabIndex = 19;
            this.labelfornewPrice.Text = "Új egységár";
            // 
            // labelfornewStock
            // 
            this.labelfornewStock.AutoSize = true;
            this.labelfornewStock.Location = new System.Drawing.Point(24, 350);
            this.labelfornewStock.Name = "labelfornewStock";
            this.labelfornewStock.Size = new System.Drawing.Size(127, 13);
            this.labelfornewStock.TabIndex = 20;
            this.labelfornewStock.Text = "Új készlet mennyiség (db)";
            // 
            // newName
            // 
            this.newName.Location = new System.Drawing.Point(160, 280);
            this.newName.Name = "newName";
            this.newName.Size = new System.Drawing.Size(158, 20);
            this.newName.TabIndex = 21;
            // 
            // newPrice
            // 
            this.newPrice.Location = new System.Drawing.Point(160, 312);
            this.newPrice.Name = "newPrice";
            this.newPrice.Size = new System.Drawing.Size(158, 20);
            this.newPrice.TabIndex = 22;
            // 
            // newStock
            // 
            this.newStock.Location = new System.Drawing.Point(160, 343);
            this.newStock.Name = "newStock";
            this.newStock.Size = new System.Drawing.Size(158, 20);
            this.newStock.TabIndex = 23;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(160, 378);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(158, 23);
            this.update.TabIndex = 24;
            this.update.Text = "Termék módosítása";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // productsFromDb
            // 
            this.productsFromDb.Location = new System.Drawing.Point(943, 493);
            this.productsFromDb.Name = "productsFromDb";
            this.productsFromDb.Size = new System.Drawing.Size(118, 23);
            this.productsFromDb.TabIndex = 25;
            this.productsFromDb.Text = "Termékek lekérése";
            this.productsFromDb.UseVisualStyleBackColor = true;
            this.productsFromDb.Click += new System.EventHandler(this.productsFromDb_Click);
            // 
            // labelforNewProduct
            // 
            this.labelforNewProduct.AutoSize = true;
            this.labelforNewProduct.Location = new System.Drawing.Point(567, 36);
            this.labelforNewProduct.Name = "labelforNewProduct";
            this.labelforNewProduct.Size = new System.Drawing.Size(112, 13);
            this.labelforNewProduct.TabIndex = 26;
            this.labelforNewProduct.Text = "Út jermék hozzáadása";
            // 
            // laberforProductsById
            // 
            this.laberforProductsById.AutoSize = true;
            this.laberforProductsById.Location = new System.Drawing.Point(434, 280);
            this.laberforProductsById.Name = "laberforProductsById";
            this.laberforProductsById.Size = new System.Drawing.Size(131, 13);
            this.laberforProductsById.TabIndex = 27;
            this.laberforProductsById.Text = "Termék lekérés ID alapján";
            // 
            // productById
            // 
            this.productById.Location = new System.Drawing.Point(567, 280);
            this.productById.Name = "productById";
            this.productById.Size = new System.Drawing.Size(100, 20);
            this.productById.TabIndex = 28;
            this.productById.TextChanged += new System.EventHandler(this.productById_TextChanged);
            // 
            // productFromDbByID
            // 
            this.productFromDbByID.Location = new System.Drawing.Point(567, 343);
            this.productFromDbByID.Name = "productFromDbByID";
            this.productFromDbByID.Size = new System.Drawing.Size(100, 23);
            this.productFromDbByID.TabIndex = 29;
            this.productFromDbByID.Text = "Termék lekérése";
            this.productFromDbByID.UseVisualStyleBackColor = true;
            this.productFromDbByID.Click += new System.EventHandler(this.productFromDbByID_Click);
            // 
            // labelforUpdateID
            // 
            this.labelforUpdateID.AutoSize = true;
            this.labelforUpdateID.Location = new System.Drawing.Point(10, 250);
            this.labelforUpdateID.Name = "labelforUpdateID";
            this.labelforUpdateID.Size = new System.Drawing.Size(141, 13);
            this.labelforUpdateID.TabIndex = 30;
            this.labelforUpdateID.Text = "Módosítani kivánt termék ID";
            // 
            // updateID
            // 
            this.updateID.Location = new System.Drawing.Point(160, 247);
            this.updateID.Name = "updateID";
            this.updateID.Size = new System.Drawing.Size(158, 20);
            this.updateID.TabIndex = 31;
            // 
            // labelforupdate
            // 
            this.labelforupdate.AutoSize = true;
            this.labelforupdate.Location = new System.Drawing.Point(12, 215);
            this.labelforupdate.Name = "labelforupdate";
            this.labelforupdate.Size = new System.Drawing.Size(152, 13);
            this.labelforupdate.TabIndex = 17;
            this.labelforupdate.Text = "Termék módosítása ID alapján";
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 538);
            this.Controls.Add(this.updateID);
            this.Controls.Add(this.labelforUpdateID);
            this.Controls.Add(this.productFromDbByID);
            this.Controls.Add(this.productById);
            this.Controls.Add(this.laberforProductsById);
            this.Controls.Add(this.labelforNewProduct);
            this.Controls.Add(this.productsFromDb);
            this.Controls.Add(this.update);
            this.Controls.Add(this.newStock);
            this.Controls.Add(this.newPrice);
            this.Controls.Add(this.newName);
            this.Controls.Add(this.labelfornewStock);
            this.Controls.Add(this.labelfornewPrice);
            this.Controls.Add(this.labelfornewName);
            this.Controls.Add(this.labelforupdate);
            this.Controls.Add(this.labelfordelete);
            this.Controls.Add(this.productDelete);
            this.Controls.Add(this.newProduct);
            this.Controls.Add(this.labelforstock);
            this.Controls.Add(this.labelforprice);
            this.Controls.Add(this.labelforname);
            this.Controls.Add(this.stock);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.adatok);
            this.Controls.Add(this.price);
            this.Controls.Add(this.name);
            this.Controls.Add(this.delete);
            this.Name = "DataForm";
            this.Text = "Adatbázis";
            this.Load += new System.EventHandler(this.DataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox delete;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.ListBox adatok;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.TextBox stock;
        private System.Windows.Forms.Label labelforname;
        private System.Windows.Forms.Label labelforprice;
        private System.Windows.Forms.Label labelforstock;
        private System.Windows.Forms.Button newProduct;
        private System.Windows.Forms.Button productDelete;
        private System.Windows.Forms.Label labelfordelete;
        private System.Windows.Forms.Label labelfornewName;
        private System.Windows.Forms.Label labelfornewPrice;
        private System.Windows.Forms.Label labelfornewStock;
        private System.Windows.Forms.TextBox newName;
        private System.Windows.Forms.TextBox newPrice;
        private System.Windows.Forms.TextBox newStock;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button productsFromDb;
        private System.Windows.Forms.Label labelforNewProduct;
        private System.Windows.Forms.Label laberforProductsById;
        private System.Windows.Forms.TextBox productById;
        private System.Windows.Forms.Button productFromDbByID;
        private System.Windows.Forms.Label labelforUpdateID;
        private System.Windows.Forms.TextBox updateID;
        private System.Windows.Forms.Label labelforupdate;
    }
}