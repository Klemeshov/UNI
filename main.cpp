#include <iostream>
#include <SFML/graphics.hpp>
#include "push_relabel.h"

using namespace std;
using namespace sf;

int main() {
    Image track;

    if (!track.loadFromFile("C:\\Users\\dima-\\Desktop\\banana1-gr-320.jpg")) {
        // oops, loading failed, handle it
        return 0;
    }
    Vector2u size = track.getSize();

    std::vector<node> nodes;
    std::vector<std::vector<edge> > edges(size.x * size.y + 2, std::vector<edge>(size.x * size.y + 2));

    //..построение графа по картинке(без S и T)
    for (int i = 0; i < size.x; i++)
        for (int j = 0; j < size.y; j++) {
            //создадим вершину
            nodes.push_back(node{int(size.y) * i + j, 0, 0, i, j});
            //добавим ребро с i-1
            if (i > 0) {
                Color p1 = track.getPixel(i, j);
                Color p2 = track.getPixel(i - 1, j);
                edges[int(size.y) * i + j][int(size.y) * (i - 1) + j] = edge{std::abs(p1.r - p2.r), 0};
                edges[int(size.y) * (i - 1) + j][int(size.y) * i + j] = edge{std::abs(p1.r - p2.r), 0};
            }
            //добавим ребро с j-1
            if (j > 0) {
                Color p1 = track.getPixel(i, j);
                Color p2 = track.getPixel(i, j - 1);
                edges[int(size.y) * i + j][int(size.y) * i + j - 1] = edge{std::abs(p1.r - p2.r), 0};
                edges[int(size.y) * i + j - 1][int(size.y) * i + j] = edge{std::abs(p1.r - p2.r), 0};
            }
            //добавим ребро с j-1 i-1
//            if (j > 0 && i > 0) {
//                Color p1 = track.getPixel(i, j);
//                Color p2 = track.getPixel(i - 1, j - 1);
//                edges[int(size.y) * i + j][int(size.y) * (i - 1) + j - 1] = edge{std::abs(p1.r - p2.r), 0};
//                edges[int(size.y) * (i - 1) + j - 1][int(size.y) * i + j] = edge{std::abs(p1.r - p2.r), 0};
//            }
        }


// Рендер картинки
    RenderWindow window(VideoMode(size.x, size.y), "SFML Works!", Style::Close | Style::Titlebar);

    Texture t;
    t.loadFromImage(track);
    Sprite s;
    s.setTexture(t);

    // Главный цикл приложения. Выполняется, пока открыто окно
    while (window.isOpen()) {
        // Обрабатываем очередь событий в цикле
        Event event;
        while (window.pollEvent(event)) {
            // Пользователь нажал на «крестик» и хочет закрыть окно?
            if (event.type == Event::Closed)
                window.close();
        }

        window.draw(s);
        // Отрисовка окна
        window.display();
    }
    return 0;
}
