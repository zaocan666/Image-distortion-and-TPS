using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace numBigH1
{
    //自定义矩阵类
    public class myMat
    {
        public byte[,,] img_data;
        public int height;
        public int width;

        //自定义坐标类
        public class myCoor
        {
            public double i;
            public double j;

            public myCoor(double in_i = 0, double in_j = 0)
            {
                i = in_i;
                j = in_j;
            }

            //求距离
            public static double getDis(myCoor p2, myCoor p1)
            {
                double di2 = (p1.i - p2.i) * (p1.i - p2.i);
                double dj2 = (p1.j - p2.j) * (p1.j - p2.j);
                return System.Math.Sqrt((double)(di2 + dj2));
            }

            public double getDis(myCoor p2)
            {
                double di2 = (i - p2.i) * (i - p2.i);
                double dj2 = (j - p2.j) * (j - p2.j);
                return System.Math.Sqrt((double)(di2 + dj2));
            }
        }

        //初始化
        public void init_bytes(int in_height, int in_width)
        {
            width = in_width;
            height = in_height;
            img_data = new byte[height, width, 3];
        }

        //从bitmap中得到矩阵值
        public void getData_bitmap(Bitmap bm)
        {
            init_bytes(bm.Height, bm.Width);
            height = bm.Height;
            width = bm.Width;

            for (int i = 0; i < bm.Height; i++)
            {
                for (int j = 0; j < bm.Width; j++)
                {
                    img_data[i, j, 0] = bm.GetPixel(j, i).R;
                    img_data[i, j, 1] = bm.GetPixel(j, i).G;
                    img_data[i, j, 2] = bm.GetPixel(j, i).B;
                }
            }
        }

        //从mat中得到矩阵值
        public void getData_Mat(myMat mat)
        {
            init_bytes(mat.height, mat.width);

            for (int i = 0; i < mat.height; i++)
            {
                for (int j = 0; j < mat.width; j++)
                {
                    img_data[i, j, 0] = mat.img_data[i, j, 0];
                    img_data[i, j, 1] = mat.img_data[i, j, 1];
                    img_data[i, j, 2] = mat.img_data[i, j, 2];
                }
            }
        }

        //返回某点的RGB数组值
        public byte[] getRGB_Byte(myCoor coor)
        {
            Color c = getRGB(coor);
            byte[] result = new byte[3];
            result[0] = c.R;
            result[1] = c.G;
            result[2] = c.B;
            return result;
        }

        //返回某点的RGB Color
        public Color getRGB_fromB(double[] b)
        {
            Color c = Color.FromArgb((int)b[0], (int)b[1], (int)b[2]);
            return c;
        }

        public Color getRGB(myCoor coor)
        {
            if (coorInRange(coor))
            {
                Color c = Color.FromArgb(img_data[(int)coor.i, (int)coor.j, 0], img_data[(int)coor.i, (int)coor.j, 1], img_data[(int)coor.i, (int)coor.j, 2]);
                return c;
            }
            else
            {
                Color c = Color.FromArgb(0, 0, 0);
                return c;
            }
        }

        //设置矩阵某点的值
        public void set_rgb(Color input_color, myCoor this_coor)
        {
            if (this_coor.i < 0 || this_coor.i >= height || this_coor.j<0 || this_coor.j >= width)
            {
                return;
            }
            img_data[(int)this_coor.i, (int)this_coor.j, 0] = input_color.R;
            img_data[(int)this_coor.i, (int)this_coor.j, 1] = input_color.G;
            img_data[(int)this_coor.i, (int)this_coor.j, 2] = input_color.B;
        }

        //向bitmap中填充矩阵的值
        public Bitmap img2Bitmap()
        {
            Bitmap bitmap = new Bitmap(width:width, height:height);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Color c = Color.FromArgb(img_data[i, j, 0], img_data[i, j, 1], img_data[i, j, 2]);
                    bitmap.SetPixel(j, i, c);
                }
            }

            return bitmap;
        }

        //判断坐标coor是否在图像范围内
        public bool coorInRange(myCoor coor)
        {
            if(coor.i>=height || coor.j>=width)
            {
                return false;
            }
            else if(coor.i<0 || coor.j<0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //判断矩阵某一点是否为纯黑色
        public bool isBlack(int i, int j)
        {
            if(img_data[i, j, 0]==0 && img_data[i, j, 1] == 0 && img_data[i, j, 2] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
