using ErasmusMG.Globals;
using ErasmusMG.Physics;
using ErasmusTest.Source;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace ErasmusTest;
public class Game : ErasmusMG.ErasmusMG
{
    private Player test;
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
        
        Engine.Root.SetRootComponent(test);
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        Engine.Root.Update(gameTime.ElapsedGameTime.TotalSeconds);
    }

    protected override void Draw(GameTime gameTime)
    {
        Engine.Graphics.GraphicsDevice.Clear(Color.Beige);
        Engine.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        Engine.Root.Draw(gameTime.ElapsedGameTime.TotalSeconds);

        Engine.SpriteBatch.End();

        base.Draw(gameTime);
    }
}
