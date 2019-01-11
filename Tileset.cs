using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace CQMEditor
{
    public class Tileset
    {
        private const string CursorTileId = "cursor";
        private const string UnknownTileId = "unknown";
        private int tileWidth = 0;
        private int tileHeight = 0;
        public int TileWidth
        {
            get
            {
                return tileWidth;
            }
        }
        public int TileHeight
        {
            get
            {
                return tileHeight;
            }
        }
        public Tile Cursor
        {
            get
            {
                return cursor;
            }
        }
        Tile unknown = null;
        Tile cursor = null;
        Dictionary<byte, Tile> tiles = new Dictionary<byte, Tile>();
        public Tile this[byte index]
        {
            get
            {
                if (tiles.ContainsKey(index))
                {
                    return tiles[index];
                }
                else
                {
                    return unknown;
                }
            }
        }
        public Tileset()
        {
        }
        public void Clear()
        {
            tileWidth = 0;
            tileHeight = 0;
            cursor = null;
            unknown = null;
            tiles = new Dictionary<byte, Tile>();
        }
        public bool Load(string filename)
        {
            Clear();
            try
            {

                XDocument doc = XDocument.Load(filename);
                XElement tilesElement = doc.Element("tiles");
                if (!int.TryParse(tilesElement.Attribute("tilewidth").Value, out tileWidth)) return false;
                if (!int.TryParse(tilesElement.Attribute("tileheight").Value, out tileHeight)) return false;
                foreach (XElement tileElement in tilesElement.Elements("tile"))
                {
                    string id = tileElement.Attribute("id").Value;
                    byte tileId = 0;
                    Tile tile = new Tile(tileElement.Element("name").Value, tileElement.Element("filename").Value);
                    if (id == CursorTileId)
                    {
                        cursor = tile;
                    }
                    else if (id == UnknownTileId)
                    {
                        unknown = tile;
                    }
                    else if (byte.TryParse(id, out tileId))
                    {
                        if (tiles.ContainsKey(tileId))
                        {
                            tiles[tileId] = tile;
                        }
                        else
                        {
                            tiles.Add(tileId, tile);
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                if ((cursor == null) || (unknown == null))
                {
                    throw new Exception();
                }
                return true;
            }
            catch
            {
                Clear();
                return false;
            }
        }
    }
}
