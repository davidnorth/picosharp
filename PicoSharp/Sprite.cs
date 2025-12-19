using Raylib_cs;

namespace PicoSharp
{
    public class Sprite
    {
        internal Texture2D Texture { get; private set; }
        internal Rectangle SourceRect { get; private set; }
        
        public int Width => (int)SourceRect.Width;
        public int Height => (int)SourceRect.Height;

        public Sprite(string path)
        {
            Texture = Raylib.LoadTexture(path);
            SourceRect = new Rectangle(0, 0, Texture.Width, Texture.Height);
        }

        internal Sprite(Texture2D texture, Rectangle sourceRect)
        {
            Texture = texture;
            SourceRect = sourceRect;
        }
    }
}
