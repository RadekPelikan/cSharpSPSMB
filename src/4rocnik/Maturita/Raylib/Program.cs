// See https://aka.ms/new-console-template for more information

// Initialization
//--------------------------------------------------------------------------------------

const int screenWidth = 800;
const int screenHeight = 450;

Color RAYWHITE = new Color(245, 245, 245, 255);
Color LIGHTGRAY = new Color(200, 200, 200, 255);
Raylib.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

Raylib.SetTargetFPS(60);

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(RAYWHITE);
    Raylib.DrawText("Congrats! You created your first window!", 190, 200, 20, LIGHTGRAY);
    Raylib.EndDrawing();
}

Raylib.CloseWindow(); // Close window and OpenGL context

return 0;