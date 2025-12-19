using System.Collections.Generic;
using Raylib_cs;

namespace PicoSharp
{
    public class SpriteSheet
    {
        private Texture2D _texture;
        private int _tileWidth;
        private int _tileHeight;
        private int _spacing;
        
        private Dictionary<int, Sprite> _cache = new Dictionary<int, Sprite>();

        public SpriteSheet(string path, int tileWidth, int tileHeight, int spacing)
        {
            _texture = Raylib.LoadTexture(path);
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
            _spacing = spacing; // Spacing between sprites, if any
        }

        public Sprite Get(int index)
        {
            if (_cache.ContainsKey(index))
                return _cache[index];

            int cols = _texture.Width / (_tileWidth + _spacing);
            
            // Calculate grid position
            int col = index % cols;
            int row = index / cols;
            
            int x = col * (_tileWidth + _spacing);
            int y = row * (_tileHeight + _spacing);

            Rectangle source = new Rectangle(x, y, _tileWidth, _tileHeight);
            
            var sprite = new Sprite(_texture, source);
            _cache[index] = sprite;
            
            return sprite;
        }
    }
}
