
namespace ToDoListWForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddCategory = new System.Windows.Forms.Button();
            this.comboBoxCategorys = new System.Windows.Forms.ComboBox();
            this.labelCategorys = new System.Windows.Forms.Label();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.buttonEditCategory = new System.Windows.Forms.Button();
            this.labelTags = new System.Windows.Forms.Label();
            this.comboBoxTags = new System.Windows.Forms.ComboBox();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.buttonDeleteTag = new System.Windows.Forms.Button();
            this.buttonEditTag = new System.Windows.Forms.Button();
            this.textBoxTag = new System.Windows.Forms.TextBox();
            this.buttonDeleteCategory = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelRight = new System.Windows.Forms.Panel();
            this.labelCurrentTask = new System.Windows.Forms.Label();
            this.tableLayoutPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.labelRightState = new System.Windows.Forms.Label();
            this.labelRightCat = new System.Windows.Forms.Label();
            this.labelRightDeadline = new System.Windows.Forms.Label();
            this.comboBoxRightState = new System.Windows.Forms.ComboBox();
            this.comboBoxRightCat = new System.Windows.Forms.ComboBox();
            this.dateTimePickerRightDeadline = new System.Windows.Forms.DateTimePicker();
            this.labelRightPrior = new System.Windows.Forms.Label();
            this.comboBoxRightPrior = new System.Windows.Forms.ComboBox();
            this.buttonRightRemoveTag = new System.Windows.Forms.Button();
            this.buttonRightAddTag = new System.Windows.Forms.Button();
            this.labelRightTags = new System.Windows.Forms.Label();
            this.comboBoxRightTags = new System.Windows.Forms.ComboBox();
            this.listBoxRightTags = new System.Windows.Forms.ListBox();
            this.textBoxRightTask = new System.Windows.Forms.TextBox();
            this.buttonSaveTask = new System.Windows.Forms.Button();
            this.radioButtonEditTask = new System.Windows.Forms.RadioButton();
            this.radioButtonAddTask = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonViewTask = new System.Windows.Forms.RadioButton();
            this.buttonDeleteTask = new System.Windows.Forms.Button();
            this.buttonUpDate = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelRight.SuspendLayout();
            this.tableLayoutPanelRight.SuspendLayout();
            this.tableLayoutPanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tableLayoutPanelMain);
            this.panelMain.Controls.Add(this.dataGridView1);
            this.panelMain.Location = new System.Drawing.Point(12, 1);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(829, 585);
            this.panelMain.TabIndex = 0;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 7;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.69697F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.30303F));
            this.tableLayoutPanelMain.Controls.Add(this.buttonAddCategory, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxCategorys, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelCategorys, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxCategory, 5, 1);
            this.tableLayoutPanelMain.Controls.Add(this.buttonEditCategory, 4, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelTags, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxTags, 1, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonAddTag, 2, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonDeleteTag, 3, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonEditTag, 4, 2);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxTag, 5, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonDeleteCategory, 3, 1);
            this.tableLayoutPanelMain.Controls.Add(this.buttonUpDate, 1, 0);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(27, 3);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(780, 110);
            this.tableLayoutPanelMain.TabIndex = 3;
            // 
            // buttonAddCategory
            // 
            this.buttonAddCategory.Location = new System.Drawing.Point(244, 39);
            this.buttonAddCategory.Name = "buttonAddCategory";
            this.buttonAddCategory.Size = new System.Drawing.Size(42, 28);
            this.buttonAddCategory.TabIndex = 0;
            this.buttonAddCategory.Text = "+";
            this.buttonAddCategory.UseVisualStyleBackColor = true;
            this.buttonAddCategory.Click += new System.EventHandler(this.buttonAddCategory_Click);
            // 
            // comboBoxCategorys
            // 
            this.comboBoxCategorys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategorys.FormattingEnabled = true;
            this.comboBoxCategorys.Location = new System.Drawing.Point(91, 39);
            this.comboBoxCategorys.Name = "comboBoxCategorys";
            this.comboBoxCategorys.Size = new System.Drawing.Size(147, 28);
            this.comboBoxCategorys.TabIndex = 1;
            this.comboBoxCategorys.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategorys_SelectedIndexChanged);
            // 
            // labelCategorys
            // 
            this.labelCategorys.AutoSize = true;
            this.labelCategorys.Location = new System.Drawing.Point(3, 36);
            this.labelCategorys.Name = "labelCategorys";
            this.labelCategorys.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelCategorys.Size = new System.Drawing.Size(82, 25);
            this.labelCategorys.TabIndex = 0;
            this.labelCategorys.Text = "Категории";
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(467, 39);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.PlaceholderText = "Новая категория";
            this.textBoxCategory.Size = new System.Drawing.Size(177, 27);
            this.textBoxCategory.TabIndex = 2;
            this.textBoxCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCategory_KeyDown);
            // 
            // buttonEditCategory
            // 
            this.buttonEditCategory.Location = new System.Drawing.Point(340, 39);
            this.buttonEditCategory.Name = "buttonEditCategory";
            this.buttonEditCategory.Size = new System.Drawing.Size(121, 28);
            this.buttonEditCategory.TabIndex = 0;
            this.buttonEditCategory.Text = "Редактировать";
            this.buttonEditCategory.UseVisualStyleBackColor = true;
            this.buttonEditCategory.Click += new System.EventHandler(this.buttonEditCategory_Click);
            // 
            // labelTags
            // 
            this.labelTags.AutoSize = true;
            this.labelTags.Location = new System.Drawing.Point(3, 70);
            this.labelTags.Name = "labelTags";
            this.labelTags.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelTags.Size = new System.Drawing.Size(52, 25);
            this.labelTags.TabIndex = 0;
            this.labelTags.Text = "Метки";
            // 
            // comboBoxTags
            // 
            this.comboBoxTags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTags.FormattingEnabled = true;
            this.comboBoxTags.Location = new System.Drawing.Point(91, 73);
            this.comboBoxTags.Name = "comboBoxTags";
            this.comboBoxTags.Size = new System.Drawing.Size(147, 28);
            this.comboBoxTags.TabIndex = 1;
            this.comboBoxTags.SelectedIndexChanged += new System.EventHandler(this.comboBoxTags_SelectedIndexChanged);
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.Location = new System.Drawing.Point(244, 73);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(42, 28);
            this.buttonAddTag.TabIndex = 0;
            this.buttonAddTag.Text = "+";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            this.buttonAddTag.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // buttonDeleteTag
            // 
            this.buttonDeleteTag.Location = new System.Drawing.Point(292, 73);
            this.buttonDeleteTag.Name = "buttonDeleteTag";
            this.buttonDeleteTag.Size = new System.Drawing.Size(42, 28);
            this.buttonDeleteTag.TabIndex = 0;
            this.buttonDeleteTag.Text = "-";
            this.buttonDeleteTag.UseVisualStyleBackColor = true;
            this.buttonDeleteTag.Click += new System.EventHandler(this.buttonDeleteTag_Click);
            // 
            // buttonEditTag
            // 
            this.buttonEditTag.Location = new System.Drawing.Point(340, 73);
            this.buttonEditTag.Name = "buttonEditTag";
            this.buttonEditTag.Size = new System.Drawing.Size(121, 28);
            this.buttonEditTag.TabIndex = 0;
            this.buttonEditTag.Text = "Редактировать";
            this.buttonEditTag.UseVisualStyleBackColor = true;
            this.buttonEditTag.Click += new System.EventHandler(this.buttonEditTag_Click);
            // 
            // textBoxTag
            // 
            this.textBoxTag.Location = new System.Drawing.Point(467, 73);
            this.textBoxTag.Name = "textBoxTag";
            this.textBoxTag.PlaceholderText = "Новая метка";
            this.textBoxTag.Size = new System.Drawing.Size(177, 27);
            this.textBoxTag.TabIndex = 2;
            this.textBoxTag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTag_KeyDown);
            // 
            // buttonDeleteCategory
            // 
            this.buttonDeleteCategory.Location = new System.Drawing.Point(292, 39);
            this.buttonDeleteCategory.Name = "buttonDeleteCategory";
            this.buttonDeleteCategory.Size = new System.Drawing.Size(42, 28);
            this.buttonDeleteCategory.TabIndex = 3;
            this.buttonDeleteCategory.Text = "-";
            this.buttonDeleteCategory.UseVisualStyleBackColor = true;
            this.buttonDeleteCategory.Click += new System.EventHandler(this.buttonDeleteCategory_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column7,
            this.Column6,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(27, 119);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(802, 458);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "№";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 55;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Описание задачи";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 146;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "Id";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 51;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column6.HeaderText = "Категория";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 110;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "Приоритет";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 114;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.HeaderText = "Дэдлайн";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 97;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column4.HeaderText = "Задача завершена";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 153;
            // 
            // panelRight
            // 
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.labelCurrentTask);
            this.panelRight.Controls.Add(this.tableLayoutPanelRight);
            this.panelRight.Controls.Add(this.textBoxRightTask);
            this.panelRight.Location = new System.Drawing.Point(848, 12);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(383, 453);
            this.panelRight.TabIndex = 0;
            // 
            // labelCurrentTask
            // 
            this.labelCurrentTask.AutoSize = true;
            this.labelCurrentTask.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelCurrentTask.Location = new System.Drawing.Point(17, 8);
            this.labelCurrentTask.Name = "labelCurrentTask";
            this.labelCurrentTask.Size = new System.Drawing.Size(167, 28);
            this.labelCurrentTask.TabIndex = 4;
            this.labelCurrentTask.Text = "Текущая задача:";
            // 
            // tableLayoutPanelRight
            // 
            this.tableLayoutPanelRight.ColumnCount = 3;
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelRight.Controls.Add(this.labelRightState, 0, 4);
            this.tableLayoutPanelRight.Controls.Add(this.labelRightCat, 0, 1);
            this.tableLayoutPanelRight.Controls.Add(this.labelRightDeadline, 0, 3);
            this.tableLayoutPanelRight.Controls.Add(this.comboBoxRightState, 1, 4);
            this.tableLayoutPanelRight.Controls.Add(this.comboBoxRightCat, 1, 1);
            this.tableLayoutPanelRight.Controls.Add(this.dateTimePickerRightDeadline, 1, 3);
            this.tableLayoutPanelRight.Controls.Add(this.labelRightPrior, 0, 2);
            this.tableLayoutPanelRight.Controls.Add(this.comboBoxRightPrior, 1, 2);
            this.tableLayoutPanelRight.Controls.Add(this.buttonRightRemoveTag, 0, 7);
            this.tableLayoutPanelRight.Controls.Add(this.buttonRightAddTag, 0, 6);
            this.tableLayoutPanelRight.Controls.Add(this.labelRightTags, 0, 5);
            this.tableLayoutPanelRight.Controls.Add(this.comboBoxRightTags, 0, 8);
            this.tableLayoutPanelRight.Controls.Add(this.listBoxRightTags, 1, 6);
            this.tableLayoutPanelRight.Location = new System.Drawing.Point(17, 155);
            this.tableLayoutPanelRight.Name = "tableLayoutPanelRight";
            this.tableLayoutPanelRight.RowCount = 10;
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.53348F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.46652F));
            this.tableLayoutPanelRight.Size = new System.Drawing.Size(352, 288);
            this.tableLayoutPanelRight.TabIndex = 3;
            // 
            // labelRightState
            // 
            this.labelRightState.AutoSize = true;
            this.labelRightState.Location = new System.Drawing.Point(3, 103);
            this.labelRightState.Name = "labelRightState";
            this.labelRightState.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelRightState.Size = new System.Drawing.Size(135, 25);
            this.labelRightState.TabIndex = 0;
            this.labelRightState.Text = "Состояние задачи";
            // 
            // labelRightCat
            // 
            this.labelRightCat.AutoSize = true;
            this.labelRightCat.Location = new System.Drawing.Point(3, 2);
            this.labelRightCat.Name = "labelRightCat";
            this.labelRightCat.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelRightCat.Size = new System.Drawing.Size(81, 25);
            this.labelRightCat.TabIndex = 0;
            this.labelRightCat.Text = "Категория";
            // 
            // labelRightDeadline
            // 
            this.labelRightDeadline.AutoSize = true;
            this.labelRightDeadline.Location = new System.Drawing.Point(3, 70);
            this.labelRightDeadline.Name = "labelRightDeadline";
            this.labelRightDeadline.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelRightDeadline.Size = new System.Drawing.Size(111, 25);
            this.labelRightDeadline.TabIndex = 0;
            this.labelRightDeadline.Text = "Конечная дата";
            // 
            // comboBoxRightState
            // 
            this.comboBoxRightState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRightState.FormattingEnabled = true;
            this.comboBoxRightState.Location = new System.Drawing.Point(144, 106);
            this.comboBoxRightState.Name = "comboBoxRightState";
            this.comboBoxRightState.Size = new System.Drawing.Size(195, 28);
            this.comboBoxRightState.TabIndex = 4;
            this.comboBoxRightState.SelectedIndexChanged += new System.EventHandler(this.comboBoxLeftState_SelectedIndexChanged);
            // 
            // comboBoxRightCat
            // 
            this.comboBoxRightCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRightCat.FormattingEnabled = true;
            this.comboBoxRightCat.Location = new System.Drawing.Point(144, 5);
            this.comboBoxRightCat.Name = "comboBoxRightCat";
            this.comboBoxRightCat.Size = new System.Drawing.Size(195, 28);
            this.comboBoxRightCat.TabIndex = 2;
            this.comboBoxRightCat.SelectedIndexChanged += new System.EventHandler(this.comboBoxLeftCat_SelectedIndexChanged);
            // 
            // dateTimePickerRightDeadline
            // 
            this.dateTimePickerRightDeadline.Location = new System.Drawing.Point(144, 73);
            this.dateTimePickerRightDeadline.Name = "dateTimePickerRightDeadline";
            this.dateTimePickerRightDeadline.Size = new System.Drawing.Size(195, 27);
            this.dateTimePickerRightDeadline.TabIndex = 3;
            this.dateTimePickerRightDeadline.ValueChanged += new System.EventHandler(this.dateTimePickerLeftDeadline_ValueChanged);
            // 
            // labelRightPrior
            // 
            this.labelRightPrior.AutoSize = true;
            this.labelRightPrior.Location = new System.Drawing.Point(3, 36);
            this.labelRightPrior.Name = "labelRightPrior";
            this.labelRightPrior.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelRightPrior.Size = new System.Drawing.Size(85, 25);
            this.labelRightPrior.TabIndex = 0;
            this.labelRightPrior.Text = "Приоритет";
            // 
            // comboBoxRightPrior
            // 
            this.comboBoxRightPrior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRightPrior.FormattingEnabled = true;
            this.comboBoxRightPrior.Location = new System.Drawing.Point(144, 39);
            this.comboBoxRightPrior.Name = "comboBoxRightPrior";
            this.comboBoxRightPrior.Size = new System.Drawing.Size(195, 28);
            this.comboBoxRightPrior.TabIndex = 2;
            this.comboBoxRightPrior.SelectedIndexChanged += new System.EventHandler(this.comboBoxLeftPrior_SelectedIndexChanged);
            // 
            // buttonRightRemoveTag
            // 
            this.buttonRightRemoveTag.Location = new System.Drawing.Point(3, 203);
            this.buttonRightRemoveTag.Name = "buttonRightRemoveTag";
            this.buttonRightRemoveTag.Size = new System.Drawing.Size(135, 29);
            this.buttonRightRemoveTag.TabIndex = 6;
            this.buttonRightRemoveTag.Text = "-";
            this.buttonRightRemoveTag.UseVisualStyleBackColor = true;
            this.buttonRightRemoveTag.Click += new System.EventHandler(this.buttonLeftRemoveTag_Click);
            // 
            // buttonRightAddTag
            // 
            this.buttonRightAddTag.Location = new System.Drawing.Point(3, 168);
            this.buttonRightAddTag.Name = "buttonRightAddTag";
            this.buttonRightAddTag.Size = new System.Drawing.Size(135, 29);
            this.buttonRightAddTag.TabIndex = 6;
            this.buttonRightAddTag.Text = "+";
            this.buttonRightAddTag.UseVisualStyleBackColor = true;
            this.buttonRightAddTag.Click += new System.EventHandler(this.buttonleftAddTag_Click);
            // 
            // labelRightTags
            // 
            this.labelRightTags.AutoSize = true;
            this.tableLayoutPanelRight.SetColumnSpan(this.labelRightTags, 2);
            this.labelRightTags.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelRightTags.Location = new System.Drawing.Point(3, 137);
            this.labelRightTags.Name = "labelRightTags";
            this.labelRightTags.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelRightTags.Size = new System.Drawing.Size(71, 28);
            this.labelRightTags.TabIndex = 0;
            this.labelRightTags.Text = "Метки:";
            this.labelRightTags.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxRightTags
            // 
            this.comboBoxRightTags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRightTags.FormattingEnabled = true;
            this.comboBoxRightTags.Location = new System.Drawing.Point(3, 238);
            this.comboBoxRightTags.Name = "comboBoxRightTags";
            this.comboBoxRightTags.Size = new System.Drawing.Size(135, 28);
            this.comboBoxRightTags.TabIndex = 7;
            this.comboBoxRightTags.SelectedIndexChanged += new System.EventHandler(this.comboBoxLeftTags_SelectedIndexChanged);
            // 
            // listBoxRightTags
            // 
            this.listBoxRightTags.FormattingEnabled = true;
            this.listBoxRightTags.ItemHeight = 20;
            this.listBoxRightTags.Location = new System.Drawing.Point(144, 168);
            this.listBoxRightTags.Name = "listBoxRightTags";
            this.tableLayoutPanelRight.SetRowSpan(this.listBoxRightTags, 3);
            this.listBoxRightTags.Size = new System.Drawing.Size(195, 104);
            this.listBoxRightTags.TabIndex = 8;
            this.listBoxRightTags.SelectedIndexChanged += new System.EventHandler(this.listBoxRightTags_SelectedIndexChanged);
            // 
            // textBoxRightTask
            // 
            this.textBoxRightTask.Location = new System.Drawing.Point(17, 39);
            this.textBoxRightTask.Multiline = true;
            this.textBoxRightTask.Name = "textBoxRightTask";
            this.textBoxRightTask.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRightTask.Size = new System.Drawing.Size(352, 108);
            this.textBoxRightTask.TabIndex = 1;
            this.textBoxRightTask.TextChanged += new System.EventHandler(this.textBoxLeftTask_TextChanged);
            // 
            // buttonSaveTask
            // 
            this.buttonSaveTask.Location = new System.Drawing.Point(187, 3);
            this.buttonSaveTask.Name = "buttonSaveTask";
            this.buttonSaveTask.Size = new System.Drawing.Size(177, 34);
            this.buttonSaveTask.TabIndex = 2;
            this.buttonSaveTask.Text = "Сохранить";
            this.buttonSaveTask.UseVisualStyleBackColor = true;
            this.buttonSaveTask.Click += new System.EventHandler(this.buttonSaveTask_Click);
            // 
            // radioButtonEditTask
            // 
            this.radioButtonEditTask.AutoSize = true;
            this.radioButtonEditTask.Location = new System.Drawing.Point(16, 79);
            this.radioButtonEditTask.Name = "radioButtonEditTask";
            this.radioButtonEditTask.Size = new System.Drawing.Size(132, 24);
            this.radioButtonEditTask.TabIndex = 3;
            this.radioButtonEditTask.TabStop = true;
            this.radioButtonEditTask.Text = "Редактировать";
            this.radioButtonEditTask.UseVisualStyleBackColor = true;
            this.radioButtonEditTask.CheckedChanged += new System.EventHandler(this.radioButtonsTask_CheckedChanged);
            // 
            // radioButtonAddTask
            // 
            this.radioButtonAddTask.AutoSize = true;
            this.radioButtonAddTask.Location = new System.Drawing.Point(16, 43);
            this.radioButtonAddTask.Name = "radioButtonAddTask";
            this.radioButtonAddTask.Size = new System.Drawing.Size(125, 24);
            this.radioButtonAddTask.TabIndex = 3;
            this.radioButtonAddTask.TabStop = true;
            this.radioButtonAddTask.Text = "Новая задача";
            this.radioButtonAddTask.UseVisualStyleBackColor = true;
            this.radioButtonAddTask.CheckedChanged += new System.EventHandler(this.radioButtonsTask_CheckedChanged);
            // 
            // tableLayoutPanelBottom
            // 
            this.tableLayoutPanelBottom.ColumnCount = 5;
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBottom.Controls.Add(this.radioButtonAddTask, 1, 1);
            this.tableLayoutPanelBottom.Controls.Add(this.radioButtonEditTask, 1, 2);
            this.tableLayoutPanelBottom.Controls.Add(this.radioButtonViewTask, 1, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.buttonSaveTask, 3, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.buttonDeleteTask, 3, 1);
            this.tableLayoutPanelBottom.Location = new System.Drawing.Point(847, 475);
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 4;
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBottom.Size = new System.Drawing.Size(383, 112);
            this.tableLayoutPanelBottom.TabIndex = 4;
            // 
            // radioButtonViewTask
            // 
            this.radioButtonViewTask.AutoSize = true;
            this.radioButtonViewTask.Location = new System.Drawing.Point(16, 3);
            this.radioButtonViewTask.Name = "radioButtonViewTask";
            this.radioButtonViewTask.Size = new System.Drawing.Size(101, 24);
            this.radioButtonViewTask.TabIndex = 3;
            this.radioButtonViewTask.TabStop = true;
            this.radioButtonViewTask.Text = "Просморт";
            this.radioButtonViewTask.UseVisualStyleBackColor = true;
            this.radioButtonViewTask.CheckedChanged += new System.EventHandler(this.radioButtonsTask_CheckedChanged);
            // 
            // buttonDeleteTask
            // 
            this.buttonDeleteTask.Location = new System.Drawing.Point(187, 43);
            this.buttonDeleteTask.Name = "buttonDeleteTask";
            this.buttonDeleteTask.Size = new System.Drawing.Size(177, 30);
            this.buttonDeleteTask.TabIndex = 2;
            this.buttonDeleteTask.Text = "Удалить задачу";
            this.buttonDeleteTask.UseVisualStyleBackColor = true;
            this.buttonDeleteTask.Click += new System.EventHandler(this.buttonDeleteTask_Click);
            // 
            // buttonUpDate
            // 
            this.buttonUpDate.Location = new System.Drawing.Point(91, 3);
            this.buttonUpDate.Name = "buttonUpDate";
            this.buttonUpDate.Size = new System.Drawing.Size(147, 29);
            this.buttonUpDate.TabIndex = 4;
            this.buttonUpDate.Text = "Обновить";
            this.buttonUpDate.UseVisualStyleBackColor = true;
            this.buttonUpDate.Click += new System.EventHandler(this.buttonUpDate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 615);
            this.Controls.Add(this.tableLayoutPanelBottom);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список задач";
            this.panelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.tableLayoutPanelRight.ResumeLayout(false);
            this.tableLayoutPanelRight.PerformLayout();
            this.tableLayoutPanelBottom.ResumeLayout(false);
            this.tableLayoutPanelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelCategorys;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button buttonAddCategory;
        private System.Windows.Forms.ComboBox comboBoxCategorys;
        private System.Windows.Forms.Button buttonDeleteTag;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.Button buttonEditCategory;
        private System.Windows.Forms.Label labelRightCat;
        private System.Windows.Forms.Label labelRightPrior;
        private System.Windows.Forms.Label labelRightDeadline;
        private System.Windows.Forms.Label labelRightState;
        private System.Windows.Forms.TextBox textBoxRightTask;
        private System.Windows.Forms.ComboBox comboBoxRightCat;
        private System.Windows.Forms.ComboBox comboBoxRightPrior;
        private System.Windows.Forms.DateTimePicker dateTimePickerRightDeadline;
        private System.Windows.Forms.Button buttonSaveTask;
        private System.Windows.Forms.RadioButton radioButtonEditTask;
        private System.Windows.Forms.RadioButton radioButtonAddTask;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRight;
        private System.Windows.Forms.ComboBox comboBoxRightState;
        private System.Windows.Forms.RadioButton radioButtonViewTask;
        private System.Windows.Forms.Button buttonDeleteTask;
        private System.Windows.Forms.Label labelTags;
        private System.Windows.Forms.ComboBox comboBoxTags;
        private System.Windows.Forms.Label labelCurrentTask;
        private System.Windows.Forms.Button buttonAddTag;
        private System.Windows.Forms.Button buttonEditTag;
        private System.Windows.Forms.TextBox textBoxTag;
        private System.Windows.Forms.Button buttonDeleteCategory;
        private System.Windows.Forms.ComboBox comboBoxRightTags;
        private System.Windows.Forms.Button buttonRightAddTag;
        private System.Windows.Forms.Button buttonRightRemoveTag;
        private System.Windows.Forms.Label labelRightTags;
        private System.Windows.Forms.ListBox listBoxRightTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.Button buttonUpDate;
    }
}

