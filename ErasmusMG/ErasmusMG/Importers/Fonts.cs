using ErasmusMG.Globals;
using Microsoft.Xna.Framework.Graphics;
using SpriteFontPlus;
using System.IO;

namespace ErasmusMG.Importers;
public static class Fonts
{
    // Load .ttf as SpriteFont.
    public static SpriteFont LoadTTF(string pathToTtf)
    {
        var fontBakeResult = TtfFontBaker.Bake(File.ReadAllBytes(Engine.ContentDir + pathToTtf),
            25,
            1024,
            1024,
            new[]
            {
                CharacterRange.BasicLatin,
                CharacterRange.Latin1Supplement,
                CharacterRange.LatinExtendedA,
                CharacterRange.Cyrillic
            }
        );

        return fontBakeResult.CreateSpriteFont(Engine.Graphics.GraphicsDevice);
    }
}
