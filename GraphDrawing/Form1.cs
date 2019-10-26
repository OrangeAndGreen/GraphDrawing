using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphDrawing
{
    /*
     * TODO:
     * -Control to highlight a window, then either delete or smooth within window
     * -Save image
     * 
     * Presentation TODOs:
     * -Title, axes, axis titles/labels
     * -Annotations
     * -
     */
    public enum ColorScheme
    {
        Light = 1,
        Dark = 2
    }

    public partial class Form1 : Form
    {
        private const int DataSize = 1000;
        private double[] mData = new double[DataSize];

        private ColorScheme mScheme = ColorScheme.Light;
        private Bitmap mImage = null;
        private Bitmap mSelectionImage = null;

        private bool mTracking = false;
        private Point mLastPosition = new Point();

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < DataSize; i++)
            {
                mData[i] = -1;
            }

            DrawFromScratch();
        }

        private Pen GetPen(Color color)
        {
            Pen pen = new Pen(color);

            pen.Width = 1;

            return pen;
        }

        private void DrawFromScratch()
        {
            mSelectionImage = new Bitmap(selectionImage.Width, selectionImage.Height);
            Graphics g = Graphics.FromImage(mSelectionImage);
            Brush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, 0, 0, selectionImage.Width, selectionImage.Height);
            g.DrawRectangle(new Pen(Color.Black), 0, 0, selectionImage.Width-1, selectionImage.Height-1);
            selectionImage.Image = mSelectionImage;

            mImage = new Bitmap(graphImage.Width, graphImage.Height);
            //Console.WriteLine("{0}, {1}", graphImage.Width, graphImage.Height);

            g = Graphics.FromImage(mImage);
            brush = new SolidBrush(mScheme == ColorScheme.Light ? Color.White : Color.Black);
            g.FillRectangle(brush, 0, 0, graphImage.Width, graphImage.Height);

            DrawAxes();

            for (int x = 0; x < DataSize - 1; x++)
            {
                updateGraph(x, mData[x], x + 1, mData[x + 1]);
            }

            graphImage.Image = mImage;
        }

        private void DrawAxes()
        {
            Graphics g = Graphics.FromImage(mImage);

            Pen pen = new Pen(Color.Gray);
            int numAxes = (int)gridLinesInput.Value;
            for (int offset = 1; offset < numAxes+1; offset++)
            {
                int pixel = (int)Math.Round((double)offset / (numAxes+1) * graphImage.Height);
                g.DrawLine(pen, 0, pixel, graphImage.Width, pixel);
                pixel = (int)Math.Round((double)offset / (numAxes+1) * graphImage.Width);
                g.DrawLine(pen, pixel, 0, pixel, graphImage.Height);
            }
        }

        private void graphImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (mTracking)
            {
                Point position = getMousePosition();

                if (position.X >= 0 && position.X < graphImage.Width &&
                    position.Y >= 0 && position.Y < graphImage.Height)
                {
                    int lastX = (int)Math.Round((double)mLastPosition.X * DataSize / graphImage.Width);
                    double lastY = (double)(graphImage.Height - mLastPosition.Y) * DataSize / graphImage.Height;

                    int x = (int)Math.Round((double)position.X * DataSize / graphImage.Width);
                    double y = (double)(graphImage.Height - position.Y) / graphImage.Height * DataSize;

                    updateGraph(lastX, lastY, x, y);

                    //Console.WriteLine("{0}, {1}", x, y);

                    mLastPosition = position;
                }
            }
        }

        private void ChangePoint(int x, double newY)
        {
            int imageX = (int)Math.Round((double)x / DataSize * graphImage.Width);
            Pen bgPen = GetPen(mScheme == ColorScheme.Light ? Color.White : Color.Black);
            Pen linePen = GetPen(mScheme == ColorScheme.Light ? Color.Black : Color.White);
            Graphics g = Graphics.FromImage(mImage);

            int imageYOld = graphImage.Height - (int)Math.Round(mData[x] / DataSize * graphImage.Height);
            if (x > 0 && mData[x - 1] >= 0)
            {
                int prevImageX = (int)Math.Round((double)(x - 1) / DataSize * graphImage.Width);
                int prevImageY = graphImage.Height - (int)Math.Round(mData[x - 1] / DataSize * graphImage.Height);
                g.DrawLine(bgPen, prevImageX, prevImageY, imageX, imageYOld);
            }
            if (x < DataSize - 1 && mData[x + 1] >= 0)
            {
                int nextImageX = (int)Math.Round((double)(x + 1) / DataSize * graphImage.Width);
                int nextImageY = graphImage.Height - (int)Math.Round(mData[x + 1] / DataSize * graphImage.Height);
                g.DrawLine(bgPen, nextImageX, nextImageY, imageX, imageYOld);
            }

            if (newY >= 0)
            {
                int imageYNew = graphImage.Height - (int)Math.Round(newY / DataSize * graphImage.Height);
                if (x > 0 && mData[x - 1] >= 0)
                {
                    int prevImageX = (int)Math.Round((double)(x - 1) / DataSize * graphImage.Width);
                    int prevImageY = graphImage.Height - (int)Math.Round(mData[x - 1] / DataSize * graphImage.Height);
                    g.DrawLine(linePen, prevImageX, prevImageY, imageX, imageYNew);
                }
                if (x < DataSize - 1 && mData[x + 1] >= 0)
                {
                    int nextImageX = (int)Math.Round((double)(x + 1) / DataSize * graphImage.Width);
                    int nextImageY = graphImage.Height - (int)Math.Round(mData[x + 1] / DataSize * graphImage.Height);
                    g.DrawLine(linePen, nextImageX, nextImageY, imageX, imageYNew);
                }
            }

            mData[x] = newY;
        }

        private void updateGraph(int lastX, double lastY, int x, double y)
        {
            int minX = Math.Min(lastX, x);
            double minY = minX == lastX ? lastY : y;
            int maxX = Math.Max(lastX, x);
            double maxY = maxX == lastX ? lastY : y;

            for (int curX = minX; curX <= maxX; curX++)
            {
                double yInterp = y;
                if (minX != maxX)
                {
                    yInterp = ((double)curX - minX) / (maxX - minX) * (maxY - minY) + minY;
                }

                ChangePoint(curX, yInterp);
            }

            //DrawFromScratch();
            DrawAxes();
            graphImage.Image = mImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int window = (int)windowInput.Value;
            double[] newData = new double[DataSize];
            for (int x = 0; x < DataSize; x++)
            {
                if (mData[x] < 0)
                {
                    newData[x] = mData[x];
                }
                else
                {
                    double total = 0;
                    int count = 0;
                    for (int subX = x - window / 2; subX <= x + window / 2; subX++)
                    {
                        if (subX >= 0 && subX < DataSize && mData[subX] >= 0)
                        {
                            total += mData[subX];
                            count++;
                        }
                    }

                    newData[x] = total / count;
                }
            }

            mData = newData;

            int empty = 0;
            int firstNonEmpty = -1;
            for (int x = 0; x < DataSize; x++)
            {
                if (mData[x] < 0)
                {
                    empty++;
                }
                else if (firstNonEmpty < 0)
                {
                    firstNonEmpty = x;
                }
            }
            Console.WriteLine("{0} empty ({1} first non-empty)", empty, firstNonEmpty);

            DrawFromScratch();
        }

        private void fillButton_Click(object sender, EventArgs e)
        {
            //Find the first valid sample
            int firstFilledIndex = -1;
            for (int i = 0; i < DataSize; i++)
            {
                if (mData[i] >= 0)
                {
                    firstFilledIndex = i;
                    break;
                }
            }

            //Only proceed if at least one sample is filled
            if (firstFilledIndex >= 0)
            {
                //Fill from beginning to firstFilledSample
                for (int i = 0; i < firstFilledIndex; i++)
                {
                    mData[i] = mData[firstFilledIndex];
                }

                //Interpolate gaps
                int lastFullSample = firstFilledIndex;
                for (int i = firstFilledIndex+1; i < DataSize; i++)
                {
                    if (mData[i] >= 0)
                    {
                        if (lastFullSample != i - 1)
                        {
                            //Fill a gap
                            for (int j = lastFullSample + 1; j < i; j++)
                            {
                                mData[j] = mData[lastFullSample] + ((double)j - lastFullSample) / (i - lastFullSample) * (mData[i] - mData[lastFullSample]);
                            }
                        }

                        lastFullSample = i;
                    }
                }

                //Fill to end
                for (int i = lastFullSample + 1; i < DataSize; i++)
                {
                    mData[i] = mData[lastFullSample];
                }

                DrawFromScratch();
            }
        }

        private Point getMousePosition()
        {
            Point position = graphImage.PointToClient(System.Windows.Forms.Cursor.Position);

            return position;
        }

        private void graphImage_MouseDown(object sender, MouseEventArgs e)
        {
            mTracking = true;
            mLastPosition = getMousePosition();
        }

        private void graphImage_MouseUp(object sender, MouseEventArgs e)
        {
            mTracking = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            DrawFromScratch();
        }

        private void colorSchemePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            mScheme = colorSchemePicker.Text.Equals("Light") ? ColorScheme.Light : ColorScheme.Dark;
            DrawFromScratch();
        }

        private void gridLinesInput_ValueChanged(object sender, EventArgs e)
        {
            DrawFromScratch();
        }
    }
}
