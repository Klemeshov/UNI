namespace Graphs
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_selectImage = new System.Windows.Forms.Button();
            this.pctrbx_selectedImage = new System.Windows.Forms.PictureBox();
            this.btn_segmentize = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_saveSegmentation = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_selectBackgroundBrush = new System.Windows.Forms.Button();
            this.btn_selectObjectBrush = new System.Windows.Forms.Button();
            this.inpt_backgroundBrushSize = new System.Windows.Forms.NumericUpDown();
            this.inpt_objectBrushSize = new System.Windows.Forms.NumericUpDown();
            this.btn_clearBackgroundSeed = new System.Windows.Forms.Button();
            this.btn_clearObjectSeed = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pctrbx_segmentationImage = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.inpt_sigma = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.inpt_lambda = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.pctrbx_idealImage = new System.Windows.Forms.PictureBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_correctObjToTotal = new System.Windows.Forms.Label();
            this.lbl_correctBgToTotal = new System.Windows.Forms.Label();
            this.lbl_correctToTotal = new System.Windows.Forms.Label();
            this.lbl_jaccard = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_compare = new System.Windows.Forms.Button();
            this.btn_selectIdeal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctrbx_selectedImage)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inpt_backgroundBrushSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpt_objectBrushSize)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrbx_segmentationImage)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrbx_idealImage)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_selectImage
            // 
            this.btn_selectImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_selectImage.Location = new System.Drawing.Point(3, 1);
            this.btn_selectImage.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btn_selectImage.Name = "btn_selectImage";
            this.btn_selectImage.Size = new System.Drawing.Size(160, 42);
            this.btn_selectImage.TabIndex = 0;
            this.btn_selectImage.Text = "Select image...";
            this.btn_selectImage.UseVisualStyleBackColor = true;
            this.btn_selectImage.Click += new System.EventHandler(this.btn_selectImage_Click);
            // 
            // pctrbx_selectedImage
            // 
            this.pctrbx_selectedImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctrbx_selectedImage.ImageLocation = "C:\\Users\\eliza\\Desktop\\images-320\\fullmoon-gr-320.jpg";
            this.pctrbx_selectedImage.Location = new System.Drawing.Point(4, 24);
            this.pctrbx_selectedImage.Margin = new System.Windows.Forms.Padding(0);
            this.pctrbx_selectedImage.Name = "pctrbx_selectedImage";
            this.pctrbx_selectedImage.Size = new System.Drawing.Size(445, 483);
            this.pctrbx_selectedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrbx_selectedImage.TabIndex = 1;
            this.pctrbx_selectedImage.TabStop = false;
            this.pctrbx_selectedImage.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pctrbx_selectedImage_LoadCompleted);
            this.pctrbx_selectedImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pctrbx_selectedImage_Paint);
            this.pctrbx_selectedImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctrbx_selectedImage_MouseDown);
            this.pctrbx_selectedImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctrbx_selectedImage_MouseMove);
            this.pctrbx_selectedImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pctrbx_selectedImage_MouseUp);
            // 
            // btn_segmentize
            // 
            this.btn_segmentize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_segmentize.Location = new System.Drawing.Point(166, 0);
            this.btn_segmentize.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btn_segmentize.Name = "btn_segmentize";
            this.btn_segmentize.Size = new System.Drawing.Size(176, 43);
            this.btn_segmentize.TabIndex = 6;
            this.btn_segmentize.Text = "Segmentize";
            this.btn_segmentize.UseVisualStyleBackColor = true;
            this.btn_segmentize.Click += new System.EventHandler(this.btn_segmentize_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_selectImage);
            this.flowLayoutPanel1.Controls.Add(this.btn_segmentize);
            this.flowLayoutPanel1.Controls.Add(this.btn_saveSegmentation);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 795);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1383, 45);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // btn_saveSegmentation
            // 
            this.btn_saveSegmentation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_saveSegmentation.Location = new System.Drawing.Point(345, 0);
            this.btn_saveSegmentation.Margin = new System.Windows.Forms.Padding(0);
            this.btn_saveSegmentation.Name = "btn_saveSegmentation";
            this.btn_saveSegmentation.Size = new System.Drawing.Size(149, 43);
            this.btn_saveSegmentation.TabIndex = 7;
            this.btn_saveSegmentation.Text = "Save result";
            this.btn_saveSegmentation.UseVisualStyleBackColor = true;
            this.btn_saveSegmentation.Click += new System.EventHandler(this.btn_saveSegmentation_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pctrbx_selectedImage);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(453, 767);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected image";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(4, 507);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(445, 255);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Brush settings";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btn_selectBackgroundBrush, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_selectObjectBrush, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.inpt_backgroundBrushSize, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.inpt_objectBrushSize, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_clearBackgroundSeed, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_clearObjectSeed, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(437, 226);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btn_selectBackgroundBrush
            // 
            this.btn_selectBackgroundBrush.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_selectBackgroundBrush.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_selectBackgroundBrush.Location = new System.Drawing.Point(4, 5);
            this.btn_selectBackgroundBrush.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_selectBackgroundBrush.Name = "btn_selectBackgroundBrush";
            this.btn_selectBackgroundBrush.Size = new System.Drawing.Size(137, 103);
            this.btn_selectBackgroundBrush.TabIndex = 0;
            this.btn_selectBackgroundBrush.Text = "Select T";
            this.btn_selectBackgroundBrush.UseVisualStyleBackColor = false;
            this.btn_selectBackgroundBrush.Click += new System.EventHandler(this.btn_selectBackgroundBrush_Click);
            // 
            // btn_selectObjectBrush
            // 
            this.btn_selectObjectBrush.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_selectObjectBrush.BackColor = System.Drawing.Color.MistyRose;
            this.btn_selectObjectBrush.Location = new System.Drawing.Point(4, 118);
            this.btn_selectObjectBrush.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_selectObjectBrush.Name = "btn_selectObjectBrush";
            this.btn_selectObjectBrush.Size = new System.Drawing.Size(137, 103);
            this.btn_selectObjectBrush.TabIndex = 1;
            this.btn_selectObjectBrush.Text = "Select S";
            this.btn_selectObjectBrush.UseVisualStyleBackColor = false;
            this.btn_selectObjectBrush.Click += new System.EventHandler(this.btn_selectObjectBrush_Click);
            // 
            // inpt_backgroundBrushSize
            // 
            this.inpt_backgroundBrushSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inpt_backgroundBrushSize.Location = new System.Drawing.Point(293, 3);
            this.inpt_backgroundBrushSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inpt_backgroundBrushSize.Name = "inpt_backgroundBrushSize";
            this.inpt_backgroundBrushSize.Size = new System.Drawing.Size(141, 26);
            this.inpt_backgroundBrushSize.TabIndex = 2;
            this.inpt_backgroundBrushSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inpt_backgroundBrushSize.ValueChanged += new System.EventHandler(this.inpt_backgroundBrushSize_ValueChanged);
            // 
            // inpt_objectBrushSize
            // 
            this.inpt_objectBrushSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inpt_objectBrushSize.Location = new System.Drawing.Point(293, 116);
            this.inpt_objectBrushSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inpt_objectBrushSize.Name = "inpt_objectBrushSize";
            this.inpt_objectBrushSize.Size = new System.Drawing.Size(141, 26);
            this.inpt_objectBrushSize.TabIndex = 3;
            this.inpt_objectBrushSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inpt_objectBrushSize.ValueChanged += new System.EventHandler(this.inpt_objectBrushSize_ValueChanged);
            // 
            // btn_clearBackgroundSeed
            // 
            this.btn_clearBackgroundSeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_clearBackgroundSeed.Location = new System.Drawing.Point(149, 5);
            this.btn_clearBackgroundSeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_clearBackgroundSeed.Name = "btn_clearBackgroundSeed";
            this.btn_clearBackgroundSeed.Size = new System.Drawing.Size(137, 103);
            this.btn_clearBackgroundSeed.TabIndex = 4;
            this.btn_clearBackgroundSeed.Text = "Clear";
            this.btn_clearBackgroundSeed.UseVisualStyleBackColor = true;
            this.btn_clearBackgroundSeed.Click += new System.EventHandler(this.btn_clearBackgroundSeed_Click);
            // 
            // btn_clearObjectSeed
            // 
            this.btn_clearObjectSeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clearObjectSeed.Location = new System.Drawing.Point(149, 118);
            this.btn_clearObjectSeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_clearObjectSeed.Name = "btn_clearObjectSeed";
            this.btn_clearObjectSeed.Size = new System.Drawing.Size(137, 103);
            this.btn_clearObjectSeed.TabIndex = 5;
            this.btn_clearObjectSeed.Text = "Clear";
            this.btn_clearObjectSeed.UseVisualStyleBackColor = true;
            this.btn_clearObjectSeed.Click += new System.EventHandler(this.btn_clearObjectSeed_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pctrbx_segmentationImage);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(465, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(453, 767);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Segmentation";
            // 
            // pctrbx_segmentationImage
            // 
            this.pctrbx_segmentationImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctrbx_segmentationImage.ImageLocation = "";
            this.pctrbx_segmentationImage.Location = new System.Drawing.Point(4, 24);
            this.pctrbx_segmentationImage.Margin = new System.Windows.Forms.Padding(0);
            this.pctrbx_segmentationImage.Name = "pctrbx_segmentationImage";
            this.pctrbx_segmentationImage.Size = new System.Drawing.Size(445, 483);
            this.pctrbx_segmentationImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrbx_segmentationImage.TabIndex = 1;
            this.pctrbx_segmentationImage.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(4, 507);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(445, 255);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Properties";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.inpt_sigma);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(4, 104);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(437, 80);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "sigma";
            // 
            // inpt_sigma
            // 
            this.inpt_sigma.Dock = System.Windows.Forms.DockStyle.Left;
            this.inpt_sigma.Location = new System.Drawing.Point(3, 22);
            this.inpt_sigma.Name = "inpt_sigma";
            this.inpt_sigma.Size = new System.Drawing.Size(100, 26);
            this.inpt_sigma.TabIndex = 1;
            this.inpt_sigma.TextChanged += new System.EventHandler(this.inpt_sigma_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.inpt_lambda);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(4, 24);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(437, 80);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "lambda";
            // 
            // inpt_lambda
            // 
            this.inpt_lambda.Dock = System.Windows.Forms.DockStyle.Left;
            this.inpt_lambda.Location = new System.Drawing.Point(3, 22);
            this.inpt_lambda.Name = "inpt_lambda";
            this.inpt_lambda.Size = new System.Drawing.Size(100, 26);
            this.inpt_lambda.TabIndex = 0;
            this.inpt_lambda.TextChanged += new System.EventHandler(this.inpt_lambda_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox8, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 18);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1383, 777);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.pctrbx_idealImage);
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Controls.Add(this.groupBox10);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(926, 5);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox8.Size = new System.Drawing.Size(453, 767);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Quality Assertion";
            // 
            // pctrbx_idealImage
            // 
            this.pctrbx_idealImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctrbx_idealImage.Location = new System.Drawing.Point(4, 24);
            this.pctrbx_idealImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pctrbx_idealImage.Name = "pctrbx_idealImage";
            this.pctrbx_idealImage.Size = new System.Drawing.Size(445, 482);
            this.pctrbx_idealImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrbx_idealImage.TabIndex = 1;
            this.pctrbx_idealImage.TabStop = false;
            this.pctrbx_idealImage.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pctrbx_idealImage_LoadCompleted);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tableLayoutPanel3);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox9.Location = new System.Drawing.Point(4, 506);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox9.Size = new System.Drawing.Size(445, 185);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Results";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_correctObjToTotal, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_correctBgToTotal, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_correctToTotal, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_jaccard, 3, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(437, 156);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "Object Pixels %";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 78);
            this.label2.TabIndex = 1;
            this.label2.Text = "Background Pixels %";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(221, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 78);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Correct Pixels %";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(221, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 78);
            this.label4.TabIndex = 3;
            this.label4.Text = "Jaccard Metric";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_correctObjToTotal
            // 
            this.lbl_correctObjToTotal.AutoSize = true;
            this.lbl_correctObjToTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_correctObjToTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_correctObjToTotal.Location = new System.Drawing.Point(146, 0);
            this.lbl_correctObjToTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_correctObjToTotal.Name = "lbl_correctObjToTotal";
            this.lbl_correctObjToTotal.Size = new System.Drawing.Size(67, 78);
            this.lbl_correctObjToTotal.TabIndex = 4;
            this.lbl_correctObjToTotal.Text = "-";
            this.lbl_correctObjToTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_correctBgToTotal
            // 
            this.lbl_correctBgToTotal.AutoSize = true;
            this.lbl_correctBgToTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_correctBgToTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_correctBgToTotal.Location = new System.Drawing.Point(146, 78);
            this.lbl_correctBgToTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_correctBgToTotal.Name = "lbl_correctBgToTotal";
            this.lbl_correctBgToTotal.Size = new System.Drawing.Size(67, 78);
            this.lbl_correctBgToTotal.TabIndex = 5;
            this.lbl_correctBgToTotal.Text = "-";
            this.lbl_correctBgToTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_correctToTotal
            // 
            this.lbl_correctToTotal.AutoSize = true;
            this.lbl_correctToTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_correctToTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_correctToTotal.Location = new System.Drawing.Point(363, 0);
            this.lbl_correctToTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_correctToTotal.Name = "lbl_correctToTotal";
            this.lbl_correctToTotal.Size = new System.Drawing.Size(70, 78);
            this.lbl_correctToTotal.TabIndex = 6;
            this.lbl_correctToTotal.Text = "-";
            this.lbl_correctToTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_jaccard
            // 
            this.lbl_jaccard.AutoSize = true;
            this.lbl_jaccard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_jaccard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_jaccard.Location = new System.Drawing.Point(363, 78);
            this.lbl_jaccard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_jaccard.Name = "lbl_jaccard";
            this.lbl_jaccard.Size = new System.Drawing.Size(70, 78);
            this.lbl_jaccard.TabIndex = 7;
            this.lbl_jaccard.Text = "-";
            this.lbl_jaccard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.tableLayoutPanel4);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox10.Location = new System.Drawing.Point(4, 691);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox10.Size = new System.Drawing.Size(445, 71);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Actions";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btn_compare, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_selectIdeal, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(437, 42);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // btn_compare
            // 
            this.btn_compare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_compare.Enabled = false;
            this.btn_compare.Location = new System.Drawing.Point(4, 5);
            this.btn_compare.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_compare.Name = "btn_compare";
            this.btn_compare.Size = new System.Drawing.Size(210, 32);
            this.btn_compare.TabIndex = 0;
            this.btn_compare.Text = "Compare";
            this.btn_compare.UseVisualStyleBackColor = true;
            this.btn_compare.Click += new System.EventHandler(this.btn_compare_Click);
            // 
            // btn_selectIdeal
            // 
            this.btn_selectIdeal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_selectIdeal.Location = new System.Drawing.Point(222, 5);
            this.btn_selectIdeal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_selectIdeal.Name = "btn_selectIdeal";
            this.btn_selectIdeal.Size = new System.Drawing.Size(211, 32);
            this.btn_selectIdeal.TabIndex = 1;
            this.btn_selectIdeal.Text = "Select ideal";
            this.btn_selectIdeal.UseVisualStyleBackColor = true;
            this.btn_selectIdeal.Click += new System.EventHandler(this.btn_selectIdeal_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 858);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(18);
            this.Text = "CutPro2000";
            ((System.ComponentModel.ISupportInitialize)(this.pctrbx_selectedImage)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inpt_backgroundBrushSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpt_objectBrushSize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctrbx_segmentationImage)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctrbx_idealImage)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_selectImage;
        private System.Windows.Forms.PictureBox pctrbx_selectedImage;
        private System.Windows.Forms.Button btn_segmentize;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pctrbx_segmentationImage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_selectBackgroundBrush;
        private System.Windows.Forms.Button btn_selectObjectBrush;
        private System.Windows.Forms.NumericUpDown inpt_backgroundBrushSize;
        private System.Windows.Forms.NumericUpDown inpt_objectBrushSize;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox inpt_sigma;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox inpt_lambda;
        private System.Windows.Forms.Button btn_clearBackgroundSeed;
        private System.Windows.Forms.Button btn_clearObjectSeed;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.PictureBox pctrbx_idealImage;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_correctObjToTotal;
        private System.Windows.Forms.Label lbl_correctBgToTotal;
        private System.Windows.Forms.Label lbl_correctToTotal;
        private System.Windows.Forms.Label lbl_jaccard;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btn_compare;
        private System.Windows.Forms.Button btn_selectIdeal;
        private System.Windows.Forms.Button btn_saveSegmentation;
    }
}

