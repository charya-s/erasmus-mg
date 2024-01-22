using ErasmusMG.Globals;
using ErasmusMG.Importers;
using ErasmusMG.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace ErasmusMG.Graphics;
public class Sprite : Drawable
{
    // Properties.  
    protected Texture2D texture { get; private set; } = null;


    // Constructor.
    public Sprite(string name, Vector2 size, string pathToContent) : base(name, size, pathToContent)
    {
        this.texture = Textures.LoadTexture2D(pathToContent);
    }


    // Load.
    public override void Load()
    {
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
        if (this.texture == null) return;
        Engine.SpriteBatch.Draw(    this.texture,
                                    this.GlobalPosition,
                                    this.sourceRect,
                                    this.Tint,
                                    this.Rotation,
                                    this.Origin,
                                    this.Scale,
                                    this.effects,
                                    this.LayerDepth
                                );
        base.Draw(deltaTime);
    }
}
