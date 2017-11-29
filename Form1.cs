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
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }

            public point3d(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }

        class edge
        {
            Graphics g;
            PictureBox pb;
            private point3d p1, p2;

            public edge(Graphics g, PictureBox pb, point3d p1, point3d p2)
            {
                this.p1 = new point3d(p1.X, p1.Y, p1.Z);
                this.p2 = new point3d(p2.X, p2.Y, p2.Z);
                this.g = g;
                this.pb = pb;
            }

            public void draw()
            {
                int centerX = pb.Width / 2;
                int centerY = pb.Height/ 2;
                g.DrawLine(new Pen(Color.Black), p1.X + centerX, p1.Y + centerY, p2.X + centerX, p2.Y + centerY);
            }

            public void sub_trans(int tx, int ty, int tz)
            {
                List<List<double>> trans_mat = new List<List<double>>(4);
                for (int i = 0; i < 4; i++)
                    trans_mat[i] = new List<double>(4);

                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        trans_mat[i][j] = i == j ? 1 : 0;

                trans_mat[0][3] = tx;
                trans_mat[1][3] = ty;
                trans_mat[2][3] = tz;

                List<double> p1_new_cords = mats_mult(new List<double> { p1.X, p1.Y, p1.Z, 1 }, trans_mat);
                List<double> p2_new_cords = mats_mult(new List<double> { p2.X, p2.Y, p2.Z, 1 }, trans_mat); // test trans_mat

                p1.X = (int)p1_new_cords[0];
                p1.Y = (int)p1_new_cords[1];
                p1.Z = (int)p1_new_cords[2];
                p2.X = (int)p2_new_cords[0];
                p2.Y = (int)p2_new_cords[1];
                p2.Z = (int)p2_new_cords[2];
            }
        }

        class polygon
        {
            private List<edge> le;

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

            public List<edge> get_edges()
            {
                return le;
            }
        }

        class polyhedron
        {
            private List<polygon> lp;

            public polyhedron()
            {
                lp = new List<polygon>();
            }

            public void add(polygon p)
            {
                lp.Add(p);
            }

            public void draw()
            {
                foreach (polygon p in lp)
                    p.draw();
            }

            public void translate(int tx, int ty, int tz)
            {
                foreach(polygon p in lp)
                {
                    List<edge> edges_to_translate = p.get_edges();
                    foreach (edge e in edges_to_translate)
                        e.sub_trans(tx, ty, tz);
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
            
            edge e1 = new edge(g, pb, p1, p2);
            edge e2 = new edge(g, pb, p2, p3);
            edge e3 = new edge(g, pb, p3, p1);
            edge e4 = new edge(g, pb, p1, p4);
            edge e5 = new edge(g, pb, p2, p4);
            edge e6 = new edge(g, pb, p3, p4);

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

            edge e1 = new edge(g, pb, p1, p2);
            edge e2 = new edge(g, pb, p2, p3);
            edge e3 = new edge(g, pb, p3, p4);
            edge e4 = new edge(g, pb, p1, p4);
            edge e5 = new edge(g, pb, p5, p6);
            edge e6 = new edge(g, pb, p6, p7);
            edge e7 = new edge(g, pb, p7, p8);
            edge e8 = new edge(g, pb, p5, p8);
            edge e9 = new edge(g, pb, p4, p8);
            edge e10 = new edge(g, pb, p1, p5);
            edge e11 = new edge(g, pb, p2, p6);
            edge e12 = new edge(g, pb, p3, p7);

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

            edge e1 = new edge(g, pb, p1, p2);
            edge e2 = new edge(g, pb, p2, p3);
            edge e3 = new edge(g, pb, p3, p4);
            edge e4 = new edge(g, pb, p1, p4);
            edge e5 = new edge(g, pb, p1, p5);
            edge e6 = new edge(g, pb, p2, p5);
            edge e7 = new edge(g, pb, p3, p5);
            edge e8 = new edge(g, pb, p4, p5);
            edge e9 = new edge(g, pb, p1, p6);
            edge e10 = new edge(g, pb, p2, p6);
            edge e11 = new edge(g, pb, p3, p6);
            edge e12 = new edge(g, pb, p4, p6);

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

        // в будущем здесь будут икосаэдр и додекаэдр

        static List<double> mats_mult(List<double> prev_cords, List<List<double>> aff_mat) // hueta?
        {
            List<double> res = new List<double>(3);
            res[0] = 0;
            res[1] = 0;
            res[2] = 0;

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

            phdrn.draw();
            pictureBox1.Invalidate();
        }
    }
}
