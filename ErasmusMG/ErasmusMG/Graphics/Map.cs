using TiledCS;
using ErasmusMG.Graphics;
using ErasmusMG.Globals;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using ErasmusMG.Importers;
using Microsoft.Xna.Framework;
using System;
using ErasmusMG.Physics;

namespace ErasmusMG;

public class Map : Drawable
{
// Properties.  
    protected TiledMap tiledMap { get; private set; } = null;
    private TiledTileset tileSet { get; set; } = null;
    private Texture2D tileAtlas { get; set; } = null;
    private List<(string layer, Rectangle src, Rectangle dest)> tiles { get; set; } = new(); // Layer name, source rect, dest rect.
    private bool visibleColliders = false;


    // Constructor.
    public Map(string name, string pathToContent, string pathToTsx, string pathToAtlas) : base(name, pathToContent)
    {
        this.tiledMap = new TiledMap(Engine.ContentDir + pathToContent);
        this.tileSet = new TiledTileset(Engine.ContentDir + pathToTsx);
        this.tileAtlas = Textures.LoadTexture2D(pathToAtlas);
    }


    // Load.
    public override void Load()
    {
        // Load the tiles from the tiled map.
        IEnumerable<TiledLayer> tileLayers = this.tiledMap.Layers.Where(x => x.type == TiledLayerType.TileLayer);
        foreach (TiledLayer layer in tileLayers) 
        {
            for (int y = 0; y < layer.height; y++)
            {
                for (int x = 0; x < layer.width; x++)
                {
                    // Get current tile position.
                    int index = (y * layer.width) + x;  // Renders from left to right, top to bottom.
                    int gid = layer.data[index];        // Tile index.
                    int tileX = (x * this.tiledMap.TileWidth);   // Current tile.
                    int tileY = (y * this.tiledMap.TileHeight);  // Current tile.

                    // Gid 0 = no tile there.
                    if (gid == 0) continue;

                    // Get current tile's source rectangle and add it to the list.
                    TiledMapTileset mapTileset = this.tiledMap.GetTiledMapTileset(gid);
                    TiledSourceRect tileRect = this.tiledMap.GetSourceRect(mapTileset, this.tileSet, gid);

                    // Add source and destination rects to the list.
                    this.tiles.Add((
                        layer.name,
                        new Rectangle(tileRect.x, tileRect.y, tileRect.width, tileRect.height),
                        new Rectangle(tileX, tileY, this.tiledMap.TileWidth, this.tiledMap.TileHeight)
                        ));
                }
            }
        }

        base.Load();
    }
    // Update.
    public override void Update(double deltaTime)
    {
        base.Update(deltaTime);
    }
    // Draw.
    public override void Draw(double deltaTime)
    {
        // Draw each tile.
        foreach ((string layer, Rectangle src, Rectangle dest) in this.tiles)
        {
            Engine.SpriteBatch.Draw(    this.tileAtlas, 
                                        new Vector2(dest.X + this.GlobalPosition.X, dest.Y + this.GlobalPosition.Y),
                                        src, 
                                        this.Tint, 
                                        this.Rotation, 
                                        this.Origin, 
                                        this.Scale,
                                        this.effects, 
                                        this.LayerDepth
                                    );
        }

        base.Draw(deltaTime);
    }


    // Set collision layer.
    public void SetCollisionLayer(string layerName)
    {
        foreach ((string layer, Rectangle src, Rectangle dest) in this.tiles)
        {
            if (layer != layerName) continue; // Not collision layer.

            Collider collider = new(this.GetChildren<Collider>().Count.ToString(), new Vector2(src.Width, src.Height));
            collider.GlobalPosition = new Vector2(dest.X, dest.Y);
            this.AddChild(collider);
        }
    }

    // Change colliders visibility.
    public bool VisibleCollider
    {
        get { return this.visibleColliders; }
        set
        {
            foreach(Collider c in this.GetChildren<Collider>()) c.VisibleCollider = value;
        }
    }
}
