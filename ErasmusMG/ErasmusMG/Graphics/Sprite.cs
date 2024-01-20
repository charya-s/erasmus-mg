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
    private Texture2D sprite;    



    // Constructor.
    public Sprite(string name, Vector2 size) : base(name, size)
    {
        this.sprite = Textures.LoadTexture2D("player.png");
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
        Engine.SpriteBatch.Draw(    this.sprite,
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
