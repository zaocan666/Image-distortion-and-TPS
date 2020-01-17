namespace numBigH1
{
    partial class mainWin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWin));
            this.pictureBox_inputImg = new System.Windows.Forms.PictureBox();
            this.openFileDialog_inputImg = new System.Windows.Forms.OpenFileDialog();
            this.button_inputImg = new System.Windows.Forms.Button();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_distort = new System.Windows.Forms.TabPage();
            this.panel_ballArg = new System.Windows.Forms.Panel();
            this.label_ballRadius = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBar_ballHeight = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_interpMethod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel_bendArg = new System.Windows.Forms.Panel();
            this.textBox_bendRadius = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_bendAngle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_distortWay = new System.Windows.Forms.ComboBox();
            this.button_distort_start = new System.Windows.Forms.Button();
            this.pictureBox_result = new System.Windows.Forms.PictureBox();
            this.tabPage_face = new System.Windows.Forms.TabPage();
            this.comboBox_interpFace = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button_blackCut = new System.Windows.Forms.Button();
            this.button_resultFace = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_aimFace = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_sourceFace = new System.Windows.Forms.ComboBox();
            this.pictureBox_resultFace = new System.Windows.Forms.PictureBox();
            this.pictureBox_aimFace = new System.Windows.Forms.PictureBox();
            this.pictureBox_sourceFace = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_inputImg)).BeginInit();
            this.tabControl_main.SuspendLayout();
            this.tabPage_distort.SuspendLayout();
            this.panel_ballArg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_ballHeight)).BeginInit();
            this.panel_bendArg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_result)).BeginInit();
            this.tabPage_face.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_resultFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_aimFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sourceFace)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_inputImg
            // 
            this.pictureBox_inputImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_inputImg.Location = new System.Drawing.Point(79, 84);
            this.pictureBox_inputImg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox_inputImg.Name = "pictureBox_inputImg";
            this.pictureBox_inputImg.Size = new System.Drawing.Size(533, 500);
            this.pictureBox_inputImg.TabIndex = 0;
            this.pictureBox_inputImg.TabStop = false;
            // 
            // openFileDialog_inputImg
            // 
            this.openFileDialog_inputImg.FileName = "openFileDialog1";
            // 
            // button_inputImg
            // 
            this.button_inputImg.Location = new System.Drawing.Point(284, 615);
            this.button_inputImg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_inputImg.Name = "button_inputImg";
            this.button_inputImg.Size = new System.Drawing.Size(123, 39);
            this.button_inputImg.TabIndex = 1;
            this.button_inputImg.Text = "打开原图片";
            this.button_inputImg.UseVisualStyleBackColor = true;
            this.button_inputImg.Click += new System.EventHandler(this.button_inputImg_Click);
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_distort);
            this.tabControl_main.Controls.Add(this.tabPage_face);
            this.tabControl_main.Location = new System.Drawing.Point(16, 15);
            this.tabControl_main.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(1723, 714);
            this.tabControl_main.TabIndex = 2;
            // 
            // tabPage_distort
            // 
            this.tabPage_distort.Controls.Add(this.panel_ballArg);
            this.tabPage_distort.Controls.Add(this.comboBox_interpMethod);
            this.tabPage_distort.Controls.Add(this.label6);
            this.tabPage_distort.Controls.Add(this.panel_bendArg);
            this.tabPage_distort.Controls.Add(this.label1);
            this.tabPage_distort.Controls.Add(this.comboBox_distortWay);
            this.tabPage_distort.Controls.Add(this.button_distort_start);
            this.tabPage_distort.Controls.Add(this.pictureBox_result);
            this.tabPage_distort.Controls.Add(this.pictureBox_inputImg);
            this.tabPage_distort.Controls.Add(this.button_inputImg);
            this.tabPage_distort.Location = new System.Drawing.Point(4, 25);
            this.tabPage_distort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_distort.Name = "tabPage_distort";
            this.tabPage_distort.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_distort.Size = new System.Drawing.Size(1715, 685);
            this.tabPage_distort.TabIndex = 0;
            this.tabPage_distort.Text = "图像扭曲";
            this.tabPage_distort.UseVisualStyleBackColor = true;
            // 
            // panel_ballArg
            // 
            this.panel_ballArg.Controls.Add(this.label_ballRadius);
            this.panel_ballArg.Controls.Add(this.label9);
            this.panel_ballArg.Controls.Add(this.label8);
            this.panel_ballArg.Controls.Add(this.trackBar_ballHeight);
            this.panel_ballArg.Controls.Add(this.label7);
            this.panel_ballArg.Location = new System.Drawing.Point(1275, 155);
            this.panel_ballArg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_ballArg.Name = "panel_ballArg";
            this.panel_ballArg.Size = new System.Drawing.Size(389, 161);
            this.panel_ballArg.TabIndex = 13;
            // 
            // label_ballRadius
            // 
            this.label_ballRadius.AutoSize = true;
            this.label_ballRadius.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ballRadius.Location = new System.Drawing.Point(117, 129);
            this.label_ballRadius.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ballRadius.Name = "label_ballRadius";
            this.label_ballRadius.Size = new System.Drawing.Size(22, 24);
            this.label_ballRadius.TabIndex = 18;
            this.label_ballRadius.Text = " ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(321, 59);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 24);
            this.label9.TabIndex = 17;
            this.label9.Text = "桶形";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(24, 59);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 24);
            this.label8.TabIndex = 16;
            this.label8.Text = "枕形";
            // 
            // trackBar_ballHeight
            // 
            this.trackBar_ballHeight.Location = new System.Drawing.Point(96, 59);
            this.trackBar_ballHeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBar_ballHeight.Name = "trackBar_ballHeight";
            this.trackBar_ballHeight.Size = new System.Drawing.Size(219, 56);
            this.trackBar_ballHeight.TabIndex = 14;
            this.trackBar_ballHeight.Scroll += new System.EventHandler(this.trackBar_ballHeight_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(148, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 13;
            this.label7.Text = "畸变高度";
            // 
            // comboBox_interpMethod
            // 
            this.comboBox_interpMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_interpMethod.FormattingEnabled = true;
            this.comboBox_interpMethod.Items.AddRange(new object[] {
            "最近邻",
            "双线性",
            "双三次"});
            this.comboBox_interpMethod.Location = new System.Drawing.Point(1447, 426);
            this.comboBox_interpMethod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_interpMethod.Name = "comboBox_interpMethod";
            this.comboBox_interpMethod.Size = new System.Drawing.Size(160, 23);
            this.comboBox_interpMethod.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(1300, 422);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 24);
            this.label6.TabIndex = 7;
            this.label6.Text = "插值方式：";
            // 
            // panel_bendArg
            // 
            this.panel_bendArg.Controls.Add(this.textBox_bendRadius);
            this.panel_bendArg.Controls.Add(this.label5);
            this.panel_bendArg.Controls.Add(this.label4);
            this.panel_bendArg.Controls.Add(this.label3);
            this.panel_bendArg.Controls.Add(this.label2);
            this.panel_bendArg.Controls.Add(this.textBox_bendAngle);
            this.panel_bendArg.Location = new System.Drawing.Point(1275, 155);
            this.panel_bendArg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_bendArg.Name = "panel_bendArg";
            this.panel_bendArg.Size = new System.Drawing.Size(389, 198);
            this.panel_bendArg.TabIndex = 6;
            this.panel_bendArg.Visible = false;
            // 
            // textBox_bendRadius
            // 
            this.textBox_bendRadius.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_bendRadius.Location = new System.Drawing.Point(172, 129);
            this.textBox_bendRadius.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_bendRadius.Name = "textBox_bendRadius";
            this.textBox_bendRadius.Size = new System.Drawing.Size(160, 35);
            this.textBox_bendRadius.TabIndex = 10;
            this.textBox_bendRadius.Text = "233";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(25, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "旋转半径：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(25, 56);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "（逆时针旋转，可正可负）";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(340, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(25, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "旋转角度：";
            // 
            // textBox_bendAngle
            // 
            this.textBox_bendAngle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_bendAngle.Location = new System.Drawing.Point(172, 16);
            this.textBox_bendAngle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_bendAngle.Name = "textBox_bendAngle";
            this.textBox_bendAngle.Size = new System.Drawing.Size(160, 35);
            this.textBox_bendAngle.TabIndex = 0;
            this.textBox_bendAngle.Text = "45";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1300, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "扭曲方式：";
            // 
            // comboBox_distortWay
            // 
            this.comboBox_distortWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_distortWay.FormattingEnabled = true;
            this.comboBox_distortWay.Items.AddRange(new object[] {
            "旋转扭曲",
            "畸变矫正"});
            this.comboBox_distortWay.Location = new System.Drawing.Point(1447, 71);
            this.comboBox_distortWay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_distortWay.Name = "comboBox_distortWay";
            this.comboBox_distortWay.Size = new System.Drawing.Size(160, 23);
            this.comboBox_distortWay.TabIndex = 4;
            this.comboBox_distortWay.SelectedIndexChanged += new System.EventHandler(this.comboBox_distortWay_SelectedIndexChanged);
            // 
            // button_distort_start
            // 
            this.button_distort_start.Location = new System.Drawing.Point(1409, 491);
            this.button_distort_start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_distort_start.Name = "button_distort_start";
            this.button_distort_start.Size = new System.Drawing.Size(127, 45);
            this.button_distort_start.TabIndex = 3;
            this.button_distort_start.Text = "图像扭曲";
            this.button_distort_start.UseVisualStyleBackColor = true;
            this.button_distort_start.Click += new System.EventHandler(this.button_distort_start_Click);
            // 
            // pictureBox_result
            // 
            this.pictureBox_result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_result.Location = new System.Drawing.Point(676, 84);
            this.pictureBox_result.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox_result.Name = "pictureBox_result";
            this.pictureBox_result.Size = new System.Drawing.Size(533, 500);
            this.pictureBox_result.TabIndex = 2;
            this.pictureBox_result.TabStop = false;
            // 
            // tabPage_face
            // 
            this.tabPage_face.Controls.Add(this.comboBox_interpFace);
            this.tabPage_face.Controls.Add(this.label12);
            this.tabPage_face.Controls.Add(this.button_blackCut);
            this.tabPage_face.Controls.Add(this.button_resultFace);
            this.tabPage_face.Controls.Add(this.label11);
            this.tabPage_face.Controls.Add(this.comboBox_aimFace);
            this.tabPage_face.Controls.Add(this.label10);
            this.tabPage_face.Controls.Add(this.comboBox_sourceFace);
            this.tabPage_face.Controls.Add(this.pictureBox_resultFace);
            this.tabPage_face.Controls.Add(this.pictureBox_aimFace);
            this.tabPage_face.Controls.Add(this.pictureBox_sourceFace);
            this.tabPage_face.Location = new System.Drawing.Point(4, 25);
            this.tabPage_face.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_face.Name = "tabPage_face";
            this.tabPage_face.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_face.Size = new System.Drawing.Size(1715, 685);
            this.tabPage_face.TabIndex = 1;
            this.tabPage_face.Text = "人脸变形";
            this.tabPage_face.UseVisualStyleBackColor = true;
            // 
            // comboBox_interpFace
            // 
            this.comboBox_interpFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_interpFace.FormattingEnabled = true;
            this.comboBox_interpFace.Items.AddRange(new object[] {
            "最近邻",
            "双线性",
            "双三次"});
            this.comboBox_interpFace.Location = new System.Drawing.Point(1375, 544);
            this.comboBox_interpFace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_interpFace.Name = "comboBox_interpFace";
            this.comboBox_interpFace.Size = new System.Drawing.Size(160, 23);
            this.comboBox_interpFace.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(1228, 540);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 24);
            this.label12.TabIndex = 11;
            this.label12.Text = "插值方式：";
            // 
            // button_blackCut
            // 
            this.button_blackCut.Location = new System.Drawing.Point(1411, 600);
            this.button_blackCut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_blackCut.Name = "button_blackCut";
            this.button_blackCut.Size = new System.Drawing.Size(127, 45);
            this.button_blackCut.TabIndex = 10;
            this.button_blackCut.Text = "切除黑边";
            this.button_blackCut.UseVisualStyleBackColor = true;
            this.button_blackCut.Click += new System.EventHandler(this.button_blackCut_Click);
            // 
            // button_resultFace
            // 
            this.button_resultFace.Location = new System.Drawing.Point(1233, 600);
            this.button_resultFace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_resultFace.Name = "button_resultFace";
            this.button_resultFace.Size = new System.Drawing.Size(127, 45);
            this.button_resultFace.TabIndex = 9;
            this.button_resultFace.Text = "求取结果";
            this.button_resultFace.UseVisualStyleBackColor = true;
            this.button_resultFace.Click += new System.EventHandler(this.button_resultFace_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(660, 540);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 24);
            this.label11.TabIndex = 8;
            this.label11.Text = "目标图片：";
            // 
            // comboBox_aimFace
            // 
            this.comboBox_aimFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_aimFace.FormattingEnabled = true;
            this.comboBox_aimFace.Items.AddRange(new object[] {
            "Face 1",
            "Face 2",
            "Face 3",
            "Face 4",
            "Face 5",
            "Face 6",
            "Face 7",
            "Face 8",
            "Face 9"});
            this.comboBox_aimFace.Location = new System.Drawing.Point(804, 539);
            this.comboBox_aimFace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_aimFace.Name = "comboBox_aimFace";
            this.comboBox_aimFace.Size = new System.Drawing.Size(160, 23);
            this.comboBox_aimFace.TabIndex = 7;
            this.comboBox_aimFace.SelectedIndexChanged += new System.EventHandler(this.comboBox_aimFace_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(85, 545);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 24);
            this.label10.TabIndex = 6;
            this.label10.Text = "原图片：";
            // 
            // comboBox_sourceFace
            // 
            this.comboBox_sourceFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sourceFace.FormattingEnabled = true;
            this.comboBox_sourceFace.Items.AddRange(new object[] {
            "Face 1",
            "Face 2",
            "Face 3",
            "Face 4",
            "Face 5",
            "Face 6",
            "Face 7",
            "Face 8",
            "Face 9"});
            this.comboBox_sourceFace.Location = new System.Drawing.Point(211, 544);
            this.comboBox_sourceFace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_sourceFace.Name = "comboBox_sourceFace";
            this.comboBox_sourceFace.Size = new System.Drawing.Size(160, 23);
            this.comboBox_sourceFace.TabIndex = 5;
            this.comboBox_sourceFace.SelectedIndexChanged += new System.EventHandler(this.comboBox_sourceFace_SelectedIndexChanged);
            // 
            // pictureBox_resultFace
            // 
            this.pictureBox_resultFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_resultFace.Location = new System.Drawing.Point(1144, 59);
            this.pictureBox_resultFace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox_resultFace.Name = "pictureBox_resultFace";
            this.pictureBox_resultFace.Size = new System.Drawing.Size(466, 437);
            this.pictureBox_resultFace.TabIndex = 3;
            this.pictureBox_resultFace.TabStop = false;
            // 
            // pictureBox_aimFace
            // 
            this.pictureBox_aimFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_aimFace.Location = new System.Drawing.Point(597, 59);
            this.pictureBox_aimFace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox_aimFace.Name = "pictureBox_aimFace";
            this.pictureBox_aimFace.Size = new System.Drawing.Size(466, 437);
            this.pictureBox_aimFace.TabIndex = 2;
            this.pictureBox_aimFace.TabStop = false;
            // 
            // pictureBox_sourceFace
            // 
            this.pictureBox_sourceFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_sourceFace.Location = new System.Drawing.Point(43, 59);
            this.pictureBox_sourceFace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox_sourceFace.Name = "pictureBox_sourceFace";
            this.pictureBox_sourceFace.Size = new System.Drawing.Size(466, 437);
            this.pictureBox_sourceFace.TabIndex = 1;
            this.pictureBox_sourceFace.TabStop = false;
            // 
            // mainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1757, 744);
            this.Controls.Add(this.tabControl_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "mainWin";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_inputImg)).EndInit();
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_distort.ResumeLayout(false);
            this.tabPage_distort.PerformLayout();
            this.panel_ballArg.ResumeLayout(false);
            this.panel_ballArg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_ballHeight)).EndInit();
            this.panel_bendArg.ResumeLayout(false);
            this.panel_bendArg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_result)).EndInit();
            this.tabPage_face.ResumeLayout(false);
            this.tabPage_face.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_resultFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_aimFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sourceFace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_inputImg;
        private System.Windows.Forms.OpenFileDialog openFileDialog_inputImg;
        private System.Windows.Forms.Button button_inputImg;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_distort;
        private System.Windows.Forms.TabPage tabPage_face;
        private System.Windows.Forms.Button button_distort_start;
        private System.Windows.Forms.PictureBox pictureBox_result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_distortWay;
        private System.Windows.Forms.Panel panel_bendArg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_bendAngle;
        private System.Windows.Forms.TextBox textBox_bendRadius;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_interpMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel_ballArg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trackBar_ballHeight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_ballRadius;
        private System.Windows.Forms.PictureBox pictureBox_resultFace;
        private System.Windows.Forms.PictureBox pictureBox_aimFace;
        private System.Windows.Forms.PictureBox pictureBox_sourceFace;
        private System.Windows.Forms.ComboBox comboBox_sourceFace;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox_aimFace;
        private System.Windows.Forms.Button button_resultFace;
        private System.Windows.Forms.Button button_blackCut;
        private System.Windows.Forms.ComboBox comboBox_interpFace;
        private System.Windows.Forms.Label label12;
    }
}

