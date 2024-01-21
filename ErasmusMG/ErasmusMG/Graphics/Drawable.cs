using ErasmusMG.Importers;
using ErasmusMG.Tree;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ErasmusMG.Graphics;
public abstract class Drawable : Component
{
    // Properties.
    protected Texture2D texture = null;
    protected Vector2 size = Vector2.Zero;
    public Vector2 ScaledSize = Vector2.Zero; // Size of the drawable component after scaling.
    protected Rectangle sourceRect { get; set; } = Rectangle.Empty;
    protected SpriteEffects effects { get; set; } = SpriteEffects.None;
    public Color Tint { get; set; } = Color.White;
    public Vector2 Origin { get; set; } = Vector2.Zero;




    // Constructor.
    public Drawable(string name, Vector2 size, string pathToTexture) : base(name)
    {
        this.texture = Textures.LoadTexture2D(pathToTexture);
        this.size = size;
        this.sourceRect = new Rectangle(0, 0, (int)size.X, (int)size.Y);
    }


    // Update method.
    public override void Update(double deltaTime)
    {
        this.ScaledSize = new Vector2(this.size.X * this.Scale.X, this.size.Y * this.Scale.Y);
        base.Update(deltaTime);
    }


    // Flip self horizontally.
    public void FlipH(int dir)
    {
        if (dir == -1) this.effects = SpriteEffects.FlipHorizontally;
        if (dir == 1) this.effects = SpriteEffects.None;
    }
}
