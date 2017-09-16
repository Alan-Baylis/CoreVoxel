using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CoreVoxel
{
    public partial class Game : Form
    {
        //define global variables
        public int[] cameraPosition { get; set; } = { 0, 0, 0 };

        public int gridSize { get; } = 30;

        //constructor
        public Game()
        {
            InitializeComponent();

            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            timer.Start();
        }

        //update canvas
        private void timer_Tick(object sender, EventArgs e)
        {
            canvas.Refresh();
            toolCanvas.Refresh();

            cameraPosition[2]++;
        }

        //main canvas render
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int width = canvas.Width;
            int height = canvas.Height;

            //define some variables for camera position
            float cameraAngleX = 0;
            float cameraAngleY = 0;
            float cameraAngleZ = 0;

            //draw grid
            int size = 22;

            int baseX = width / 2 - (gridSize * size) / 2;
            int baseY = height / 2 - (gridSize * size) / 2;
            int baseZ = 0;

            int cameraAngleOffsetX = 0;
            int cameraAngleOffsetY = 0;
            int cameraAngleOffsetZ = 0;

            for (int x = 0; x < gridSize * size; x += size)
            {
                cameraAngleOffsetX++;
                cameraAngleX = (float)(Math.Cos(cameraPosition[0] + cameraAngleOffsetX) * 2);

                cameraAngleOffsetY = 0;
                for (int y = 0; y < gridSize * size; y += size)
                {
                    cameraAngleOffsetY++;
                    cameraAngleY = (float)(Math.Sin(cameraPosition[1] + cameraAngleOffsetY) * 2);

                    g.DrawRectangle(Pens.Black, baseX + x + cameraAngleX, baseY + y + cameraAngleY, size - cameraAngleZ, size - cameraAngleZ);
                }
            }
        }

        //tool canvas render
        private void toolCanvas_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
