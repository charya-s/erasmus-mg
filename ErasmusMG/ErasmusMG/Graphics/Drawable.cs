using ErasmusMG.Globals;
using ErasmusMG.Tree;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace ErasmusMG.Graphics;
public abstract class Drawable : Component
{
    // Properties.
    public Vector2 Size = Vector2.Zero;
    public Vector2 ScaledSize = Vector2.Zero; // Size of the drawable component after scaling.
    protected Rectangle sourceRect { get; set; } = Rectangle.Empty;
    protected SpriteEffects effects { get; set; } = SpriteEffects.None;
    public Color Tint { get; set; } = Color.White;
    public Vector2 Origin { get; set; } = Vector2.Zero;
    public bool VisibleBox { get; set; } = false;
    private Texture2D visibleBox { get; set; } = new Texture2D(Engine.Graphics.GraphicsDevice, 1, 1); // Draw a box according to the scale size.



    // Constructors.
    public Drawable(string name, string pathToContent) : base(name)
    {
        this.visibleBox = new Texture2D(Engine.Graphics.GraphicsDevice, 1, 1);
        this.visibleBox.SetData(new Color[] { Color.LightBlue });
    }
    public Drawable(string name, Vector2 size, string pathToContent) : base(name)
    {
        this.Size = size;

        this.visibleBox = new Texture2D(Engine.Graphics.GraphicsDevice, 1, 1);
        this.visibleBox.SetData(new Color[] { Color.LightBlue });
    }


    // Load method.
    public override void Load()
    {
        this.sourceRect = new Rectangle(0, 0, (int)Size.X, (int)Size.Y);
        this.ScaledSize = new Vector2(this.Size.X * this.Scale.X, this.Size.Y * this.Scale.Y);
        base.Load();
    }


    // Update method.
    public override void Update(double deltaTime)
    {
        base.Update(deltaTime); 
    }


    // Draw method.
    public override void Draw(double deltaTime)
    {
        if (this.VisibleBox) // Draw a visible bounding box is enabled.
        {
            Engine.SpriteBatch.Draw(    this.visibleBox, 
                                        this.GlobalPosition, 
                                        this.sourceRect, 
                                        Color.LightBlue * 0.75f, 
                                        this.Rotation, 
                                        this.Origin, 
                                        this.Scale, 
                                        this.effects, 
                                        this.LayerDepth
                                    );
        }
        base.Draw(deltaTime);
    }


    // Flip self horizontally.
    public void FlipH(int dir)
    {
        if (dir == -1) this.effects = SpriteEffects.FlipHorizontally;
        if (dir == 1) this.effects = SpriteEffects.None;
    }


    // Overriden scale setter (auto-updates ScaledSize).
    public override Vector2 Scale
    {
        get { return this.scale; }
        set { 
            this.scale = value; 
            this.ScaledSize = new Vector2(this.Size.X * this.Scale.X, this.Size.Y * this.Scale.Y); 
        }
    }
}
