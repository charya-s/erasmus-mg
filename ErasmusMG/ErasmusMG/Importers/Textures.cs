

using ErasmusMG.Globals;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace ErasmusMG.Importers;
public static class Textures
{
    // Load .png as Texture2D.
    public static Texture2D LoadTexture2D(string pathToPng)
    {
        using (FileStream stream = new FileStream(Engine.ContentDir + pathToPng, FileMode.Open))
        {
            return Texture2D.FromStream(Engine.Graphics.GraphicsDevice, stream);
        }
    }
}
