using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using RingtoneWizard;
using System.Collections.Generic;
using System;

public class CustomTrackbar : Panel
{
    private float trackPosition = -5f;
    private RectangleF backR;
    private RectangleF fillR;
    private RectangleF outlineR;
    private NewMessage newMessage = new NewMessage();
    private OptionsPane pane = new OptionsPane();
    
    public bool waitingForNext { get; set; }
    public bool firstPoint { get; set; }
    private bool secondValidated { get; set; }
    private bool firstValid { get; set; }

    //Array containing the points
    private List<float[]> sets = new List<float[]>();

    //the points
    private float[] points = new float[2] { -5, -5 };
    private float[] points2 = new float[2] { -5, -5 };

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        SolidBrush myBrush;
        Graphics g = this.CreateGraphics();

        //outline
        outlineR = new RectangleF(0, 0, this.Width, this.Height);
        myBrush = new SolidBrush(Color.Black);
        g.FillRectangle(myBrush, outlineR);

        //trackbar background
        backR = new RectangleF(1f, 1f, this.Width - 2f, this.Height - 2f);
        myBrush = new SolidBrush(Color.White);
        g.FillRectangle(myBrush, backR);

        //render points
        myBrush = new SolidBrush(Color.Red);

        foreach (float[] point in sets)
        {
            RectangleF point1 = new RectangleF(point[0], 1f, 2f, this.Height - 2f);
            g.FillRectangle(myBrush, point1);
            RectangleF point2 = new RectangleF(point[1], 1f, 2f, this.Height - 2f);
            g.FillRectangle(myBrush, point2);
            RectangleF filler = new RectangleF(point[0], 1f, point[1] - point[0], this.Height - 2f);
            g.FillRectangle(myBrush, filler);
        }

        //render dragging point
        RectangleF dragPoint = new RectangleF(points[0], 1f, 2f, this.Height - 2f);
        g.FillRectangle(myBrush, dragPoint);

        //position
        fillR = new RectangleF(trackPosition, 1f, 2f, this.Height - 2f);
        myBrush = new SolidBrush(Color.Blue);
        g.FillRectangle(myBrush, fillR);

        //destroy graphics
        //Console.WriteLine("Custom trackbar percentage: " + (trackPosition / this.Width));
        myBrush.Dispose();
        g.Dispose();
    }

    public void setPosition(float pos)
    {
        this.trackPosition = pos * backR.Width;
        this.Refresh();
    }

    public void rightClick(float percentage)
    {
        float p = percentage * backR.Width;
        if(waitingForNext)
        {
            finishSet(p);
        }
        else
        {
            newSet(p);
        }
    }

    private void newSet(float p)
    {
        points = new float[2] {-5, -5};

        firstValid = true;
        //make sure a new point is not started in the middle of another
        foreach(float[] point in sets)
        {
            if(p > point[0] && p < point[1])
            {
                showOptions(point);
                firstValid = false;
                break;
            }
        }
        if(firstValid)
        {
            points[0] = p;
            firstPoint = true;
            this.Refresh();
        }
    }

    private void showOptions(float[] point)
    {
        pane.Hide();
        pane.Show(point, this);
        Point loc = this.PointToScreen(Point.Empty);
        pane.Location = new Point(loc.X + (int)point[0] + (int)((point[1] - point[0]) / 2) - pane.Width / 2, loc.Y - pane.Height - 3);
    }

    private void deletePoint(float[] point)
    {
        sets.Remove(point);
        this.Refresh();
    }

    public void finish()
    {
        if (!waitingForNext && firstPoint)
        {
            if (firstValid)
            {
                sets.Add(points);
                waitingForNext = true;
                firstPoint = false;
            }
        }
        else
        {
            if(secondValidated)
            {
                waitingForNext = false;
                firstPoint = true;
            }
        }
    }

    public new void KeyDown()
    {
        if (waitingForNext)
        {
            waitingForNext = false;
            firstPoint = true;
            sets.Remove(points);
            points = new float[2] { -5, -5 };
            this.Refresh();
        }
    }

    public void orderPoints()
    {
        sets = sets
            .OrderBy(arr => arr[0]).ToList();
    }

    private void finishSet(float p)
    {
        //last item being worked on
        points2 = ((float[])sets[sets.Count - 1]);

        bool afterFirst = false;
        bool validSecond = true;
        secondValidated = false;

        //check to make sure second point is after first point
        if (p > points2[0])
            afterFirst = true;
        else
            newMessage.Show("The second point must be placed after the first point");

        //check to make sure point doesn't cross into another point
        if (afterFirst)
        {
            foreach (float[] point in sets)
            {
                if (points2[0] < point[0])
                {
                    if (p < point[0])
                    {
                        validSecond = true;
                    }
                    else
                    {
                        newMessage.Show("The second point must be placed before another set of points.");
                        validSecond = false;
                        break;
                    }
                }
            }
        }

        //if after first and a valid position, add to array
        if(afterFirst && validSecond)
        {
            secondValidated = true;
            points2[1] = p;
            points = points2;
            this.Refresh();
        }
    }

    public List<float[]> getSets()
    {
        return this.sets;
    }

    public void setSets(List<float[]> list)
    {
        this.sets = list;
        this.Refresh();
    }
}