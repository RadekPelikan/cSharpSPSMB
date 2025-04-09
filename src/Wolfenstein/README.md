# Wolfenstein projekt

- [Coding train - ray caster](https://www.youtube.com/watch?v=TOEi6T2mtHo)
- [P5 dokumentace (inspirace)](https://p5js.org/reference/p5/line/)

RP - testy

graficka knihovna
Celda - Line(Vector2 pos1, Vector2 pos2, Color color=Color.White)
Matej - Circle(Vector2 pos, uint r, Color color=Color.White)
Cinkl - Rectangle(Rectangle rect, Color color=Color.White)
Fuka - DrawImage(Vector2 pos, Color color=color.White)

Urban - implementace WallSegment(Vector2 pos1, Vector2 pos2, Color color)
Bigi - implementace Ray(Vector2 pos1, int angle) [angle je v radianech]
Pavlicek - implementace Point(WallSegment ws, Ray ray)  [kolize Ray a WallSegment]
Roman - implementace Player
Bara - implementace MapGenerator

