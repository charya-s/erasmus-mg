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


    // Constructor.
    public Sprite(string name, Vector2 size, string pathToTexture) : base(name, size, pathToTexture)
    {
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
