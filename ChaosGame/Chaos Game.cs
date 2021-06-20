using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaosGame
{

    /**
     * This program is a visualization of the Chaos game, which is a method of creating a fractal using a polygon and any
     * random point inside of it. This program will draw the sierpinski triangle no matter where the user places the dot.
     **/
    public partial class gameWindow : Form
    {
        Point[] polygon = new Point[3];//Vertices of the triangle
        Point cursor = new Point(-10, -10);//I set each starting point as (-10,-10) so when drawn users do not see it until
        Point start = new Point(-10, -10);//a set position is stated
        Point pointer = new Point(-10, -10);//If I do not set a starting point, it defaults to (0,0) which users can see at 
        Point local = new Point(-10, -10);//the corner of the window
        Random pick = new Random();
        Brush blackBrush = Brushes.Black;
        Brush redBrush = Brushes.Red;
        Boolean hoverMode = true;
        int radius = 3;//Radius of the dots
        int size = 240;//Size of the triangle
        int speed = 1100;
        int iterations = 0;
        int scale = 10;//Speed of the timer (smaller is faster)
        Graphics g;

        public gameWindow()
        {
            InitializeComponent();
        }
        
        private void gameWindow_MouseMove(object sender, MouseEventArgs e)
        {
            local = this.PointToClient(Cursor.Position);//Get position of cursor to draw shape underneath
            if (hoverMode)
                Refresh();
        }

        private void gameWindow_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
        }

        private void gameWindow_Paint(object sender, PaintEventArgs e)
        { 
            if (hoverMode)
            {
                Rectangle rect1 = new Rectangle(local.X - radius, local.Y + radius, radius * 2, radius * 2);
                g.FillEllipse(blackBrush, new Rectangle(cursor.X - radius, cursor.Y + radius, radius * 2, radius * 2));//Circle inside triangle
                g.FillEllipse(blackBrush, rect1);//Circle under cursor
                threePointSetup();
            }
            
        }

        private void gameWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void gameWindow_MouseClick(object sender, MouseEventArgs e)
        {
            if (insideTriangle(e) && hoverMode)
            {
                infoLabel.Text = "2. Click play to see the animation run or next to see step by step.";
                cursor = new Point(e.X, e.Y);
                start = cursor;
                playerButton.Enabled = true;//Once a spot has been set, users can play the animation
                nextButton.Enabled = true;
                Refresh();
            }
            
        }

        private void gameWindow_Shown(object sender, EventArgs e)
        {
            speed = (speedBar.Maximum - speedBar.Value + 1) * scale;//Inversed speedbar so higher trackbar value means smaller intervals
            counterLabel.Text = "Iterations: " + iterations.ToString();
            infoLabel.Text = "1. Pick any spot inside the triangle to start.";
            threePointSetup();
            speedCheck();
        }

        private void gameWindow_MouseLeave(object sender, EventArgs e)
        {
            if (hoverMode)
            {
                local = new Point(-10, -10);//If the cursor leaves the window or is over a button, move the graphic out of view.
                Refresh();
            }
        }

        private void speedBar_Scroll(object sender, EventArgs e)
        {
            speed = (speedBar.Maximum - speedBar.Value + 1) * scale;
            dotTimer.Interval = speed;
            speedCheck();
        }

        private void dotTimer_Tick(object sender, EventArgs e)
        {
            drawDot();//Place a dot for every tick
        }

        private void playerButton_Click(object sender, EventArgs e)
        {
            hoverMode = false;//Once played, graphic under cursor won't show and users can't set another starting point
            dotTimer.Enabled = !dotTimer.Enabled;//Toggle the usability of buttons
            if (iterations < 400)
                infoLabel.Text = "3. We will set a point halfway between the starting point and a random point of the triangle (highlighted in red).";
            nextButton.Enabled = !nextButton.Enabled;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            drawDot();//Draw only one dot at a time
            if(iterations < 400)
                infoLabel.Text = "3. We will set a point halfway between the starting point and a random point of the triangle (highlighted in red).";
            hoverMode = false;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            g.Clear(Form.ActiveForm.BackColor);//Erase every graphic drawn
            cursor = new Point(-10, -10);//Hide starting point
            hoverMode = true;
            playerButton.Enabled = false;
            nextButton.Enabled = false;
            dotTimer.Enabled = false;
            iterations = 0;
            counterLabel.Text = "Iterations: " + iterations;
            infoLabel.Text = "1. Pick any spot inside the triangle to start.";
            threePointSetup();//Draw the 3 vertices of the triangle
        }

        /**
         * This function draws the 3 vertices of the triangle for users to visualize where to put the starting point
         **/
        private void threePointSetup()
        {
            Point center = new Point(554, 275);//Arbitrary center point of triangle
            Rectangle[] rectangles = new Rectangle[4];
            //Points of the polygon
            polygon[0] = new Point(center.X, center.Y - size);
            polygon[1] = new Point(center.X - (int)(size * Math.Cos(Math.PI / 6)), center.Y + (int)(size * Math.Sin(Math.PI / 6)));
            polygon[2] = new Point(center.X + (int)(size * Math.Cos(Math.PI / 6)), center.Y + (int)(size * Math.Sin(Math.PI / 6)));
            //rectangles[0] = new Rectangle(center.X - radius, center.Y + radius, radius * 2, radius * 2); this is center point, used for debugging

            //Size of the polygon
            rectangles[1] = new Rectangle(polygon[0].X - radius, polygon[0].Y + radius, radius * 2, radius * 2);
            rectangles[2] = new Rectangle(polygon[1].X - radius, polygon[1].Y + radius, radius * 2, radius * 2);
            rectangles[3] = new Rectangle(polygon[2].X - radius, polygon[2].Y + radius, radius * 2, radius * 2);

            //g.FillEllipse(blackBrush, rect1);
            foreach (Rectangle rect in rectangles)
                g.FillEllipse(blackBrush, rect);//Draw each point of the polygon

            //This section was used for debugging, it draws a line between each point to help visualize where exactly an intersection would be
            //Point prev = polygon[polygon.Length - 1];
            //foreach (Point point in polygon)
            //{
            //    g.DrawLine(new Pen(blackBrush), point, prev);
            //    prev = point;
            //}
        }

        /**
         * This function determines a point is inside the triangle using the raycast method 
         **/
        private Boolean insideTriangle(MouseEventArgs e)
        {
            int intersections = 0;//If there are even intersections, a point is inside the shape and vice versa
            Point prev = polygon[polygon.Length - 1];
            foreach (Point point in polygon)
            {
                //Since we are using a straight horizontal line as a ray, we just need to make sure our point is within the y-range of a line segment
                if ((point.Y < e.Y && prev.Y > e.Y) || (point.Y > e.Y && prev.Y < e.Y)) {
                    int side1 = ((-point.X)*(prev.Y - point.Y)) - ((e.Y-point.Y)*(prev.X - point.X));//We use the dot product to determine if the line intersects
                    int side2 = ((e.X - point.X) * (prev.Y - point.Y)) - ((e.Y - point.Y) * (prev.X - point.X));
                    if(Math.Sign(side1) != Math.Sign(side2))//If the line intersects, then signs of both dot products are opposites
                        intersections++;
                }

                prev = point;

            }
            return intersections % 2 == 1;//If intersections is odd, return true
        }

        /**
         * The function is used to update the label on how fast the animation will play
         **/
        private void speedCheck()
        {
            if (speedBar.Value >= 9 && speedBar.Value <= 10)
                speedLabel.Text = "Speed: Fast";
            if (speedBar.Value >= 6 && speedBar.Value <= 8)
                speedLabel.Text = "Speed: Quick";
            if (speedBar.Value >= 3 && speedBar.Value <= 5)
                speedLabel.Text = "Speed: Moderate";
            if (speedBar.Value >= 0 && speedBar.Value <= 2)
                speedLabel.Text = "Speed: Slow";
        }

        /**
         * This function is used for the animation played to draw the sierpinski triangle
         **/
        private void drawDot()
        {
            iterations++;
            counterLabel.Text = "Iterations: " + iterations;
            g.FillEllipse(blackBrush, new Rectangle(pointer.X - radius, pointer.Y + radius, radius * 2, radius * 2));
            pointer = polygon[pick.Next(3)];//Pick a random point of the triangle
            g.FillEllipse(redBrush, new Rectangle(pointer.X - radius, pointer.Y + radius, radius * 2, radius * 2));//Highlights which point is being used
            Point dest = new Point((pointer.X + start.X) / 2, (pointer.Y + start.Y) / 2);//Gets the point thats halfway between the vertice and the starting
            Rectangle rect = new Rectangle(dest.X - radius, dest.Y + radius, radius * 2, radius * 2);
            Graphics dot = this.CreateGraphics();//Create a new graphic so it can be easily drawn
            dot.FillEllipse(blackBrush, rect);
            start = dest;//Drawn point is the new starting point

            if (iterations == 400)
                infoLabel.Text = "4. After a few hundred iterations, you can see a fractal start appearing.";
        }
    }

}
