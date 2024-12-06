namespace Open_API_Kliens
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
            this.logout = new System.Windows.Forms.Button();
            this.adatok = new System.Windows.Forms.ListBox();
            this.carsFromDb = new System.Windows.Forms.Button();
            this.labelForCarById = new System.Windows.Forms.Label();
            this.carFromDbById = new System.Windows.Forms.Button();
            this.labelForNewCar = new System.Windows.Forms.Label();
            this.labelForNewBrand = new System.Windows.Forms.Label();
            this.labelForNewVin = new System.Windows.Forms.Label();
            this.labelForNewColor = new System.Windows.Forms.Label();
            this.labelForNewModelYear = new System.Windows.Forms.Label();
            this.labelForNewNumOfCylinders = new System.Windows.Forms.Label();
            this.labelForNewEngineDisplacement = new System.Windows.Forms.Label();
            this.labelForNewFuel = new System.Windows.Forms.Label();
            this.newBrand = new System.Windows.Forms.TextBox();
            this.newVin = new System.Windows.Forms.TextBox();
            this.newColor = new System.Windows.Forms.TextBox();
            this.newModelYear = new System.Windows.Forms.TextBox();
            this.newNumOfCylinders = new System.Windows.Forms.TextBox();
            this.newEngingeDisplacement = new System.Windows.Forms.TextBox();
            this.newFuel = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.carById = new System.Windows.Forms.ComboBox();
            this.newCar = new System.Windows.Forms.Button();
            this.clearAdatok = new System.Windows.Forms.Button();
            this.labelForUpdBrand = new System.Windows.Forms.Label();
            this.labelForUpdVin = new System.Windows.Forms.Label();
            this.labelForUpdColor = new System.Windows.Forms.Label();
            this.labelForUpdModellYear = new System.Windows.Forms.Label();
            this.labelForUpdNumOfCylinders = new System.Windows.Forms.Label();
            this.labelForUpdEngineDisplacement = new System.Windows.Forms.Label();
            this.LabelForUpdFuel = new System.Windows.Forms.Label();
            this.labelForUpdID = new System.Windows.Forms.Label();
            this.updFuel = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updEngineDisplacement = new System.Windows.Forms.TextBox();
            this.updNumOfCylinders = new System.Windows.Forms.TextBox();
            this.updModelYear = new System.Windows.Forms.TextBox();
            this.updColor = new System.Windows.Forms.TextBox();
            this.updVin = new System.Windows.Forms.TextBox();
            this.updBrand = new System.Windows.Forms.TextBox();
            this.updId = new System.Windows.Forms.ComboBox();
            this.updCar = new System.Windows.Forms.Button();
            this.labelForDeleteById = new System.Windows.Forms.Label();
            this.deleteById = new System.Windows.Forms.ComboBox();
            this.labelForUpdate = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.Button();
            this.labelForFuel = new System.Windows.Forms.Label();
            this.Fuel = new System.Windows.Forms.ListBox();
            this.getFuels = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(1525, 26);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(134, 23);
            this.logout.TabIndex = 0;
            this.logout.Text = "Kijelentkezés";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // adatok
            // 
            this.adatok.FormattingEnabled = true;
            this.adatok.Location = new System.Drawing.Point(1191, 52);
            this.adatok.Name = "adatok";
            this.adatok.Size = new System.Drawing.Size(468, 706);
            this.adatok.TabIndex = 1;
            // 
            // carsFromDb
            // 
            this.carsFromDb.Location = new System.Drawing.Point(1191, 26);
            this.carsFromDb.Name = "carsFromDb";
            this.carsFromDb.Size = new System.Drawing.Size(105, 23);
            this.carsFromDb.TabIndex = 2;
            this.carsFromDb.Text = "Autók lekérése";
            this.carsFromDb.UseVisualStyleBackColor = true;
            this.carsFromDb.Click += new System.EventHandler(this.carsFromDb_Click);
            // 
            // labelForCarById
            // 
            this.labelForCarById.AutoSize = true;
            this.labelForCarById.Location = new System.Drawing.Point(819, 80);
            this.labelForCarById.Name = "labelForCarById";
            this.labelForCarById.Size = new System.Drawing.Size(123, 13);
            this.labelForCarById.TabIndex = 4;
            this.labelForCarById.Text = "Autó lekérése ID alapján";
            // 
            // carFromDbById
            // 
            this.carFromDbById.Location = new System.Drawing.Point(948, 117);
            this.carFromDbById.Name = "carFromDbById";
            this.carFromDbById.Size = new System.Drawing.Size(100, 23);
            this.carFromDbById.TabIndex = 5;
            this.carFromDbById.Text = "Autó lekérése";
            this.carFromDbById.UseVisualStyleBackColor = true;
            this.carFromDbById.Click += new System.EventHandler(this.carFromDbById_Click);
            // 
            // labelForNewCar
            // 
            this.labelForNewCar.AutoSize = true;
            this.labelForNewCar.Location = new System.Drawing.Point(647, 80);
            this.labelForNewCar.Name = "labelForNewCar";
            this.labelForNewCar.Size = new System.Drawing.Size(101, 13);
            this.labelForNewCar.TabIndex = 6;
            this.labelForNewCar.Text = "Új autó hozzáadása";
            // 
            // labelForNewBrand
            // 
            this.labelForNewBrand.AutoSize = true;
            this.labelForNewBrand.Location = new System.Drawing.Point(585, 117);
            this.labelForNewBrand.Name = "labelForNewBrand";
            this.labelForNewBrand.Size = new System.Drawing.Size(37, 13);
            this.labelForNewBrand.TabIndex = 7;
            this.labelForNewBrand.Text = "Márka";
            // 
            // labelForNewVin
            // 
            this.labelForNewVin.AutoSize = true;
            this.labelForNewVin.Location = new System.Drawing.Point(585, 142);
            this.labelForNewVin.Name = "labelForNewVin";
            this.labelForNewVin.Size = new System.Drawing.Size(57, 13);
            this.labelForNewVin.TabIndex = 8;
            this.labelForNewVin.Text = "Alvázszám";
            // 
            // labelForNewColor
            // 
            this.labelForNewColor.AutoSize = true;
            this.labelForNewColor.Location = new System.Drawing.Point(585, 167);
            this.labelForNewColor.Name = "labelForNewColor";
            this.labelForNewColor.Size = new System.Drawing.Size(29, 13);
            this.labelForNewColor.TabIndex = 9;
            this.labelForNewColor.Text = "Szín";
            // 
            // labelForNewModelYear
            // 
            this.labelForNewModelYear.AutoSize = true;
            this.labelForNewModelYear.Location = new System.Drawing.Point(585, 189);
            this.labelForNewModelYear.Name = "labelForNewModelYear";
            this.labelForNewModelYear.Size = new System.Drawing.Size(53, 13);
            this.labelForNewModelYear.TabIndex = 10;
            this.labelForNewModelYear.Text = "Modell év";
            // 
            // labelForNewNumOfCylinders
            // 
            this.labelForNewNumOfCylinders.AutoSize = true;
            this.labelForNewNumOfCylinders.Location = new System.Drawing.Point(585, 212);
            this.labelForNewNumOfCylinders.Name = "labelForNewNumOfCylinders";
            this.labelForNewNumOfCylinders.Size = new System.Drawing.Size(89, 13);
            this.labelForNewNumOfCylinders.TabIndex = 11;
            this.labelForNewNumOfCylinders.Text = "Hengerek Száma";
            // 
            // labelForNewEngineDisplacement
            // 
            this.labelForNewEngineDisplacement.AutoSize = true;
            this.labelForNewEngineDisplacement.Location = new System.Drawing.Point(585, 242);
            this.labelForNewEngineDisplacement.Name = "labelForNewEngineDisplacement";
            this.labelForNewEngineDisplacement.Size = new System.Drawing.Size(88, 13);
            this.labelForNewEngineDisplacement.TabIndex = 12;
            this.labelForNewEngineDisplacement.Text = "Hengerürtartalom";
            // 
            // labelForNewFuel
            // 
            this.labelForNewFuel.AutoSize = true;
            this.labelForNewFuel.Location = new System.Drawing.Point(585, 268);
            this.labelForNewFuel.Name = "labelForNewFuel";
            this.labelForNewFuel.Size = new System.Drawing.Size(101, 13);
            this.labelForNewFuel.TabIndex = 13;
            this.labelForNewFuel.Text = "Tűzelőanyag típusa";
            // 
            // newBrand
            // 
            this.newBrand.Location = new System.Drawing.Point(689, 108);
            this.newBrand.Name = "newBrand";
            this.newBrand.Size = new System.Drawing.Size(124, 20);
            this.newBrand.TabIndex = 14;
            // 
            // newVin
            // 
            this.newVin.Location = new System.Drawing.Point(689, 134);
            this.newVin.Name = "newVin";
            this.newVin.Size = new System.Drawing.Size(124, 20);
            this.newVin.TabIndex = 15;
            // 
            // newColor
            // 
            this.newColor.Location = new System.Drawing.Point(689, 160);
            this.newColor.Name = "newColor";
            this.newColor.Size = new System.Drawing.Size(124, 20);
            this.newColor.TabIndex = 16;
            // 
            // newModelYear
            // 
            this.newModelYear.Location = new System.Drawing.Point(689, 186);
            this.newModelYear.Name = "newModelYear";
            this.newModelYear.Size = new System.Drawing.Size(124, 20);
            this.newModelYear.TabIndex = 17;
            // 
            // newNumOfCylinders
            // 
            this.newNumOfCylinders.Location = new System.Drawing.Point(689, 209);
            this.newNumOfCylinders.Name = "newNumOfCylinders";
            this.newNumOfCylinders.Size = new System.Drawing.Size(124, 20);
            this.newNumOfCylinders.TabIndex = 18;
            // 
            // newEngingeDisplacement
            // 
            this.newEngingeDisplacement.Location = new System.Drawing.Point(689, 235);
            this.newEngingeDisplacement.Name = "newEngingeDisplacement";
            this.newEngingeDisplacement.Size = new System.Drawing.Size(124, 20);
            this.newEngingeDisplacement.TabIndex = 19;
            // 
            // newFuel
            // 
            this.newFuel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.newFuel.FormattingEnabled = true;
            this.newFuel.Location = new System.Drawing.Point(689, 261);
            this.newFuel.Name = "newFuel";
            this.newFuel.Size = new System.Drawing.Size(124, 21);
            this.newFuel.TabIndex = 20;
            // 
            // carById
            // 
            this.carById.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.carById.FormattingEnabled = true;
            this.carById.Location = new System.Drawing.Point(948, 72);
            this.carById.Name = "carById";
            this.carById.Size = new System.Drawing.Size(100, 21);
            this.carById.TabIndex = 21;
            // 
            // newCar
            // 
            this.newCar.Location = new System.Drawing.Point(689, 297);
            this.newCar.Name = "newCar";
            this.newCar.Size = new System.Drawing.Size(124, 23);
            this.newCar.TabIndex = 22;
            this.newCar.Text = "Hozzáadás";
            this.newCar.UseVisualStyleBackColor = true;
            this.newCar.Click += new System.EventHandler(this.newCar_Click);
            // 
            // clearAdatok
            // 
            this.clearAdatok.Location = new System.Drawing.Point(1079, 731);
            this.clearAdatok.Name = "clearAdatok";
            this.clearAdatok.Size = new System.Drawing.Size(106, 23);
            this.clearAdatok.TabIndex = 23;
            this.clearAdatok.Text = "Kiírás törlése";
            this.clearAdatok.UseVisualStyleBackColor = true;
            this.clearAdatok.Click += new System.EventHandler(this.clearAdatok_Click);
            // 
            // labelForUpdBrand
            // 
            this.labelForUpdBrand.AutoSize = true;
            this.labelForUpdBrand.Location = new System.Drawing.Point(140, 117);
            this.labelForUpdBrand.Name = "labelForUpdBrand";
            this.labelForUpdBrand.Size = new System.Drawing.Size(37, 13);
            this.labelForUpdBrand.TabIndex = 24;
            this.labelForUpdBrand.Text = "Márka";
            // 
            // labelForUpdVin
            // 
            this.labelForUpdVin.AutoSize = true;
            this.labelForUpdVin.Location = new System.Drawing.Point(140, 141);
            this.labelForUpdVin.Name = "labelForUpdVin";
            this.labelForUpdVin.Size = new System.Drawing.Size(57, 13);
            this.labelForUpdVin.TabIndex = 25;
            this.labelForUpdVin.Text = "Alvázszám";
            // 
            // labelForUpdColor
            // 
            this.labelForUpdColor.AutoSize = true;
            this.labelForUpdColor.Location = new System.Drawing.Point(140, 167);
            this.labelForUpdColor.Name = "labelForUpdColor";
            this.labelForUpdColor.Size = new System.Drawing.Size(29, 13);
            this.labelForUpdColor.TabIndex = 26;
            this.labelForUpdColor.Text = "Szín";
            // 
            // labelForUpdModellYear
            // 
            this.labelForUpdModellYear.AutoSize = true;
            this.labelForUpdModellYear.Location = new System.Drawing.Point(140, 189);
            this.labelForUpdModellYear.Name = "labelForUpdModellYear";
            this.labelForUpdModellYear.Size = new System.Drawing.Size(53, 13);
            this.labelForUpdModellYear.TabIndex = 27;
            this.labelForUpdModellYear.Text = "Modell év";
            // 
            // labelForUpdNumOfCylinders
            // 
            this.labelForUpdNumOfCylinders.AutoSize = true;
            this.labelForUpdNumOfCylinders.Location = new System.Drawing.Point(140, 216);
            this.labelForUpdNumOfCylinders.Name = "labelForUpdNumOfCylinders";
            this.labelForUpdNumOfCylinders.Size = new System.Drawing.Size(87, 13);
            this.labelForUpdNumOfCylinders.TabIndex = 28;
            this.labelForUpdNumOfCylinders.Text = "Hengerek száma";
            // 
            // labelForUpdEngineDisplacement
            // 
            this.labelForUpdEngineDisplacement.AutoSize = true;
            this.labelForUpdEngineDisplacement.Location = new System.Drawing.Point(140, 242);
            this.labelForUpdEngineDisplacement.Name = "labelForUpdEngineDisplacement";
            this.labelForUpdEngineDisplacement.Size = new System.Drawing.Size(88, 13);
            this.labelForUpdEngineDisplacement.TabIndex = 29;
            this.labelForUpdEngineDisplacement.Text = "Hengerűrtartalom";
            // 
            // LabelForUpdFuel
            // 
            this.LabelForUpdFuel.AutoSize = true;
            this.LabelForUpdFuel.Location = new System.Drawing.Point(140, 269);
            this.LabelForUpdFuel.Name = "LabelForUpdFuel";
            this.LabelForUpdFuel.Size = new System.Drawing.Size(101, 13);
            this.LabelForUpdFuel.TabIndex = 30;
            this.LabelForUpdFuel.Text = "Tűzelőanyag típusa";
            // 
            // labelForUpdID
            // 
            this.labelForUpdID.AutoSize = true;
            this.labelForUpdID.Location = new System.Drawing.Point(140, 91);
            this.labelForUpdID.Name = "labelForUpdID";
            this.labelForUpdID.Size = new System.Drawing.Size(18, 13);
            this.labelForUpdID.TabIndex = 31;
            this.labelForUpdID.Text = "ID";
            // 
            // updFuel
            // 
            this.updFuel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.updFuel.FormattingEnabled = true;
            this.updFuel.Location = new System.Drawing.Point(248, 269);
            this.updFuel.Name = "updFuel";
            this.updFuel.Size = new System.Drawing.Size(121, 21);
            this.updFuel.TabIndex = 32;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // updEngineDisplacement
            // 
            this.updEngineDisplacement.Location = new System.Drawing.Point(248, 239);
            this.updEngineDisplacement.Name = "updEngineDisplacement";
            this.updEngineDisplacement.Size = new System.Drawing.Size(121, 20);
            this.updEngineDisplacement.TabIndex = 34;
            // 
            // updNumOfCylinders
            // 
            this.updNumOfCylinders.Location = new System.Drawing.Point(248, 212);
            this.updNumOfCylinders.Name = "updNumOfCylinders";
            this.updNumOfCylinders.Size = new System.Drawing.Size(121, 20);
            this.updNumOfCylinders.TabIndex = 35;
            // 
            // updModelYear
            // 
            this.updModelYear.Location = new System.Drawing.Point(248, 186);
            this.updModelYear.Name = "updModelYear";
            this.updModelYear.Size = new System.Drawing.Size(121, 20);
            this.updModelYear.TabIndex = 36;
            // 
            // updColor
            // 
            this.updColor.Location = new System.Drawing.Point(248, 160);
            this.updColor.Name = "updColor";
            this.updColor.Size = new System.Drawing.Size(121, 20);
            this.updColor.TabIndex = 37;
            // 
            // updVin
            // 
            this.updVin.Location = new System.Drawing.Point(248, 134);
            this.updVin.Name = "updVin";
            this.updVin.Size = new System.Drawing.Size(121, 20);
            this.updVin.TabIndex = 38;
            // 
            // updBrand
            // 
            this.updBrand.Location = new System.Drawing.Point(248, 108);
            this.updBrand.Name = "updBrand";
            this.updBrand.Size = new System.Drawing.Size(121, 20);
            this.updBrand.TabIndex = 39;
            // 
            // updId
            // 
            this.updId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.updId.FormattingEnabled = true;
            this.updId.Location = new System.Drawing.Point(248, 81);
            this.updId.Name = "updId";
            this.updId.Size = new System.Drawing.Size(121, 21);
            this.updId.TabIndex = 40;
            this.updId.DropDownClosed += new System.EventHandler(this.updId_DropDownClosed);
            // 
            // updCar
            // 
            this.updCar.Location = new System.Drawing.Point(248, 296);
            this.updCar.Name = "updCar";
            this.updCar.Size = new System.Drawing.Size(121, 23);
            this.updCar.TabIndex = 41;
            this.updCar.Text = "Módosítás";
            this.updCar.UseVisualStyleBackColor = true;
            this.updCar.Click += new System.EventHandler(this.updCar_Click);
            // 
            // labelForDeleteById
            // 
            this.labelForDeleteById.AutoSize = true;
            this.labelForDeleteById.Location = new System.Drawing.Point(140, 521);
            this.labelForDeleteById.Name = "labelForDeleteById";
            this.labelForDeleteById.Size = new System.Drawing.Size(87, 13);
            this.labelForDeleteById.TabIndex = 42;
            this.labelForDeleteById.Text = "Törlés ID alapján";
            // 
            // deleteById
            // 
            this.deleteById.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deleteById.FormattingEnabled = true;
            this.deleteById.Location = new System.Drawing.Point(143, 547);
            this.deleteById.Name = "deleteById";
            this.deleteById.Size = new System.Drawing.Size(121, 21);
            this.deleteById.TabIndex = 43;
            // 
            // labelForUpdate
            // 
            this.labelForUpdate.AutoSize = true;
            this.labelForUpdate.Location = new System.Drawing.Point(163, 52);
            this.labelForUpdate.Name = "labelForUpdate";
            this.labelForUpdate.Size = new System.Drawing.Size(87, 13);
            this.labelForUpdate.TabIndex = 44;
            this.labelForUpdate.Text = "Autó módosítása";
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(143, 585);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(121, 23);
            this.delete.TabIndex = 45;
            this.delete.Text = "Törlés";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // labelForFuel
            // 
            this.labelForFuel.AutoSize = true;
            this.labelForFuel.Location = new System.Drawing.Point(606, 520);
            this.labelForFuel.Name = "labelForFuel";
            this.labelForFuel.Size = new System.Drawing.Size(128, 13);
            this.labelForFuel.TabIndex = 46;
            this.labelForFuel.Text = "Aktuális tűzelőanyag árak";
            // 
            // Fuel
            // 
            this.Fuel.FormattingEnabled = true;
            this.Fuel.Location = new System.Drawing.Point(599, 547);
            this.Fuel.Name = "Fuel";
            this.Fuel.Size = new System.Drawing.Size(149, 160);
            this.Fuel.TabIndex = 47;
            // 
            // getFuels
            // 
            this.getFuels.Location = new System.Drawing.Point(588, 722);
            this.getFuels.Name = "getFuels";
            this.getFuels.Size = new System.Drawing.Size(172, 23);
            this.getFuels.TabIndex = 48;
            this.getFuels.Text = "Tűzelőanyag árak lekérdezése";
            this.getFuels.UseVisualStyleBackColor = true;
            this.getFuels.Click += new System.EventHandler(this.getFuels_Click);
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1691, 766);
            this.Controls.Add(this.getFuels);
            this.Controls.Add(this.Fuel);
            this.Controls.Add(this.labelForFuel);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.labelForUpdate);
            this.Controls.Add(this.deleteById);
            this.Controls.Add(this.labelForDeleteById);
            this.Controls.Add(this.updCar);
            this.Controls.Add(this.updId);
            this.Controls.Add(this.updBrand);
            this.Controls.Add(this.updVin);
            this.Controls.Add(this.updColor);
            this.Controls.Add(this.updModelYear);
            this.Controls.Add(this.updNumOfCylinders);
            this.Controls.Add(this.updEngineDisplacement);
            this.Controls.Add(this.updFuel);
            this.Controls.Add(this.labelForUpdID);
            this.Controls.Add(this.LabelForUpdFuel);
            this.Controls.Add(this.labelForUpdEngineDisplacement);
            this.Controls.Add(this.labelForUpdNumOfCylinders);
            this.Controls.Add(this.labelForUpdModellYear);
            this.Controls.Add(this.labelForUpdColor);
            this.Controls.Add(this.labelForUpdVin);
            this.Controls.Add(this.labelForUpdBrand);
            this.Controls.Add(this.clearAdatok);
            this.Controls.Add(this.newCar);
            this.Controls.Add(this.carById);
            this.Controls.Add(this.newFuel);
            this.Controls.Add(this.newEngingeDisplacement);
            this.Controls.Add(this.newNumOfCylinders);
            this.Controls.Add(this.newModelYear);
            this.Controls.Add(this.newColor);
            this.Controls.Add(this.newVin);
            this.Controls.Add(this.newBrand);
            this.Controls.Add(this.labelForNewFuel);
            this.Controls.Add(this.labelForNewEngineDisplacement);
            this.Controls.Add(this.labelForNewNumOfCylinders);
            this.Controls.Add(this.labelForNewModelYear);
            this.Controls.Add(this.labelForNewColor);
            this.Controls.Add(this.labelForNewVin);
            this.Controls.Add(this.labelForNewBrand);
            this.Controls.Add(this.labelForNewCar);
            this.Controls.Add(this.carFromDbById);
            this.Controls.Add(this.labelForCarById);
            this.Controls.Add(this.carsFromDb);
            this.Controls.Add(this.adatok);
            this.Controls.Add(this.logout);
            this.Name = "DataForm";
            this.Text = "DaraForm";
            this.Load += new System.EventHandler(this.DataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.ListBox adatok;
        private System.Windows.Forms.Button carsFromDb;
        private System.Windows.Forms.Label labelForCarById;
        private System.Windows.Forms.Button carFromDbById;
        private System.Windows.Forms.Label labelForNewCar;
        private System.Windows.Forms.Label labelForNewBrand;
        private System.Windows.Forms.Label labelForNewVin;
        private System.Windows.Forms.Label labelForNewColor;
        private System.Windows.Forms.Label labelForNewModelYear;
        private System.Windows.Forms.Label labelForNewNumOfCylinders;
        private System.Windows.Forms.Label labelForNewEngineDisplacement;
        private System.Windows.Forms.Label labelForNewFuel;
        private System.Windows.Forms.TextBox newBrand;
        private System.Windows.Forms.TextBox newVin;
        private System.Windows.Forms.TextBox newColor;
        private System.Windows.Forms.TextBox newModelYear;
        private System.Windows.Forms.TextBox newNumOfCylinders;
        private System.Windows.Forms.TextBox newEngingeDisplacement;
        private System.Windows.Forms.ComboBox newFuel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox carById;
        private System.Windows.Forms.Button newCar;
        private System.Windows.Forms.Button clearAdatok;
        private System.Windows.Forms.Label labelForUpdBrand;
        private System.Windows.Forms.Label labelForUpdVin;
        private System.Windows.Forms.Label labelForUpdColor;
        private System.Windows.Forms.Label labelForUpdModellYear;
        private System.Windows.Forms.Label labelForUpdNumOfCylinders;
        private System.Windows.Forms.Label labelForUpdEngineDisplacement;
        private System.Windows.Forms.Label LabelForUpdFuel;
        private System.Windows.Forms.Label labelForUpdID;
        private System.Windows.Forms.ComboBox updFuel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox updEngineDisplacement;
        private System.Windows.Forms.TextBox updNumOfCylinders;
        private System.Windows.Forms.TextBox updModelYear;
        private System.Windows.Forms.TextBox updColor;
        private System.Windows.Forms.TextBox updVin;
        private System.Windows.Forms.TextBox updBrand;
        private System.Windows.Forms.ComboBox updId;
        private System.Windows.Forms.Button updCar;
        private System.Windows.Forms.Label labelForDeleteById;
        private System.Windows.Forms.ComboBox deleteById;
        private System.Windows.Forms.Label labelForUpdate;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Label labelForFuel;
        private System.Windows.Forms.ListBox Fuel;
        private System.Windows.Forms.Button getFuels;
    }
}