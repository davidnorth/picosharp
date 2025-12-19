using System;
using Raylib_cs;
using System.Numerics;

namespace PicoSharp
{
    public abstract class Game
    {
        private const int GameWidth = 320;
        private const int GameHeight = 240;
        private const int Scale = 2;
        private const int WindowWidth = GameWidth * Scale;
        private const int WindowHeight = GameHeight * Scale;

        private RenderTexture2D _target;
        
        // API for the user to override
        public virtual void Init() { }
        public abstract void Update();
        public abstract void Draw();

        public void Run()
        {
            Raylib.SetTraceLogLevel(TraceLogLevel.Warning);
            Raylib.InitWindow(WindowWidth, WindowHeight, "PicoSharp");
            Raylib.SetTargetFPS(60);

            // Load resources for the system here if needed
            _target = Raylib.LoadRenderTexture(GameWidth, GameHeight);
            
            // Texture filtering point for pixel perfect look
            Raylib.SetTextureFilter(_target.Texture, TextureFilter.Point);

            Init();

            while (!Raylib.WindowShouldClose())
            {
                Update();

                // Draw to the render texture (low res)
                Raylib.BeginTextureMode(_target);
                // We don't automatically clear here to allow cumulative drawing if desired, 
                // but typically users will Clear(Color) at the start of Draw().
                
                Draw();
                
                Raylib.EndTextureMode();

                // Draw the render texture to the screen (scaled up)
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib_cs.Color.Black);
                
                // Draw the texture scaled heavily
                // Source rect is the texture itself (note: OpenGL coordinates, so height might need to be flipped if upside down, 
                // but Raylib usually handles this. If it's upside down, use -GameHeight for height)
                Rectangle sourceRec = new Rectangle(0, 0, GameWidth, -GameHeight);
                Rectangle destRec = new Rectangle(0, 0, WindowWidth, WindowHeight);
                Vector2 origin = new Vector2(0, 0);
                
                Raylib.DrawTexturePro(_target.Texture, sourceRec, destRec, origin, 0.0f, Raylib_cs.Color.White);
                
                Raylib.EndDrawing();
            }

            Raylib.UnloadRenderTexture(_target);
            Raylib.CloseWindow();
        }

        // --- Sprite API ---

        protected Sprite LoadSprite(string path)
        {
            return new Sprite(path);
        }
        
        protected SpriteSheet LoadSpriteSheet(string path, int tileWidth, int tileHeight, int spacing)
        {
            return new SpriteSheet(path, tileWidth, tileHeight, spacing);
        }

        protected void DrawSprite(Sprite sprite, int x, int y)
        {
            Raylib.DrawTextureRec(sprite.Texture, sprite.SourceRect, new System.Numerics.Vector2(x, y), Raylib_cs.Color.White);
        }

        // --- Input API ---

        protected bool IsDown(Key key) => Raylib.IsKeyDown(MapKey(key));
        protected bool IsPressed(Key key) => Raylib.IsKeyPressed(MapKey(key));

        private KeyboardKey MapKey(Key key)
        {
            return key switch
            {
                Key.Up => KeyboardKey.Up,
                Key.Down => KeyboardKey.Down,
                Key.Left => KeyboardKey.Left,
                Key.Right => KeyboardKey.Right,
                Key.Space => KeyboardKey.Space,
                Key.LeftShift => KeyboardKey.LeftShift,
                Key.LeftControl => KeyboardKey.LeftControl,
                Key.Alt => KeyboardKey.LeftAlt,
                Key.Enter => KeyboardKey.Enter,
                Key.Escape => KeyboardKey.Escape,
                Key.W => KeyboardKey.W,
                Key.A => KeyboardKey.A,
                Key.S => KeyboardKey.S,
                Key.D => KeyboardKey.D,
                Key.Z => KeyboardKey.Z,
                Key.X => KeyboardKey.X,
                Key.C => KeyboardKey.C,
                Key.V => KeyboardKey.V,
                _ => KeyboardKey.Null
            };
        }

        // --- Drawing API ---

        protected void Clear(Raylib_cs.Color color)
        {
            Raylib.ClearBackground(color);
        }

        protected void DrawPixel(int x, int y, Raylib_cs.Color color)
        {
            Raylib.DrawPixel(x, y, color);
        }

        protected void DrawCircle(int centerX, int centerY, int radius, Raylib_cs.Color color)
        {
            Raylib.DrawCircleLines(centerX, centerY, radius, color);
        }

        protected void DrawFilledCircle(int centerX, int centerY, int radius, Raylib_cs.Color color)
        {
            Raylib.DrawCircle(centerX, centerY, radius, color); 
        }        
        protected void DrawCircleLines(int centerX, int centerY, int radius, Raylib_cs.Color color)
        {
            Raylib.DrawCircleLines(centerX, centerY, radius, color);
        }

        protected void DrawRect(int x, int y, int width, int height, Raylib_cs.Color color)
        {
            Raylib.DrawRectangleLines(x, y, width, height, color);
        }

        protected void DrawFilledRect(int x, int y, int width, int height, Raylib_cs.Color color)
        {
            Raylib.DrawRectangle(x, y, width, height, color);
        }

        protected void DrawLine(int startX, int startY, int endX, int endY, Raylib_cs.Color color)
        {
            Raylib.DrawLine(startX, startY, endX, endY, color);
        }

        protected Raylib_cs.Color GetPixel(int x, int y)
        {
            // WARNING: This is slow because it downloads the texture from GPU
            // In a real PICO-8 like environment we might want a software buffer
            Image image = Raylib.LoadImageFromTexture(_target.Texture);
            Raylib_cs.Color color = Raylib.GetImageColor(image, x, y);
            Raylib.UnloadImage(image);
            return color;
        }

        protected void DrawText(string text, int x, int y, int fontSize, Raylib_cs.Color color)
        {
            // Using default font for now
            Raylib.DrawText(text, x, y, fontSize, color);
        }
    }
}
