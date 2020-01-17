using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace numBigH1
{
    public class Pic_distort
    {
        public myMat inputImg;
        public myMat resultImg;

        public void setInputImg(Bitmap bm)
        {
            inputImg = new myMat();
            inputImg.getData_bitmap(bm);
        }


        public void ball_distort(double height, string interp_method = "最近邻")
        {
            
            /*
             球形变换，将结果赋予resultImg
             height: 球形变换的高度参数
             */
            resultImg = new myMat();
            double height_abs = System.Math.Abs(height);
            double m = System.Math.Sqrt(inputImg.height * inputImg.height + inputImg.width * inputImg.width) / 2;
            double radius = (height * height + m * m) / 2 / height_abs;
            myMat.myCoor mid_p = new myMat.myCoor(inputImg.height / 2, inputImg.width / 2);
            resultImg.init_bytes(inputImg.height, inputImg.width);
            for (int i = 0; i < inputImg.height; i++)
            {
                for (int j = 0; j < inputImg.width; j++)
                {
                    myMat.myCoor sourceCoor = ball_source_coor(new myMat.myCoor(i, j), mid_p, radius, direction:(int)(height/height_abs));
                    Color c = interp(sourceCoor, interp_method);
                    resultImg.set_rgb(c, new myMat.myCoor(i, j));
                }
            }
        }

        public void bend_distort(double a_max, double radius, string interp_method = "最近邻")
        {
            /*
             弯曲变换，将结果赋予resultImg
             a_max: 最大旋转角度，角度制
             radius: 旋转半径
             */
            resultImg = new myMat();
            double a_max_arc = a_max * System.Math.PI / 180;
            myMat.myCoor mid_p = new myMat.myCoor(inputImg.height / 2, inputImg.width / 2);
            resultImg.init_bytes(inputImg.height, inputImg.width);
            for (int i=0;i<inputImg.height;i++)
            {
                for(int j=0;j<inputImg.width;j++)
                {
                    myMat.myCoor sourceCoor = bend_source_coor(new myMat.myCoor(i, j), mid_p, a_max_arc, radius);
                    Color c = interp(sourceCoor, interp_method);
                    resultImg.set_rgb(c, new myMat.myCoor(i, j));
                }
            }
        }

        public myMat.myCoor bend_source_coor(myMat.myCoor aim_p, myMat.myCoor mid_p, double a_max, double radius) 
        {
            /*
             弯曲变换，输入目标图中的坐标，返回原图坐标
             aim_p: 目标图坐标
             mid_p: 中点坐标
             a_max: 最大旋转角度，弧度制
             radius: 旋转半径
             */

            double dis = aim_p.getDis(mid_p);
            if(dis>=radius)
            {
                return aim_p;
            }

            double a = a_max * (radius - dis) / radius;
            int x_ = (int)(aim_p.j - mid_p.j);
            int y_ = (int)(aim_p.i - mid_p.i);

            myMat.myCoor ord = new myMat.myCoor();
            ord.j = x_ * System.Math.Cos(a) - y_ * System.Math.Sin(a);
            ord.j = ord.j + mid_p.j;
            ord.i = x_ * System.Math.Sin(a) + y_ * System.Math.Cos(a);
            ord.i = ord.i + mid_p.i;

            return ord;
        }

        public myMat.myCoor ball_source_coor(myMat.myCoor aim_p, myMat.myCoor mid_p, double radius, int direction=1)
        {
            /*
             球形畸变，输入目标图中的坐标，返回原图坐标
             aim_p: 目标图坐标
             mid_p: 中点坐标
             radius: 畸变半径
             */

            double dis = aim_p.getDis(mid_p);

            int x_ = (int)(aim_p.j - mid_p.j);
            int y_ = (int)(aim_p.i - mid_p.i);

            myMat.myCoor ord = new myMat.myCoor();

            if(direction>0) //桶形畸变
            {
                ord.j = radius / dis * System.Math.Asin(dis / radius) * x_;
                ord.i = radius / dis * System.Math.Asin(dis / radius) * y_;
            }
            else //枕形畸变
            {
                ord.j = dis / radius / System.Math.Asin(dis / radius) * x_;
                ord.i = dis / radius / System.Math.Asin(dis / radius) * y_;
            }

            ord.j = ord.j + mid_p.j;            
            ord.i = ord.i + mid_p.i;

            if(double.IsNaN(ord.i))
            {
                ord.i = inputImg.height + 1000;
            }
            if (double.IsNaN(ord.j))
            {
                ord.j = inputImg.width + 1000;
            }

            return ord;
        }

        public Color interp(myMat.myCoor source_p, string interp_method)
        {
            if(interp_method=="最近邻")
            {
                return nearest_interp(source_p);
            }
            else if(interp_method=="双线性")
            {
                return bilinear_interp(source_p);
            }
            else
            {
                return bicubic_interp(source_p);
            }
        }

        //最近邻插值
        public Color nearest_interp(myMat.myCoor source_p)
        {
            double i = (int)System.Math.Round(source_p.i);
            double j = (int)System.Math.Round(source_p.j);

            return inputImg.getRGB(new myMat.myCoor(i, j));
        }

        //双线性插值
        public Color bilinear_interp(myMat.myCoor source_p)
        {
            int x1 = (int)System.Math.Floor(source_p.i);
            int y1 = (int)System.Math.Floor(source_p.j);
            int x2 = x1 + 1;
            int y2 = y1 + 1;
            Byte[] f11 = inputImg.getRGB_Byte(new myMat.myCoor(x1, y1));
            Byte[] f12 = inputImg.getRGB_Byte(new myMat.myCoor(x1, y2));
            Byte[] f21 = inputImg.getRGB_Byte(new myMat.myCoor(x2, y1));
            Byte[] f22 = inputImg.getRGB_Byte(new myMat.myCoor(x2, y2));

            double[] fxy1 = new double[3];
            double[] fxy2 = new double[3];
            double[] fxy = new double[3];

            for (int k=0;k<3;k++)
            {
                fxy1[k] = (x2 - source_p.i) / (x2 - x1) * (double)f11[k] + (source_p.i - x1) / (x2 - x1) * (double)f21[k];
                fxy2[k] = (x2 - source_p.i) / (x2 - x1) * (double)f12[k] + (source_p.i - x1) / (x2 - x1) * (double)f22[k];
            }
            for (int k = 0; k < 3; k++)
            {
                fxy[k] = (y2 - source_p.j) / (y2 - y1) * (double)fxy1[k] + (source_p.j - y1) / (y2 - y1) * (double)fxy2[k];
            }

            return inputImg.getRGB_fromB(fxy);
        }

        //双三次插值
        public Color bicubic_interp(myMat.myCoor source_p)
        {
            //x y坐标的小数部分
            int x1 = (int)System.Math.Floor(source_p.i);
            int y1 = (int)System.Math.Floor(source_p.j);
            double dx = source_p.i - x1;
            double dy = source_p.j - y1;

            double[] result = new double[3] {0, 0, 0};
            double k_sum = 0;
            for(int x=-1;x<=2;x++)
            {
                for(int y=-1;y<=2;y++)
                {
                    double dis_x = System.Math.Abs(dx - x);
                    double dis_y = System.Math.Abs(dy - y);
                    double kx = bsp_bicubic_k(dis_x);
                    double ky = bsp_bicubic_k(dis_y);

                    Byte[] fxy = inputImg.getRGB_Byte(new myMat.myCoor(x1 + x, y1 + y));
                    k_sum += kx * ky;
                    for (int k=0;k<3;k++)
                    {
                        result[k] += fxy[k] * kx * ky;
                    }
                }
            }

            for (int k = 0; k < 3; k++)
            {
                result[k] /= k_sum;
            }

            return inputImg.getRGB_fromB(result);
        }

        //B样条曲线函数
        public double bsp_bicubic_k(double dis)
        {
            if (dis >= 0.0 && dis <= 1.0)
            {
                return (2.0 / 3.0) + (0.5) * System.Math.Pow(dis, 3) - (dis * dis);
            }
            else if (dis > 1.0 && dis <= 2.0)
            {
                return 1.0 / 6.0 * System.Math.Pow((2.0 - dis), 3.0);
            }
            else
            {
                return 1.0;
            }
        }
    }
}
