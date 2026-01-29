using System.Runtime.InteropServices;
using System.Security;


[StructLayout(LayoutKind.Sequential)]
public record struct Color(byte Red, byte Green, byte Blue, byte Alpha);

[SuppressUnmanagedCodeSecurity]
public static unsafe partial class  Raylib
{
    [DllImport("libraylib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern void InitWindow(int width, int height, string title);
    
    [DllImport("libraylib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetTargetFPS(int targetFps);
    
    [DllImport("libraylib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool WindowShouldClose();
    
    [DllImport("libraylib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BeginDrawing();
    
    [DllImport("libraylib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ClearBackground(Color color);
    
    [DllImport("libraylib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern void DrawText(string text, int posX, int posY, int fontSize, Color color);
    
    [DllImport("libraylib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void EndDrawing();
    
    [DllImport("libraylib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CloseWindow();
}