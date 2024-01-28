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
    public string Text { get; set; }


    // Constructor.
    public TextLabel(string name, string pathToContent, string text) : base(name, pathToContent)
    {
        this.font = Fonts.LoadTTF(pathToContent);
        this.Text = text;
        this.Size = this.font.MeasureString(this.Text);
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
        if (!this.Visible) return;
        Engine.SpriteBatch.DrawString(  this.font,
                                        this.Text,
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
