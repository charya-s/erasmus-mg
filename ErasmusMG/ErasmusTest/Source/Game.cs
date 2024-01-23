using ErasmusMG.Globals;
using ErasmusMG.Graphics;
using ErasmusTest.Source;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace ErasmusTest;
public class Game : ErasmusMG.ErasmusMG
{
    private Player test;
    private TextLabel fpsCounter; 
    public Game()
    {
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        base.LoadContent();

        test = new Player("Player");
        Engine.Root.AddToRoot(test);

        fpsCounter = new TextLabel("FpsCounter", "font.ttf", MathF.Round(Engine.Root.GameFPS).ToString());
        fpsCounter.GlobalPosition = new Vector2(750, 0);
        fpsCounter.Tint = Color.Black;
        fpsCounter.Scale = new Vector2(0.5f, 0.5f);
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        Engine.Root.Update(gameTime.ElapsedGameTime.TotalSeconds);

        fpsCounter.Text = MathF.Round(Engine.Root.GameFPS).ToString();
    }

    protected override void Draw(GameTime gameTime)
    {
        Engine.Graphics.GraphicsDevice.Clear(Color.Beige);
        Engine.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        Engine.Root.Draw(gameTime.ElapsedGameTime.TotalSeconds);
        fpsCounter.Draw(gameTime.ElapsedGameTime.TotalSeconds);

        Engine.SpriteBatch.End();

        base.Draw(gameTime);
    }
}
