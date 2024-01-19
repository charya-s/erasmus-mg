using ErasmusMG.Tree;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace ErasmusMG.Globals;
public static class Engine
{
    // Graphics and rendering.
    public static GraphicsDeviceManager Graphics { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }


    // Importing and asset loading.
    public static string ContentDir { get; set; }


    // Tree.
    public static Root Root { get; set; }
}
