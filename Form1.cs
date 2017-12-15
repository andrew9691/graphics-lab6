using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        polyhedron phdrn = new polyhedron();

        class point3d
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }

            public point3d(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public point3d clone()
            {
                return (point3d)this.MemberwiseClone();
            }

			public static bool operator ==(point3d p1, point3d p2)
			{
				return p1.X == p2.X && p1.Y == p2.Y && p1.Z == p2.Z;
			}

			public static bool operator !=(point3d p1, point3d p2)
			{
				return !(p1 == p2);
			}

            public void sub_scale(double mx, double my, double mz)
            {
                // Getting identity matrix
                List<List<double>> scale_mat = new List<List<double>>(4);
                for (int i = 0; i < 4; i++)
                    scale_mat.Add(new List<double>(4));
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (i == j)
                            scale_mat[i].Add(1);
                        else
                            scale_mat[i].Add(0);

                scale_mat[0][0] = mx;
                scale_mat[1][1] = my;
                scale_mat[2][2] = mz;

                List<double> new_cords = mats_mult(new List<double> { X, Y, Z, 1 }, scale_mat);

                X = new_cords[0];
                Y = new_cords[1];
                Z = new_cords[2];
            }
        }

        class edge
        {
            Graphics g;
            PictureBox pb;
            public point3d p1, p2;

            public edge(Graphics g, PictureBox pb, ref point3d p1, ref point3d p2)
            {
                this.p1 = p1;
                this.p2 = p2;
                this.g = g;
                this.pb = pb;
            }

			public static bool operator ==(edge e1, edge e2)
			{
				return e1.p1 == e2.p1 && e1.p2 == e2.p2;
			}

			public static bool operator !=(edge e1, edge e2)
			{
				return !(e1 == e2);
			}

			public void draw()
            {
                int centerX = pb.Width / 2;
                int centerY = pb.Height/ 2;
                g.DrawLine(new Pen(Color.Black), (int)p1.X + centerX, (int)p1.Y + centerY, (int)p2.X + centerX, (int)p2.Y + centerY);
            }

            public void sub_trans(int tx, int ty, int tz)
            {
				// Getting identity matrix
				List<List<double>> trans_mat = new List<List<double>>(4);
                for (int i = 0; i < 4; i++)
                    trans_mat.Add(new List<double>(4));
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (i == j)
                            trans_mat[i].Add(1);
                        else
                            trans_mat[i].Add(0);
                trans_mat[3][0] = tx;
                trans_mat[3][1] = ty;
                trans_mat[3][2] = tz;

                List<double> p1_new_cords = mats_mult(new List<double> { p1.X, p1.Y, p1.Z, 1 }, trans_mat);
                List<double> p2_new_cords = mats_mult(new List<double> { p2.X, p2.Y, p2.Z, 1 }, trans_mat);

                p1.X = p1_new_cords[0];
                p1.Y = p1_new_cords[1];
                p1.Z = p1_new_cords[2];
                p2.X = p2_new_cords[0];
                p2.Y = p2_new_cords[1];
                p2.Z = p2_new_cords[2];
            }

            public void sub_rotateX(double angle)
            {
                double cos = Math.Cos(angle);
                double sin = Math.Sin(angle);

                // Getting identity matrix
                List<List<double>> rotateX_mat = new List<List<double>>(4);
                for (int i = 0; i < 4; i++)
                    rotateX_mat.Add(new List<double>(4));

                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (i == j)
                            rotateX_mat[i].Add(1);
                        else
                            rotateX_mat[i].Add(0);

                rotateX_mat[1][1] = cos;
                rotateX_mat[1][2] = -sin;
                rotateX_mat[2][1] = sin;
                rotateX_mat[2][2] = cos;

                List<double> p1_new_cords = mats_mult(new List<double> { p1.X, p1.Y, p1.Z, 1 }, rotateX_mat);
                List<double> p2_new_cords = mats_mult(new List<double> { p2.X, p2.Y, p2.Z, 1 }, rotateX_mat);

                p1.X = p1_new_cords[0];
                p1.Y = p1_new_cords[1];
                p1.Z = p1_new_cords[2];
                p2.X = p2_new_cords[0];
                p2.Y = p2_new_cords[1];
                p2.Z = p2_new_cords[2];
            }

            public void sub_rotateY(double angle)
            {
                double cos = Math.Cos(angle);
                double sin = Math.Sin(angle);

                // Getting identity matrix
                List<List<double>> rotateY_mat = new List<List<double>>(4);
                for (int i = 0; i < 4; i++)
                    rotateY_mat.Add(new List<double>(4));
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (i == j)
                            rotateY_mat[i].Add(1);
                        else
                            rotateY_mat[i].Add(0);

                rotateY_mat[0][0] = cos;
                rotateY_mat[0][2] = sin;
                rotateY_mat[2][0] = -sin;
                rotateY_mat[2][2] = cos;

                List<double> p1_new_cords = mats_mult(new List<double> { p1.X, p1.Y, p1.Z, 1 }, rotateY_mat);
                List<double> p2_new_cords = mats_mult(new List<double> { p2.X, p2.Y, p2.Z, 1 }, rotateY_mat);

                p1.X = p1_new_cords[0];
                p1.Y = p1_new_cords[1];
                p1.Z = p1_new_cords[2];
                p2.X = p2_new_cords[0];
                p2.Y = p2_new_cords[1];
                p2.Z = p2_new_cords[2];
            }

            public void sub_rotateZ(double angle)
            {
                double cos = Math.Cos(angle);
                double sin = Math.Sin(angle);

                // Getting identity matrix
                List<List<double>> rotateZ_mat = new List<List<double>>(4);
                for (int i = 0; i < 4; i++)
                    rotateZ_mat.Add(new List<double>(4));
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (i == j)
                            rotateZ_mat[i].Add(1);
                        else
                            rotateZ_mat[i].Add(0);

                rotateZ_mat[0][0] = cos;
                rotateZ_mat[0][1] = -sin;
                rotateZ_mat[1][0] = sin;
                rotateZ_mat[1][1] = cos;

                List<double> p1_new_cords = mats_mult(new List<double> { p1.X, p1.Y, p1.Z, 1 }, rotateZ_mat);
                List<double> p2_new_cords = mats_mult(new List<double> { p2.X, p2.Y, p2.Z, 1 }, rotateZ_mat);

                p1.X = p1_new_cords[0];
                p1.Y = p1_new_cords[1];
                p1.Z = p1_new_cords[2];
                p2.X = p2_new_cords[0];
                p2.Y = p2_new_cords[1];
                p2.Z = p2_new_cords[2];
            }
		}

		class polygon
        {
            public List<edge> le;

            public polygon()
            {
                le = new List<edge>();
            }

            public void add(edge e)
            {
                le.Add(e);
            }

            public void draw()
            {
                foreach(edge e in le)
                    e.draw();
            }
        }

        class polyhedron
        {
            private List<polygon> lp;
			private List<edge> polygon_edges;

            public polyhedron()
            {
                lp = new List<polygon>();
				polygon_edges = new List<edge>();
            }

            public void add(polygon p)
            {
                lp.Add(p);
				foreach (edge e in p.le)
					if (!polygon_edges.Contains(e))
						polygon_edges.Add(e);
            }

            public void draw()
            {
                foreach (edge e in polygon_edges)
                    e.draw();
            }

            public void translate(int tx, int ty, int tz)
            {
                foreach (edge e in polygon_edges)
                    e.sub_trans(tx, ty, tz);
            }

            public void rotateX(double angle)
            {
                foreach (edge e in polygon_edges)
                    e.sub_rotateX(angle);
            }

            public void rotateY(double angle)
            {
                foreach (edge e in polygon_edges)
                    e.sub_rotateY(angle);
            }

            public void rotateZ(double angle)
            {
                foreach (edge e in polygon_edges)
                    e.sub_rotateZ(angle);
            }

            public void scale(double mx, double my, double mz)
            {
                List<point3d> unique_pts = new List<point3d>();
                foreach (edge e in polygon_edges)
                {
                    if (!unique_pts.Contains(e.p1))
                    {
                        e.p1.sub_scale(mx, my, mz);
                        unique_pts.Add(e.p1);
                    }
                    if (!unique_pts.Contains(e.p2))
                    {
                        e.p2.sub_scale(mx, my, mz);
                        unique_pts.Add(e.p2);
                    }
                }
            }

            public void reflectX()
            {
                List<point3d> unique_pts = new List<point3d>();
                foreach (edge e in polygon_edges)
                {
                    if (!unique_pts.Contains(e.p1))
                    {
                        e.p1.X *= -1;
                        unique_pts.Add(e.p1);
                    }
                    if (!unique_pts.Contains(e.p2))
                    {
                        e.p2.X *= -1;
                        unique_pts.Add(e.p2);
                    }
                }
            }

            public void reflectY()
            {
                List<point3d> unique_pts = new List<point3d>();
                foreach (edge e in polygon_edges)
                {
                    if (!unique_pts.Contains(e.p1))
                    {
                        e.p1.Y *= -1;
                        unique_pts.Add(e.p1);
                    }
                    if (!unique_pts.Contains(e.p2))
                    {
                        e.p2.Y *= -1;
                        unique_pts.Add(e.p2);
                    }
                }
            }

            public void reflectZ()
            {
                List<point3d> unique_pts = new List<point3d>();
                foreach (edge e in polygon_edges)
                {
                    if (!unique_pts.Contains(e.p1))
                    {
                        e.p1.Z *= -1;
                        unique_pts.Add(e.p1);
                    }
                    if (!unique_pts.Contains(e.p2))
                    {
                        e.p2.Z *= -1;
                        unique_pts.Add(e.p2);
                    }
                }
            }
        }

        static polyhedron tetrahedron(Graphics g, PictureBox pb, int size)
        {
            double h = size * Math.Sqrt(3);

            point3d p1 = new point3d(-size, (int)-h / 2, (int)-h / 2);
            point3d p2 = new point3d(size, (int)-h / 2, (int)-h / 2);
            point3d p3 = new point3d(0, (int)-h / 2, (int)h / 2);
            point3d p4 = new point3d(0, (int)h / 2, 0);
            
            edge e1 = new edge(g, pb, ref p1, ref p2);
            edge e2 = new edge(g, pb, ref p2, ref p3);
            edge e3 = new edge(g, pb, ref p3, ref p1);
            edge e4 = new edge(g, pb, ref p1, ref p4);
            edge e5 = new edge(g, pb, ref p2, ref p4);
            edge e6 = new edge(g, pb, ref p3, ref p4);

            polygon plg1 = new polygon();
            plg1.add(e1);
            plg1.add(e2);
            plg1.add(e3);

            polygon plg2 = new polygon();
            plg2.add(e1);
            plg2.add(e4);
            plg2.add(e5);

            polygon plg3 = new polygon();
            plg3.add(e2);
            plg3.add(e5);
            plg3.add(e6);

            polygon plg4 = new polygon();
            plg4.add(e3);
            plg4.add(e4);
            plg4.add(e6);

            polyhedron res = new polyhedron();
            res.add(plg1);
            res.add(plg2);
            res.add(plg3);
            res.add(plg4);
            return res;
        }

        static polyhedron hexahedron(Graphics g, PictureBox pb, int size)
        {
            point3d p1 = new point3d(-size / 2, -size / 2, -size / 2);
            point3d p2 = new point3d(size / 2, -size / 2, -size / 2);
            point3d p3 = new point3d(size / 2, -size / 2, size / 2);
            point3d p4 = new point3d(-size / 2, -size / 2, size / 2);
            point3d p5 = new point3d(-size / 2, size / 2, -size / 2);
            point3d p6 = new point3d(size / 2, size / 2, -size / 2);
            point3d p7 = new point3d(size / 2, size / 2, size / 2);
            point3d p8 = new point3d(-size / 2, size / 2, size / 2);

            edge e1 = new edge(g, pb, ref p1, ref p2);
            edge e2 = new edge(g, pb, ref p2, ref p3);
            edge e3 = new edge(g, pb, ref p3, ref p4);
            edge e4 = new edge(g, pb, ref p1, ref p4);
            edge e5 = new edge(g, pb, ref p5, ref p6);
            edge e6 = new edge(g, pb, ref p6, ref p7);
            edge e7 = new edge(g, pb, ref p7, ref p8);
            edge e8 = new edge(g, pb, ref p5, ref p8);
            edge e9 = new edge(g, pb, ref p4, ref p8);
            edge e10 = new edge(g, pb, ref p1, ref p5);
            edge e11 = new edge(g, pb, ref p2, ref p6);
            edge e12 = new edge(g, pb, ref p3, ref p7);

            polygon plg1 = new polygon();
            plg1.add(e1);
            plg1.add(e2);
            plg1.add(e3);
            plg1.add(e4);

            polygon plg2 = new polygon();
            plg2.add(e5);
            plg2.add(e6);
            plg2.add(e7);
            plg2.add(e8);

            polygon plg3 = new polygon();
            plg3.add(e4);
            plg3.add(e10);
            plg3.add(e8);
            plg3.add(e9);

            polygon plg4 = new polygon();
            plg4.add(e10);
            plg4.add(e1);
            plg4.add(e11);
            plg4.add(e5);

            polygon plg5 = new polygon();
            plg5.add(e6);
            plg5.add(e11);
            plg5.add(e2);
            plg5.add(e12);

            polygon plg6 = new polygon();
            plg6.add(e7);
            plg6.add(e12);
            plg6.add(e3);
            plg6.add(e9);

            polyhedron res = new polyhedron();
            res.add(plg1);
            res.add(plg2);
            res.add(plg3);
            res.add(plg4);
            res.add(plg5);
            res.add(plg6);
            return res;
        }

        static polyhedron octahedron(Graphics g, PictureBox pb, int size)
        {
            point3d p1 = new point3d(-size / 2, 0, 0);
            point3d p2 = new point3d(0, 0, -size / 2);
            point3d p3 = new point3d(size / 2, 0, 0);
            point3d p4 = new point3d(0, 0, size / 2);
            point3d p5 = new point3d(0, size / 2, 0);
            point3d p6 = new point3d(0, -size / 2, 0);

            edge e1 = new edge(g, pb, ref p1, ref p2);
            edge e2 = new edge(g, pb, ref p2, ref p3);
            edge e3 = new edge(g, pb, ref p3, ref p4);
            edge e4 = new edge(g, pb, ref p1, ref p4);
            edge e5 = new edge(g, pb, ref p1, ref p5);
            edge e6 = new edge(g, pb, ref p2, ref p5);
            edge e7 = new edge(g, pb, ref p3, ref p5);
            edge e8 = new edge(g, pb, ref p4, ref p5);
            edge e9 = new edge(g, pb, ref p1, ref p6);
            edge e10 = new edge(g, pb, ref p2, ref p6);
            edge e11 = new edge(g, pb, ref p3, ref p6);
            edge e12 = new edge(g, pb, ref p4, ref p6);

            polygon plg1 = new polygon();
            plg1.add(e1);
            plg1.add(e6);
            plg1.add(e5);

            polygon plg2 = new polygon();
            plg2.add(e2);
            plg2.add(e7);
            plg2.add(e6);

            polygon plg3 = new polygon();
            plg3.add(e3);
            plg3.add(e7);
            plg3.add(e8);

            polygon plg4 = new polygon();
            plg4.add(e4);
            plg4.add(e8);
            plg4.add(e5);

            polygon plg5 = new polygon();
            plg5.add(e1);
            plg5.add(e9);
            plg5.add(e10);

            polygon plg6 = new polygon();
            plg6.add(e2);
            plg6.add(e10);
            plg6.add(e11);

            polygon plg7 = new polygon();
            plg7.add(e3);
            plg7.add(e11);
            plg7.add(e12);

            polygon plg8 = new polygon();
            plg1.add(e4);
            plg1.add(e9);
            plg1.add(e12);

            polyhedron res = new polyhedron();
            res.add(plg1);
            res.add(plg2);
            res.add(plg3);
            res.add(plg4);
            res.add(plg5);
            res.add(plg6);
            res.add(plg7);
            res.add(plg8);
            return res;
        }

        // в будущем здесь будут икосаэдр и додекаэдр. А может и не будут

        static List<double> mats_mult(List<double> prev_cords, List<List<double>> aff_mat)
        {
            List<double> res = new List<double> { 0, 0, 0 };

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 3; j++)
                    res[j] += aff_mat[i][j] * prev_cords[i];

            return res;
        }

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pen = new Pen(Color.Black);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int ind = comboBox1.SelectedIndex;

            if (ind == 0)
                phdrn = tetrahedron(g, pictureBox1, 150);
            else if (ind == 1)
                phdrn = hexahedron(g, pictureBox1, 250);
            else
                phdrn = octahedron(g, pictureBox1, 300);

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
			button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();

            phdrn.draw();
            pictureBox1.Invalidate();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            int tx, ty, tz;

            if (int.TryParse(textBox1.Text, out tx))
                phdrn.translate(tx, 0, 0);

            if (int.TryParse(textBox2.Text, out ty))
                phdrn.translate(0, ty, 0);

            if (int.TryParse(textBox3.Text, out tz))
                phdrn.translate(0, 0, tz);

            g.Clear(Color.White);
            phdrn.draw();
            pictureBox1.Invalidate();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            int angle;

            if (int.TryParse(textBox4.Text, out angle))
                phdrn.rotateX(angle * Math.PI / 180); // перевод в радианы

            if (int.TryParse(textBox5.Text, out angle))
                phdrn.rotateY(angle * Math.PI / 180);

            if (int.TryParse(textBox6.Text, out angle))
                phdrn.rotateZ(angle * Math.PI / 180);

            g.Clear(Color.White);
            phdrn.draw();
            pictureBox1.Invalidate();
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            double mx, my, mz;

            if (double.TryParse(textBox7.Text, out mx))              
				phdrn.scale(mx, 1, 1);

            if (double.TryParse(textBox8.Text, out my))
                phdrn.scale(1, my, 1);

            if (double.TryParse(textBox9.Text, out mz))
                phdrn.scale(1, 1, mz);

            g.Clear(Color.White);
            phdrn.draw();
            pictureBox1.Invalidate();
        }

		private void button4_MouseClick(object sender, MouseEventArgs e)
		{
			phdrn.reflectX();
			g.Clear(Color.White);
			phdrn.draw();
			pictureBox1.Invalidate();
		}

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            phdrn.reflectY();
            g.Clear(Color.White);
            phdrn.draw();
            pictureBox1.Invalidate();
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            phdrn.reflectZ();
            g.Clear(Color.White);
            phdrn.draw();
            pictureBox1.Invalidate();
        }
    }
}
