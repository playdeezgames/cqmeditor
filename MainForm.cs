using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace CQMEditor
{
    public partial class MainForm : Form
    {
        private const string DefaultTilesetFilename = "defaulttiles.xml";
        private Tileset currentTileset = new Tileset();
        private byte currentTile = 0;
        private CQMFile currentMap = new CQMFile(15, 15);
        private byte cursorX = 0;
        private byte cursorY = 0;
        private bool mouseDown = false;

        private bool recreateDirtyMapCells = true;
        private bool[,] dirtyMapCells = null;

        private bool reloadTileBitmaps = true;
        private Bitmap[] tileBitmaps = null;

        private bool reloadCursorBitmap = true;
        private Bitmap cursorBitmap = null;

        private void updateTilesetListView()
        {
            lvTileset.Items.Clear();
            for (int index = byte.MinValue; index <= byte.MaxValue; ++index)
            {
                Tile tile = currentTileset[(byte)index];
                string[] entry = new string[] { index.ToString(),tile.Name };
                lvTileset.Items.Add(new ListViewItem(entry));
            }
            lvTileset.Items[currentTile].Selected = true;
        }
        private void updateTileBitmaps()
        {
            if (reloadTileBitmaps)
            {
                reloadTileBitmaps = false;
                tileBitmaps = new Bitmap[byte.MaxValue - byte.MinValue + 1];
                for (int index = 0; index < byte.MaxValue - byte.MinValue + 1; ++index)
                {
                    Tile tile = currentTileset[(byte)index];
                    tileBitmaps[index] = (Bitmap)Image.FromFile(tile.Filename);
                }
            }
        }
        private void updateCursorBitmap()
        {
            if (reloadCursorBitmap)
            {
                reloadCursorBitmap = false;
                cursorBitmap = (Bitmap)Image.FromFile(currentTileset.Cursor.Filename);
            }
        }
        private void updateDirtyMapCells()
        {
            if (recreateDirtyMapCells)
            {
                recreateDirtyMapCells = false;
                dirtyMapCells = new bool[currentMap.Width, currentMap.Height];
                for (int x = 0; x < currentMap.Width; ++x)
                {
                    for (int y = 0; y < currentMap.Height; ++y)
                    {
                        dirtyMapCells[x, y] = true;
                    }
                }
            }
        }
        public MainForm()
        {
            InitializeComponent();
            currentTileset.Load(DefaultTilesetFilename);
            updateTilesetListView();
            updateMap();
        }
        private void updateTilePreview()
        {
            updateTileBitmaps();
            pbTilePreview.Image = tileBitmaps[currentTile];
            pbTilePreview.Width = currentTileset.TileWidth;
            pbTilePreview.Height = currentTileset.TileHeight;
        }
        private void updateMap()
        {
            if (pbMap.Width != currentTileset.TileWidth * currentMap.Width || pbMap.Height != currentTileset.TileHeight * currentMap.Height)
            {
                pbMap.Image = new Bitmap(currentTileset.TileWidth * currentMap.Width, currentTileset.TileHeight * currentMap.Height, PixelFormat.Format32bppArgb);
                pbMap.Width = pbMap.Image.Width;
                pbMap.Height = pbMap.Image.Height;
            }
            Graphics g = Graphics.FromImage(pbMap.Image);
            Bitmap bitmap = null;
            updateTileBitmaps();
            updateDirtyMapCells();
            updateCursorBitmap();
            for (int x = 0; x < currentMap.Width; ++x)
            {
                for (int y = 0; y < currentMap.Height; ++y)
                {
                    if (dirtyMapCells[x, y])
                    {
                        dirtyMapCells[x, y] = false;
                        bitmap = tileBitmaps[currentMap.GetCellValue((byte)x, (byte)y)];
                        g.DrawImage(bitmap, x * currentTileset.TileWidth, y * currentTileset.TileHeight, new Rectangle(0, 0, currentTileset.TileWidth, currentTileset.TileHeight), GraphicsUnit.Pixel);
                        if ((x == cursorX) && (y == cursorY))
                        {
                            bitmap = cursorBitmap;
                            g.DrawImage(bitmap, x * currentTileset.TileWidth, y * currentTileset.TileHeight, new Rectangle(0, 0, currentTileset.TileWidth, currentTileset.TileHeight), GraphicsUnit.Pixel);
                        }
                        pbMap.Invalidate(new Rectangle(x * currentTileset.TileWidth, y * currentTileset.TileHeight, currentTileset.TileWidth, currentTileset.TileHeight));
                    }
                }
            }
        }
        private void lvTileset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTileset.SelectedIndices.Count > 0)
            {
                if (lvTileset.SelectedIndices[0] != currentTile)
                {
                    currentTile = (byte)lvTileset.SelectedIndices[0];
                }
            }
            updateTilePreview();
        }

        private void pbMap_MouseMove(object sender, MouseEventArgs e)
        {
            int newCursorX = e.X / currentTileset.TileWidth;
            int newCursorY = e.Y / currentTileset.TileHeight;
            if ((newCursorX != cursorX) || (newCursorY != cursorY))
            {
                if (newCursorX >= 0 && newCursorX < currentMap.Width && newCursorY >= 0 && newCursorY < currentMap.Height)
                {
                    dirtyMapCells[cursorX, cursorY] = true;
                    cursorX = (byte)newCursorX;
                    cursorY = (byte)newCursorY;
                    if (mouseDown)
                    {
                        currentMap.SetCellValue(cursorX, cursorY, currentTile);
                    }
                    dirtyMapCells[cursorX, cursorY] = true;
                    updateMap();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openTilesetDialog.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            reloadTileBitmaps = true;
            reloadCursorBitmap = true;
            recreateDirtyMapCells = true;
            currentTileset.Load(openTilesetDialog.FileName);
            updateTilesetListView();
            updateMap();
        }

        private void pbMap_MouseDown(object sender, MouseEventArgs e)
        {
            currentMap.SetCellValue(cursorX, cursorY, currentTile);
            dirtyMapCells[cursorX, cursorY] = true;
            updateMap();
            mouseDown = true;
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = openMapDialog.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            currentMap = CQMLoader.LoadFromFile(openMapDialog.FileName);
            recreateDirtyMapCells = true;
            updateMap();
        }

        private void pbMap_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveMapDialog.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            currentMap.ToFile(saveMapDialog.FileName);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openMapDialog.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            CQMFile mergeMap = CQMLoader.LoadFromFile(openMapDialog.FileName);
            MergeTransparencyDialog mergeDlg = new MergeTransparencyDialog();
            result = mergeDlg.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            for (int x = 0; x < currentMap.Width && x < mergeMap.Width; ++x)
            {
                for (int y = 0; y < currentMap.Height && y < mergeMap.Height; ++y)
                {
                    if (mergeMap.GetCellValue((byte)x, (byte)y) != mergeDlg.TransparentValue)
                    {
                        currentMap.SetCellValue((byte)x, (byte)y, mergeMap.GetCellValue((byte)x, (byte)y));
                    }
                }
            }
            recreateDirtyMapCells = true;
            updateMap();

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewMapDialog mapDlg = new NewMapDialog();
            DialogResult result = mapDlg.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            currentMap = new CQMFile(mapDlg.MapWidth, mapDlg.MapHeight);
            for (int x = byte.MinValue; x < byte.MaxValue - byte.MinValue + 1; ++x)
            {
                for (int y = byte.MinValue; y < byte.MaxValue - byte.MinValue + 1; ++y)
                {
                    currentMap.SetCellValue((byte)x, (byte)y, mapDlg.MapFill);
                }
            }
            recreateDirtyMapCells = true;
            updateMap();
        }
    }
}
