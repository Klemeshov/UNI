using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Graphs
{
    public partial class Main : Form
    {
        // Types
        private enum BrushType
        {
            Background = 0,
            Object = 1,
        };

        // Cursor
        private readonly Queue<Point> cursorQueue; 
        private int cursorSize = 10;
        private bool isDrawing;

        // Seeds drawing
        private BrushType activeBrushType;
        private Rectangle renderedImageBounds;
        private byte[,] backgroundSeedSelectionRegion;
        private byte[,] objectSeedSelectionRegion;

        // Drawing surface to image bitmap transformation
        private double zoom;

        // Properties
        private int lambda = Segmentation.LABMDA;
        private double sigma = Segmentation.SIGMA;

        public Main()
        {
            InitializeComponent();

            cursorQueue = new Queue<Point>();
            activeBrushType = BrushType.Background;

            inpt_backgroundBrushSize.Value = cursorSize;
            inpt_objectBrushSize.Value = cursorSize;

            inpt_lambda.Text = "" + lambda;
            inpt_sigma.Text = "" + sigma;
        }

        /** ### INITALIZATION ### **/

        /**
         * When image is loaded into PictureBox, initialize:
         * - bacgroundSeedSelectionRegion, objectSeedSelectionRegion - surface for drawing selection. It's important to initilize with the size equals to PictureBox size
         * - zoom - property for finding pixels positions in original bitmap
         * - renderedImageBounds - region for determining drawing surface bounds
         * **/
        private void pctrbx_selectedImage_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            backgroundSeedSelectionRegion = new byte[pctrbx_selectedImage.ClientSize.Width, pctrbx_selectedImage.ClientSize.Height];
            objectSeedSelectionRegion = new byte[pctrbx_selectedImage.ClientSize.Width, pctrbx_selectedImage.ClientSize.Height];
            zoom = (double)pctrbx_selectedImage.Image.Size.Width / pctrbx_selectedImage.ClientSize.Width;

            var ratio = (double)pctrbx_selectedImage.Image.Size.Width / pctrbx_selectedImage.Image.Size.Height;

            if (ratio >= 1)
            {
                int newHeight = (int)(pctrbx_selectedImage.ClientSize.Width / ratio);

                renderedImageBounds = new Rectangle(0, (pctrbx_selectedImage.ClientSize.Height - newHeight) / 2, pctrbx_selectedImage.ClientSize.Width, newHeight);
            }
            else
            {
                int newWitdh = (int)(pctrbx_selectedImage.ClientSize.Height * ratio);

                renderedImageBounds = new Rectangle((pctrbx_selectedImage.ClientSize.Width - newWitdh) / 2, 0, newWitdh, pctrbx_selectedImage.ClientSize.Height);
            }
        }

        // Enable "Compare" button, when ideal image is loaded
        private void pctrbx_idealImage_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (pctrbx_segmentationImage.Image != null)
            {
                btn_compare.Enabled = true;
            }
        }

        /** ### CORE FUNCTIONALITY ###  **/

        /**
         * Select image from file system for segmentation
         * **/
        private void btn_selectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pctrbx_selectedImage.ImageLocation = openFileDialog.FileName;
                }
            }
        }

        /** 
         * Save segmentation result
         * **/
        private void btn_saveSegmentation_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var bitmap = new Bitmap(pctrbx_segmentationImage.Image);
                    
                    bitmap.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                }
            }
        }

        /** 
         * Find and print background
         * **/
        private void btn_segmentize_Click(object sender, EventArgs e)
        {            
            var segmentation = new Segmentation(
                new Bitmap(pctrbx_selectedImage.Image),
                GetSeeds(backgroundSeedSelectionRegion),
                GetSeeds(objectSeedSelectionRegion),
                lambda,
                sigma
            );
            var bitmap = segmentation.Cut();

            pctrbx_segmentationImage.Image = bitmap;
        }

        /** 
         * Get flat points array from seed selection region
         * **/
        private Point[] GetSeeds(byte[,] seedSelectionRegion)
        {
            HashSet<string> usedPixels = new HashSet<string>();
            List<Point> seeds = new List<Point>();
            
            for (var i = 0; i < seedSelectionRegion.GetLength(0); i++)
            {
                for (var j = 0; j < seedSelectionRegion.GetLength(1); j++)
                {
                    if (seedSelectionRegion[i, j] != 0)
                    {
                        // Values in initial image bitmap for evaluation pixel intensities
                        var relativeX = (int)((i - renderedImageBounds.X) * zoom);
                        var relativeY = (int)((j - renderedImageBounds.Y) * zoom);
                        var key = relativeX + " " + relativeY;

                        // After zooming, we might to have duplicates in seeds that will break intensity histogram, so we need to exclude them from final seeds 
                        if (!usedPixels.Contains(key))
                        {
                            seeds.Add(new Point(relativeX, relativeY));

                            usedPixels.Add(key);
                        }
                    }
                }
            }

            return seeds.ToArray();
        }

        /** 
         * Clear seed selection region
         * **/
        private void ClearSeedSelectionRegion(byte[,] seedSelectionRegion)
        {
            for (var i = 0; i < seedSelectionRegion.GetLength(0); i++)
            {
                for (var j = 0; j < seedSelectionRegion.GetLength(1); j++)
                {
                    seedSelectionRegion[i, j] = 0;
                }
            }
        }

        /** Quality Assertion **/

        /** 
         * Selec image for comparison
         * **/
        private void btn_selectIdeal_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\users\\eliza\\Desktop";
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pctrbx_idealImage.ImageLocation = openFileDialog.FileName;
                }
            }
        }

        /** 
         * Compare segmentation with ideal
         * **/
        private void btn_compare_Click(object sender, EventArgs e)
        {
            var assertion = new QualityAssertion(new Bitmap(pctrbx_segmentationImage.Image), new Bitmap(pctrbx_idealImage.Image));
            var metrics = assertion.GetQualityMetrics();

            lbl_correctObjToTotal.Text = metrics.CorrectObjectPixelsToTotalPixels + "%";
            lbl_correctBgToTotal.Text = metrics.CorrectBackgroundPixelsToTotalPixels + "%";
            lbl_correctToTotal.Text = metrics.AllCorrectPixelsToTotalPixels + "%";
            lbl_jaccard.Text = metrics.JaccardMetric + "%";
        }

        /** READ SEGMENTATION PROPPERTIES FROM USER **/

        private void inpt_lambda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lambda = Int32.Parse(inpt_lambda.Text);
            } catch (Exception)
            { }
        }

        private void inpt_sigma_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sigma = Double.Parse(inpt_sigma.Text);
            } catch (Exception)
            { }
        }

        /** ### DRAWAING SEED SELECTION REGIONS AND BRUSH SETTINGS **/

        /** 
         * Get brush color for background seed or object seed
         * **/
        private Color GetBrushColor(BrushType type)
        {
            switch (type)
            {
                case BrushType.Background:
                    return Color.LightBlue;

                case BrushType.Object:
                default:
                    return Color.LightPink;
            }
        }

        /** 
         * Draw seed selection region
         * **/
        private void DrawSeedSelectionRegion(Graphics g, byte[,] region, BrushType type)
        {
            using (var brush = new SolidBrush(GetBrushColor(type)))
            {
                if (region != null)
                {
                    for (var i = 0; i < region.GetLength(0); i++)
                    {
                        for (var j = 0; j < region.GetLength(1); j++)
                        {
                            if (region[i, j] != 0)
                            {
                                g.FillRectangle(brush, i, j, 1, 1);
                            }
                        }
                    }
                }
            }
        }

        /** 
         * Draw brush
         * **/
        private void DrawBrush(int x, int y)
        {
            if (IsCursorInBounds(x, y))
            {
                for (var i = x; i < x + cursorSize; i++)
                {
                    for (var j = y; j < y + cursorSize; j++)
                    {
                        switch (activeBrushType)
                        {
                            case BrushType.Background:
                                backgroundSeedSelectionRegion[i, j] = 1;
                                objectSeedSelectionRegion[i, j] = 0; // Remove pixel from oposite seed region
                                break;

                            case BrushType.Object:
                                objectSeedSelectionRegion[i, j] = 1;
                                backgroundSeedSelectionRegion[i, j] = 0; // Remove pixel from oposite seed region
                                break;
                        }
                    }
                }
            }
        }

        /** 
         * Check if cursor is inside image bounds
         * **/
        private bool IsCursorInBounds(int x, int y)
        {
            bool isXInBounds = x >= renderedImageBounds.X && x <= renderedImageBounds.X + renderedImageBounds.Width - cursorSize;
            bool isYInBounds = y >= renderedImageBounds.Y && y <= renderedImageBounds.Y + renderedImageBounds.Height - cursorSize;

            return isXInBounds && isYInBounds;
        }
        
        /** 
         * Drawing shapes onto PictureBox of selected image
         * **/
        private void pctrbx_selectedImage_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw cursor and image bounds
            using (var pen = new Pen(GetBrushColor(activeBrushType), 1))
            {
                if (cursorQueue.Count != 0)
                {
                    var point = cursorQueue.Dequeue();

                    g.DrawRectangle(pen, point.X, point.Y, cursorSize, cursorSize);
                }
            }

            using (var pen = new Pen(GetBrushColor(activeBrushType), 3))
            {
                g.DrawRectangle(pen, renderedImageBounds);
            }

            // Draw seeds selection regions
            DrawSeedSelectionRegion(g, backgroundSeedSelectionRegion, BrushType.Background);
            DrawSeedSelectionRegion(g, objectSeedSelectionRegion, BrushType.Object);
        }

        /**
         * Handle mouse moves on PictureBox canvas
         * **/
        private void pctrbx_selectedImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsCursorInBounds(e.X, e.Y))
            {
                cursorQueue.Enqueue(new Point(e.X, e.Y));

                if (isDrawing)
                {
                    DrawBrush(e.X, e.Y);
                }

                pctrbx_selectedImage.Refresh();
            }
        }

        /**
         * Handle mouse click start on PictureBox canvas
         * **/
        private void pctrbx_selectedImage_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;

            DrawBrush(e.X, e.Y);
        }

        /**
         * Handle mouse click end on PictureBox canvas
         * **/
        private void pctrbx_selectedImage_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        /** 
         * Select background brush
         * **/
        private void btn_selectBackgroundBrush_Click(object sender, EventArgs e)
        {
            activeBrushType = BrushType.Background;

            pctrbx_selectedImage.Refresh();
        }

        /** 
         * Select object brush
         * **/
        private void btn_selectObjectBrush_Click(object sender, EventArgs e)
        {
            activeBrushType = BrushType.Object;

            pctrbx_selectedImage.Refresh();
        }

        /** 
         * Change background brush size
         * **/
        private void inpt_backgroundBrushSize_ValueChanged(object sender, EventArgs e)
        {
            cursorSize = (int)inpt_backgroundBrushSize.Value;
        }

        /** 
         * Change background brush size
         * **/
        private void inpt_objectBrushSize_ValueChanged(object sender, EventArgs e)
        {
            cursorSize = (int)inpt_objectBrushSize.Value;
        }

        /** 
         * Clear background seed selection
         * **/
        private void btn_clearBackgroundSeed_Click(object sender, EventArgs e)
        {
            ClearSeedSelectionRegion(backgroundSeedSelectionRegion);
        }

        /**
         * Clear object seed selection
         * **/
        private void btn_clearObjectSeed_Click(object sender, EventArgs e)
        {
            ClearSeedSelectionRegion(objectSeedSelectionRegion);
        }
    }
}
