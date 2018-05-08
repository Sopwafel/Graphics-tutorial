using System;
using System.IO;

namespace Template
{

    class Game
    {
        float centerx = 0;
        float centery = 0;
        float a = 0;
        // member variables
        public Surface screen;
        // initialize
        public void Init()
        {
        }

        /// <summary>
        /// Handles keyPresses for shifting the image with cursor keys
        /// </summary>
        public void keyPress()
        {
            var keyboard = OpenTK.Input.Keyboard.GetState();
            if (keyboard[OpenTK.Input.Key.Left])
                centerx -= 0.01F;
            else if (keyboard[OpenTK.Input.Key.Right])
                centerx += 0.01F;

            if (keyboard[OpenTK.Input.Key.Down])
                centery += 0.01F;
            if (keyboard[OpenTK.Input.Key.Up])
                centery -= 0.01F;

        }
        // tick: renders one frame
        public void Tick()
        {
            keyPress();
            screen.Clear(0);
            // A step
            a= a + 0.01F;

            // These rotate the square
            float x1 = -1, y1 = 1.0f;
            float rx1 = (float)(x1 * Math.Cos(a) - y1 * Math.Sin(a));
            float ry1 = (float)(x1 * Math.Sin(a) + y1 * Math.Cos(a));

            float x2 = 1, y2 = 1.0f;
            float rx2 = (float)(x2 * Math.Cos(a) - y2 * Math.Sin(a));
            float ry2 = (float)(x2 * Math.Sin(a) + y2 * Math.Cos(a));

            float x3 = 1, y3 = -1.0f;
            float rx3 = (float)(x3 * Math.Cos(a) - y3 * Math.Sin(a));
            float ry3 = (float)(x3 * Math.Sin(a) + y3 * Math.Cos(a));

            float x4 = -1, y4 = -1.0f;
            float rx4 = (float)(x4 * Math.Cos(a) - y4 * Math.Sin(a));
            float ry4 = (float)(x4 * Math.Sin(a) + y4 * Math.Cos(a));

            // These translate to screen coordinates and actually draw the square
            screen.Line(TX(rx1), TY(ry1), TX(rx2), TY(ry2), 0xffffff);
            screen.Line(TX(rx2), TY(ry2), TX(rx3), TY(ry3), 0xffffff);
            screen.Line(TX(rx3), TY(ry3), TX(rx4), TY(ry4), 0xffffff);
            screen.Line(TX(rx4), TY(ry4), TX(rx1), TY(ry1), 0xffffff);


        }

        public int TX(float x)
        {
            x += 2+centerx;
            int factor = screen.width / 4;

            x *= (screen.width / 4);
            return (int)x;
        }

        public int TY(float y)
        {
            y += 2+centery;
            y *= (screen.height / 4);
            return (int)y;
        }
    }

} // namespace Template