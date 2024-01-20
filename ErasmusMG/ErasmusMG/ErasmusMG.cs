using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ErasmusMG.Globals;
using System.IO;
using System.Diagnostics;


namespace ErasmusMG
{
    public class ErasmusMG : Game
    {
        public ErasmusMG()
        {
            Engine.Graphics = new GraphicsDeviceManager(this);
            Engine.Graphics.SynchronizeWithVerticalRetrace = false;
            this.IsMouseVisible = true;
            this.IsFixedTimeStep = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            Engine.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Engine.Root = new Tree.Root();
            Engine.ContentDir = Directory.GetCurrentDirectory() + "/Content/"; 

            // Tree loading is done whenever a root component is set.
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //Debug.WriteLine(1/gameTime.ElapsedGameTime.TotalSeconds);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
