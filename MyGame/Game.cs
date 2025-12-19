using PicoSharp;

public struct Ball
{
    public float x;
    public float y;
    public float xv;
    public float yv;
}

namespace MyGame
{
    public class MyGame : Game
    {
        private int _x = 160;
        private int _y = 120;
        private int _radius = 10;
        private Sprite _sprite;

        private Ball[] balls;
        private Random _rng = new Random();
        
        private SpriteSheet _characterSheet;
        private int _frameIndex = 0;
        private int _frameTimer = 0;

        public override void Init()
        {
            _sprite = LoadSprite("sprite.png");
            _characterSheet = LoadSpriteSheet("spritesheet.png", 16, 16, 0);

            balls = new Ball[10];

            // 10 balls
            for(int i = 0 ; i < 10; i++) {
                balls[i] = new Ball();
                // A random position
                balls[i].x = _rng.Next(0, 320);
                balls[i].y = _rng.Next(0, 240);
                // A random velocity
                balls[i].xv = _rng.Next(-2, 3); // -2 to 2
                balls[i].yv = _rng.Next(-2, 3);
            }

        }

        public override void Update()
        {
            if (IsDown(Key.Right)) _x += 2;
            if (IsDown(Key.Left)) _x -= 2;
            if (IsDown(Key.Up)) _y -= 2;
            if (IsDown(Key.Down)) _y += 2;

            // Animate sprite every 10 frames
            _frameTimer++;
            if (_frameTimer >= 10)
            {
                _frameTimer = 0;
                _frameIndex++;
                if (_frameIndex > 3) _frameIndex = 0; // Cycle first 4 frames
            }

            // Update balls
            for(int i = 0 ; i < 10; i++) {
                balls[i].x += balls[i].xv;
                balls[i].y += balls[i].yv;
                // bounce of edges
                if (balls[i].x < 0 || balls[i].x > 320) balls[i].xv = -balls[i].xv;
                if (balls[i].y < 0 || balls[i].y > 240) balls[i].yv = -balls[i].yv;
            }
        }

        public override void Draw()
        {
            Clear(Color.Black);
            
            DrawSprite(_sprite, _x, _y);
            
            // Draw animated character from spritesheet
            DrawSprite(_characterSheet.Get(_frameIndex), _x, _y + 20);
            
            DrawRect(10, 10, 100, 100, Color.Red);
            DrawCircle(128, 128, 50, Color.Lavender);
            
            DrawLine(0, 0, 320, 240, Color.Green);
            
            // simple visual test for GetPixel: draw a dot where the center pixel color is detected
            var c = GetPixel(160, 120);
            DrawPixel(10, 200, c);
           
            DrawText("HELLO PICOSHARP", 10, 10, 20, Color.White);

            // draw the balls
            for(int i = 0; i < 10; i++){
                // just a 8px circle
                DrawCircle((int)balls[i].x, (int)balls[i].y, 4, Color.White);
            }
        }
    }
}
