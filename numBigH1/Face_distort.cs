using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/*using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;*/

namespace numBigH1
{
    class Face_distort
    {
        static int point_num = 68; //每张图片有68个特征点

        public Pic_distort sourceFace_distort;
        public double[,] source_ps;
        public double[,] aim_ps;
        public Pic_distort blackCut_distort; //切除黑边所用对象
        myMat.myCoor leftUp_point;
        myMat.myCoor leftDown_point;

        public double[,] W; //坐标变换所用参数

        //保存原图像
        public void set_source_img(Bitmap bm)
        {
            sourceFace_distort = new Pic_distort();
            sourceFace_distort.setInputImg(bm);
        }

        //保存脸部特征点位置
        public static void set_ps(int pic_num, out double[,] ps, double scale, Bitmap bm)
        {
            ps = new double[68, 2];

            System.IO.StreamReader file = new System.IO.StreamReader(@"face-images\"+pic_num.ToString()+".txt");
            string line;
            int i = 0;
            while ((line = file.ReadLine()) != null)
            {
                string[] nums = line.Split(' ');
                double x, y;
                double.TryParse(nums[1], out x);
                double.TryParse(nums[0], out y); //nums[0]是和左边缘的距离，和图像上的坐标系相同，和矩阵中的坐标系相反
                ps[i, 0] = x*scale;
                ps[i, 1] = y*scale; 
                i += 1;
            }

            /*Image<Bgr, byte> draw_img = new Image<Bgr, byte>(bm);//new Image<Bgr, byte>("face-images\\" + pic_num.ToString() + ".jpg");
            for (int j=0;j<point_num;j++)
            {
                draw_img.Draw(new Cross2DF(new PointF((int)ps[j, 1], (int)ps[j, 0]), 10, 10), new Bgr(0, 0, 0), 2);
            }
            
            CvInvoke.Imshow("a", draw_img);
            CvInvoke.WaitKey();*/
        }

        //使用原图特征点和目标图特征点位置求出参数矩阵W
        public void get_W()
        {
            int point_num = Face_distort.point_num;

            //首先将目标脸型图的特征点平移到原脸型图特征点附近位置，避免原图产生过大的位置变形
            double x_delta = source_ps[0, 0] - aim_ps[0, 0];
            double y_delta = source_ps[0, 1] - aim_ps[0, 1];
            for (int i = 0; i < point_num;i++)
            {
                aim_ps[i, 0] = aim_ps[i, 0] + x_delta;
                aim_ps[i, 1] = aim_ps[i, 1] + y_delta;
            }

            double [,] L = new double[point_num+3, point_num+3];
            //double [,] K = new double[point_num, point_num];
            //double[,] P = new double[point_num, 3];
            //double[,] P_T = new double[point_num, 3]; //P的转置
            double[,] V = new double[point_num+3, 2];
            W = new double[point_num + 3, 2];

            //求出K
            for(int i=0;i<point_num;i++)
            {
                for(int j=0;j<point_num;j++)
                {
                    double dis = System.Math.Pow(aim_ps[i, 0] - aim_ps[j, 0], 2) + System.Math.Pow(aim_ps[i, 1] - aim_ps[j, 1], 2);
                    if(dis==0)
                    {
                        dis += 1e-16;
                    }
                    L[i, j] = dis * System.Math.Log(dis) / 2;
                }
            }

            //求出P和P_T
            for (int i = 0; i < point_num; i++)
            {
                L[i, point_num] = 1;
                L[i, point_num + 1] = aim_ps[i, 0];
                L[i, point_num + 2] = aim_ps[i, 1];

                L[point_num, i] = 1;
                L[point_num + 1, i] = aim_ps[i, 0];
                L[point_num + 2, i] = aim_ps[i, 1];
            }

            for(int i=point_num;i<point_num+3;i++)
            {
                for(int j=point_num;j<point_num+3;j++)
                {
                    L[i,j] = 0;
                }
            }

            //得到V
            for(int i=0;i<point_num;i++)
            {
                V[i, 0] = source_ps[i, 0];
                V[i, 1] = source_ps[i, 1];
            }
            for (int i = point_num; i < point_num+3; i++)
            {
                V[i, 0] = 0;
                V[i, 1] = 0;
            }

            
            //求解线性方程组L*W=V，使用列主元素消去法
            //消去主元，使L变成上三角矩阵
            for(int j=0;j<point_num+2;j++)
            {
                //找到L第j列最大的主元并放到第j行
                max_principleRow(ref L, ref W, ref V, j);
                if(L[j, j]<=double.MinValue)
                {
                    L[j, j] = 1e-16;
                }


                //消去第j列第j行下面的元素
                //第i行减第j行
                for(int i=j+1;i<point_num+3;i++)
                {
                    double scale = L[i, j] / L[j, j];
                    L[i, j] = 0;
                    //第j列后面元素的相减
                    for(int col=j+1;col<point_num+3;col++)
                    {
                        L[i, col] -= scale * L[j, col];
                    }

                    W[i, 0] -= scale * W[j, 0];
                    W[i, 1] -= scale * W[j, 1];

                    V[i, 0] -= scale * V[j, 0];
                    V[i, 1] -= scale * V[j, 1];
                }
            }

            for(int k=point_num+2;k>=0;k--)
            {
                double[] result = new double[2];
                result[0] = V[k, 0];
                result[1] = V[k, 1];

                for (int j=k+1;j<point_num+3;j++)
                {
                    result[0] -= W[j, 0] * L[k, j];
                    result[1] -= W[j, 1] * L[k, j];
                }
                W[k, 0] = result[0] / L[k, k];
                W[k, 1] = result[1] / L[k, k];
            }
        }

        //找到第j列最大的主元并放到第j行
        public static void max_principleRow(ref double[,] L, ref double[,] W, ref double[,] V, int j)
        {
            double max_value = L[j, j];
            int max_index = j;
            for(int i=j+1;i<Face_distort.point_num+3;i++)
            {
                if(L[i, j]>max_value)
                {
                    max_value = L[i, j];
                    max_index = i;
                }
            }

            if(max_index==j)
            {
                return;
            }

            for(int col=j;col<Face_distort.point_num+3;col++)
            {
                switch_ab(ref L[j, col], ref L[max_index, col]);
            }

            switch_ab(ref W[j, 0], ref W[max_index, 0]);
            switch_ab(ref W[j, 1], ref W[max_index, 1]);

            switch_ab(ref V[j, 0], ref V[max_index, 0]);
            switch_ab(ref V[j, 1], ref V[max_index, 1]);
        }

        public static void switch_ab(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }

        //使用参数矩阵W求得目标图
        public void get_result_img(string interp_method)
        {
            myMat.myCoor source_leftUp_point = new myMat.myCoor(in_i: sourceFace_distort.inputImg.height, in_j: sourceFace_distort.inputImg.width); //初始化为右下角点
            myMat.myCoor source_leftDown_point = new myMat.myCoor(in_i: 0, in_j: sourceFace_distort.inputImg.width); //初始化为右上角点
            leftUp_point = new myMat.myCoor(); //初始化为右下角点
            leftDown_point = new myMat.myCoor(); //初始化为右上角点
            myMat.myCoor vir_leftUp_point = new myMat.myCoor(0, 0);
            myMat.myCoor vir_leftDown_point = new myMat.myCoor(sourceFace_distort.inputImg.height, 0);

            sourceFace_distort.resultImg = new myMat();
            sourceFace_distort.resultImg.init_bytes(sourceFace_distort.inputImg.height, sourceFace_distort.inputImg.width);
            for(int i=0;i<sourceFace_distort.inputImg.height;i++)
            {
                for(int j=0;j<sourceFace_distort.inputImg.width;j++)
                {
                    //得到目标图中第i行i列坐标对应原图中的坐标
                    myMat.myCoor sourceCoor = TPS_get_sourceCoor(i, j);

                    if(sourceCoor.i>=0 && sourceCoor.j>=0 && sourceCoor.i<sourceFace_distort.inputImg.height && sourceCoor.j<sourceFace_distort.inputImg.width)
                    {
                        if(myMat.myCoor.getDis(sourceCoor, vir_leftUp_point)< myMat.myCoor.getDis(source_leftUp_point, vir_leftUp_point))
                        {
                            source_leftUp_point.i = sourceCoor.i; source_leftUp_point.j = sourceCoor.j;
                            leftUp_point.i = i;leftUp_point.j = j;
                        }

                        if (myMat.myCoor.getDis(sourceCoor, vir_leftDown_point) < myMat.myCoor.getDis(source_leftDown_point, vir_leftDown_point))
                        {
                            source_leftDown_point.i = sourceCoor.i; source_leftDown_point.j = sourceCoor.j;
                            leftDown_point.i = i;leftDown_point.j = j;
                        }
                    }
                    
                    
                    Color c = sourceFace_distort.interp(sourceCoor, interp_method);
                    sourceFace_distort.resultImg.set_rgb(c, new myMat.myCoor(i, j));
                }
            }
        }

        //TPS变换得到目标图中第i行i列坐标对应原图中的坐标
        public myMat.myCoor TPS_get_sourceCoor(int i, int j)
        {
            double source_x = 0, source_y = 0;
            for (int k = 0; k < point_num; k++)
            {
                double dis = System.Math.Pow(i - aim_ps[k, 0], 2) + System.Math.Pow(j - aim_ps[k, 1], 2);
                if (dis == 0)
                {
                    dis += 1e-16;
                }
                double L_k = dis * System.Math.Log(dis) / 2;
                source_x += L_k * W[k, 0];
                source_y += L_k * W[k, 1];
            }

            source_x += W[point_num, 0] * 1;
            source_x += W[point_num + 1, 0] * i;
            source_x += W[point_num + 2, 0] * j;

            source_y += W[point_num, 1] * 1;
            source_y += W[point_num + 1, 1] * i;
            source_y += W[point_num + 2, 1] * j;

            myMat.myCoor sourceCoor = new myMat.myCoor(source_x, source_y);
            return sourceCoor;
        }

        //切除黑边
        public void BlackCut_tran(string interp_method = "最近邻")
        {
            blackCut_distort = new Pic_distort();

            blackCut_distort.inputImg = new myMat();
            blackCut_distort.inputImg.getData_Mat(sourceFace_distort.resultImg);
            blackCut_distort.resultImg = new myMat();
            blackCut_distort.resultImg.init_bytes(blackCut_distort.inputImg.height, blackCut_distort.inputImg.width);

            /*Bitmap bm = blackCut_distort.inputImg.img2Bitmap();
            Image<Bgr, byte> draw_img = new Image<Bgr, byte>(bm);
            draw_img.Draw(new Cross2DF(new PointF((int)leftUp_point.j, (int)leftUp_point.i), 10, 10), new Bgr(0, 0, 255), 2);
            draw_img.Draw(new Cross2DF(new PointF((int)leftDown_point.j, (int)leftDown_point.i), 10, 10), new Bgr(0, 0, 255), 2);

            CvInvoke.Imshow("a", draw_img);
            CvInvoke.WaitKey();*/

            double turn_angle = System.Math.Atan2((leftDown_point.j - leftUp_point.j), (leftDown_point.i - leftUp_point.i));
            double height_scale = myMat.myCoor.getDis(leftUp_point, leftDown_point) / blackCut_distort.resultImg.height;
            for (int i=0;i<blackCut_distort.inputImg.height;i++)
            {
                for(int j=0;j<blackCut_distort.inputImg.width;j++)
                {
                    if(i==blackCut_distort.inputImg.height-3 && j==0)
                    {
                        int a = 0;
                    }
                    myMat.myCoor sourceCoor = Turn_get_sourceCoor(i, j, turn_angle);
                    sourceCoor.i *= height_scale;
                    sourceCoor.j *= height_scale;
                    sourceCoor.i += (int)leftUp_point.i;
                    sourceCoor.j += (int)leftUp_point.j;
                    Color c = blackCut_distort.interp(sourceCoor, interp_method);
                    blackCut_distort.resultImg.set_rgb(c, new myMat.myCoor(i, j));
                }
            }

            /*Bitmap bm2 = blackCut_distort.resultImg.img2Bitmap();
            Image<Bgr, byte> draw_img2 = new Image<Bgr, byte>(bm2);

            CvInvoke.Imshow("a", draw_img2);
            CvInvoke.WaitKey();*/

            int min_y, max_y, max_x, min_x;
            blackCut_getIJ(out min_y, out max_y, out min_x, out max_x);

            int new_height = max_x - min_x + 1;
            int new_width = max_y - min_y + 1;
            for(int i = 0;i<new_height;i++)
            {
                for(int j = 0;j<new_width;j++)
                {
                    int i_cut = min_x + i;
                    int j_cut = min_y + j;
                    Color source_color = blackCut_distort.resultImg.getRGB(new myMat.myCoor(i_cut, j_cut));
                    blackCut_distort.resultImg.set_rgb(source_color, new myMat.myCoor(i, j));
                }
            }
            blackCut_distort.resultImg.height = new_height;
            blackCut_distort.resultImg.width = new_width;
        }

        //旋转变换 返回原图中对应坐标点
        public myMat.myCoor Turn_get_sourceCoor(int i, int j, double turn_angle)
        {
            double x, y;
            x = i * System.Math.Cos(turn_angle) - j * System.Math.Sin(turn_angle);
            y = i * System.Math.Sin(turn_angle) + j * System.Math.Cos(turn_angle);
            myMat.myCoor sourceCoor = new myMat.myCoor(x, y);
            return sourceCoor;
        }

        //切除黑边，得到切除范围
        public void blackCut_getIJ(out int min_y, out int max_y, out int min_x, out int max_x)
        {
            min_y = 0;
            max_y = blackCut_distort.resultImg.width - 1;
            for (int i = blackCut_distort.resultImg.height/4; i < blackCut_distort.resultImg.height*3/4; i++)
            {
                for (int j = 0; j < blackCut_distort.resultImg.width / 4; j++)
                {
                    if (!blackCut_distort.resultImg.isBlack(i, j))
                    {
                        if (j > min_y)
                        {
                            min_y = j;
                        }
                        break;
                    }
                }

                for (int j = blackCut_distort.resultImg.width - 1; j >= blackCut_distort.resultImg.width * 3 / 4; j--)
                {
                    if (!blackCut_distort.resultImg.isBlack(i, j))
                    {
                        if (j < max_y)
                        {
                            max_y = j;
                        }
                        break;
                    }
                }
            }

            min_x = 0;
            max_x = blackCut_distort.resultImg.height - 1;
            for (int j = blackCut_distort.resultImg.width/4; j < blackCut_distort.resultImg.width*3/4; j++)
            {
                for (int i = 0; i < blackCut_distort.resultImg.height / 4; i++)
                {
                    if (!blackCut_distort.resultImg.isBlack(i, j))
                    {
                        if (i > min_x)
                        {
                            min_x = i;
                        }
                        break;
                    }
                }

                for (int i = blackCut_distort.resultImg.height - 1; i >= blackCut_distort.resultImg.height * 3 / 4; i--)
                {
                    if (!blackCut_distort.resultImg.isBlack(i, j))
                    {
                        if (i < max_x)
                        {
                            max_x = i;
                        }
                        break;
                    }
                }
            }
        }
    }
}
