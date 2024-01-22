using ErasmusMG.Globals;
using ErasmusMG.Importers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace ErasmusMG.Graphics;
public class TextLabel : Drawable
{
    // Properties.  
    protected SpriteFont font;
    protected string text { get; private set; }


    // Constructor.
    public TextLabel(string name, Vector2 size, string pathToContent, string text) : base(name, size, pathToContent)
    {
        this.font = Fonts.LoadTTF(pathToContent);
        this.text = text;
        this.Size = this.font.MeasureString(this.text);
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
        Engine.SpriteBatch.DrawString(  this.font,
                                        this.text,
                                        this.GlobalPosition,
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
