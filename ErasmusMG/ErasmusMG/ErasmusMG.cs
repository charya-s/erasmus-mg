using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ErasmusMG.Globals;


namespace ErasmusMG
{
    public class ErasmusMG : Game
    {

        public ErasmusMG()
        {
            Engine.Graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Engine.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Engine.Root = new Tree.Root();

            Engine.Root.Load();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Engine.Root.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Engine.Graphics.GraphicsDevice.Clear(Color.Beige);
            base.Draw(gameTime);

            // Draw.
            Engine.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

            Engine.Root.Draw(gameTime);

            Engine.SpriteBatch.End();
        }
    }
}
