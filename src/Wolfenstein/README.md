# Wolfenstein projekt

- [Coding train - ray caster](https://www.youtube.com/watch?v=TOEi6T2mtHo)
- [P5 dokumentace (inspirace)](https://p5js.org/reference/p5/line/)

RP - testy

## graficka knihovna
- **Celda1** - Line(Vector2 pos1, Vector2 pos2, Color color=Color.White)
- **Šilhy** - Circle(Vector2 pos, uint r, Color color=Color.White)
- **Ten co chybi** - Rectangle(Rectangle rect, Color color=Color.White)
- **Honza** - DrawImage(Vector2 pos, Color color=color.White)


## implementace hry 

- **Urban** - implementace WallSegment(Vector2 pos1, Vector2 pos2, Color color)
- **Žďárský** - implementace Ray(Vector2 pos1, int angle) [angle je v radianech]
- **Pavel** - implementace Point(WallSegment ws, Ray ray)  [kolize Ray a WallSegment]
- **Roman** - implementace Player
- **Bara** - implementace MapGenerator

