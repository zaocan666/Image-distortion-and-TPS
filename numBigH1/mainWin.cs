using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace numBigH1
{
    public partial class mainWin : Form
    {
        Pic_distort distort_class=null;
        Face_distort face_class = null;
        Bitmap resultFace_bm;

        public mainWin()
        {
            InitializeComponent();
            comboBox_distortWay.SelectedIndex = 0;
            comboBox_interpMethod.SelectedIndex = 0;
            comboBox_interpFace.SelectedIndex = 0;
            trackBar_ballHeight.Maximum = 21;
            trackBar_ballHeight.Value = trackBar_ballHeight.Maximum / 2;

            face_class = new Face_distort();
        }

        //必做任务 输入图像选择
        private void button_inputImg_Click(object sender, EventArgs e)
        {
            openFileDialog_inputImg.Filter = "图片文件(*.jpg,*.bmp,*.png)|*.jpg;*.bmp;*.png";
            if (openFileDialog_inputImg.ShowDialog() == DialogResult.OK)
            {
                string img_path = openFileDialog_inputImg.FileName; //图片路径
                //Mat img = CvInvoke.Imread(img_path);
                Bitmap bm_source = show_img(img_path, pictureBox_inputImg);

                distort_class = new Pic_distort();
                distort_class.setInputImg(bm_source);
            }
        }

        //显示图像
        public Bitmap show_img(string img_path, PictureBox pic_box)
        {
            Bitmap bm_source = new Bitmap(Image.FromFile(img_path));
            Bitmap bm = new Bitmap(Image.FromFile(img_path), pic_box.Width, pic_box.Height);
            pic_box.Image = bm;
            return bm_source;
        }

        //调整为合适大小后显示图像
        public Bitmap show_img_resize(string img_path, PictureBox pic_box, out double scale)
        {
            int middle_x = pic_box.Left + pic_box.Width / 2;
            int middle_y = pic_box.Top + pic_box.Height / 2;
           
            Bitmap bm_source = new Bitmap(Image.FromFile(img_path));
            int max_size = System.Math.Max(bm_source.Width, bm_source.Height);
            scale = 400.0 / max_size;
            Bitmap bm = new Bitmap(Image.FromFile(img_path), (int)(bm_source.Width*scale), (int)(bm_source.Height*scale));
 
            pic_box.Size = new Size(bm.Width, bm.Height);
            pic_box.Left = middle_x - pic_box.Width / 2;
            pic_box.Top = middle_y - pic_box.Height / 2;

            pic_box.Image = bm;
            return bm;
        }

        public void show_img_resize(Bitmap bm_source, PictureBox pic_box)
        {
            int middle_x = pic_box.Left + pic_box.Width / 2;
            int middle_y = pic_box.Top + pic_box.Height / 2;

            int max_size = System.Math.Max(bm_source.Width, bm_source.Height);
            double scale = 400.0 / max_size;

            Bitmap bm = new Bitmap(bm_source.Width, bm_source.Height);
            using (Graphics g = Graphics.FromImage(bm))
            {
                g.DrawImage(bm_source, 0, 0, (int)(bm_source.Width * scale), (int)(bm_source.Height * scale));
            }

            pic_box.Size = new Size(bm.Width, bm.Height);
            pic_box.Left = middle_x - pic_box.Width / 2;
            pic_box.Top = middle_y - pic_box.Height / 2;

            pic_box.Image = bm;
        }

        public void show_img(Bitmap bm_source, PictureBox pic_box)
        {
            Bitmap bm = new Bitmap(bm_source.Width, bm_source.Height);
            using (Graphics g = Graphics.FromImage(bm))
            {
                g.DrawImage(bm_source, 0, 0, pic_box.Width, pic_box.Height);
            }
            
            pic_box.Image = bm;
        }

        //必做任务 得到结果图
        private void button_distort_start_Click(object sender, EventArgs e)
        {
            /*int x1 = (int)System.Math.Floor(2.4);
            int x2 = (int)System.Math.Round(2.4);
            int x3 = (int)System.Math.Round(2.6);
            int x4 = (int)System.Math.Round(2.5);
            int x5 = (int)System.Math.Floor(1.5);*/

            DialogResult dr;
            if (distort_class==null)
            {
                dr = MessageBox.Show("您还未打开原图片！", "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            string interp_method = comboBox_interpMethod.Text;
            string distort_method = comboBox_distortWay.Text;
            if (distort_method == "旋转扭曲")
            {
                double angle, radius;
                bool parse_bool = (double.TryParse(textBox_bendAngle.Text, out angle)) & (double.TryParse(textBox_bendRadius.Text, out radius));
                if ((!parse_bool) || radius < 0)
                {
                    dr = MessageBox.Show("旋转角度或直径输入形式错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                distort_class.bend_distort(angle, radius, interp_method);
            }
            else
            {
                double ball_height;
                double m = System.Math.Sqrt(distort_class.inputImg.height * distort_class.inputImg.height + distort_class.inputImg.width * distort_class.inputImg.width) / 2;
                double height = (trackBar_ballHeight.Value - trackBar_ballHeight.Maximum / 2.0);
                ball_height = m / (trackBar_ballHeight.Maximum / 2) * height;//得到用户选择的桶形变换高度

                distort_class.ball_distort( interp_method: interp_method, height:ball_height);
            }
            
            Bitmap bm_source = distort_class.resultImg.img2Bitmap();
            show_img(bm_source, pictureBox_result);

            dr = MessageBox.Show("扭曲完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        //必做任务 扭曲方式变化
        private void comboBox_distortWay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_distortWay.SelectedItem.ToString()=="旋转扭曲")
            {
                panel_bendArg.Visible = true;
                panel_ballArg.Visible = false;
               
            }
            else
            {
                panel_bendArg.Visible = false;
                panel_ballArg.Visible = true;
            }
        }

        private void trackBar_ballHeight_Scroll(object sender, EventArgs e)
        {
            set_ballHeight_label();
        }

        public void set_ballHeight_label()
        {
            double m, radius;
            if(distort_class==null)
            {
                return;
                
            }
            else
            {
                m = System.Math.Sqrt(distort_class.inputImg.height * distort_class.inputImg.height + distort_class.inputImg.width * distort_class.inputImg.width) / 2;
            }

            double height = System.Math.Abs(trackBar_ballHeight.Value-trackBar_ballHeight.Maximum/2.0);
            height = m / (trackBar_ballHeight.Maximum / 2) * height;
           
            radius = (height * height + m * m) / 2 / height;
            label_ballRadius.Text = "畸变半径："+((int)radius).ToString();
        }

        //选做任务 原图片改变
        private void comboBox_sourceFace_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pic_num = comboBox_sourceFace.SelectedIndex+1;
            string pic_root = "face-images\\"+pic_num.ToString()+".jpg";
            if(!File.Exists(pic_root))
            {
                DialogResult dr = MessageBox.Show("请将face-images文件夹放到项目bin/Release或Debug目录下！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            double scale;
            Bitmap sourceFace_bm = show_img_resize(pic_root, pictureBox_sourceFace, out scale);

            face_class.set_source_img(sourceFace_bm);
            Face_distort.set_ps(pic_num, out face_class.source_ps, scale, sourceFace_bm);
        }

        //选做任务 目标图片改变
        private void comboBox_aimFace_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pic_num = comboBox_aimFace.SelectedIndex + 1;
            string pic_root = "face-images\\" + pic_num.ToString() + ".jpg";
            
            if (!File.Exists(pic_root))
            {
                DialogResult dr = MessageBox.Show("请将face-images文件夹放到项目bin/Release或Debug目录下！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double scale;
            Bitmap bm_source = show_img_resize(pic_root, pictureBox_aimFace, out scale);

            Face_distort.set_ps(pic_num, out face_class.aim_ps, scale, bm_source);
        }

        //选做任务 获得结果图片
        private void button_resultFace_Click(object sender, EventArgs e)
        {
            if(face_class.aim_ps==null || face_class.source_ps==null)
            {
                DialogResult dr;
                dr = MessageBox.Show("您还未选择原图片和目标图片！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            face_class.get_W();
            string interp_method = comboBox_interpFace.Text;
            face_class.get_result_img(interp_method);
            resultFace_bm = face_class.sourceFace_distort.resultImg.img2Bitmap();
            show_img_resize(resultFace_bm, pictureBox_resultFace);
        }

        //选做任务 切除黑边
        private void button_blackCut_Click(object sender, EventArgs e)
        {
            if (face_class.sourceFace_distort.resultImg == null)
            {
                DialogResult dr;
                dr = MessageBox.Show("您还未生成扭曲结果！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string interp_method = comboBox_interpFace.Text;
            face_class.BlackCut_tran(interp_method:interp_method);
            Bitmap bm_source = face_class.blackCut_distort.resultImg.img2Bitmap();
            show_img_resize(bm_source, pictureBox_resultFace);
        }
    }
}
