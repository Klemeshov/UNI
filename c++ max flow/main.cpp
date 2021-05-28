#include <iostream>
#include <SFML/graphics.hpp>
#include "push_relabel.h"
#include <map>
#include <fstream>

using namespace std;
using namespace sf;

int main() {
    Image track;
    //откроем картинку
    if (!track.loadFromFile("C:\\Users\\dima-\\Desktop\\banana1-gr-320.jpg")) {
        // oops, loading failed, handle it
        return 0;
    }
    //Размер картинки
    Vector2u size = track.getSize();

    vector<node> nodes;
    map<pair<int, int>, edge> edges;

    ifstream in;
    in.open("C:\\Users\\dima-\\Desktop\\input.txt");

    int n, m;
    in>> n >> m;
    



    //..построение графа по картинке(без S и T)
//    for (int i = 0; i < int(size.x); i++)
//        for (int j = 0; j < int(size.y); j++) {
//            //создадим вершину
//            nodes.push_back(node{int(size.y) * i + j, 0, 0, i, j});
//            //добавим ребро с i-1
//            if (i > 0) {
//                Color p1 = track.getPixel(i, j);
//                Color p2 = track.getPixel(i - 1, j);
//                edges[{int(size.y) * i + j, int(size.y) * (i - 1) + j}] = edge{std::abs(p1.r - p2.r), 0};
//                edges[{int(size.y) * (i - 1) + j, int(size.y) * i + j}] = edge{std::abs(p1.r - p2.r), 0};
//                nodes[int(size.y) * i + j].neighbours.push_back(int(size.y) * (i - 1) + j);
//                nodes[int(size.y) * (i - 1) + j].neighbours.push_back(int(size.y) * i + j);
//            }
//            //добавим ребро с j-1
//            if (j > 0) {
//                Color p1 = track.getPixel(i, j);
//                Color p2 = track.getPixel(i, j - 1);
//                edges[{int(size.y) * i + j, int(size.y) * i + j - 1}] = edge{std::abs(p1.r - p2.r), 0};
//                edges[{int(size.y) * i + j - 1, int(size.y) * i + j}] = edge{std::abs(p1.r - p2.r), 0};
//                nodes[int(size.y) * i + j].neighbours.push_back(int(size.y) * i + j - 1);
//                nodes[int(size.y) * i + j - 1].neighbours.push_back(int(size.y) * i + j);
//            }
//            //добавим ребро с j-1 i-1
////            if (j > 0 && i > 0) {
////                Color p1 = track.getPixel(i, j);
////                Color p2 = track.getPixel(i - 1, j - 1);
////                edges[{int(size.y) * i + j, int(size.y) * (i - 1) + j - 1}] = edge{std::abs(p1.r - p2.r), 0};
////                edges[{int(size.y) * (i - 1) + j - 1, int(size.y) * i + j}] = edge{std::abs(p1.r - p2.r), 0};
////                nodes[int(size.y) * i + j].neighbours.push_back(int(size.y) * (i - 1) + j - 1);
////                nodes[int(size.y) * (i - 1) + j - 1].neighbours.push_back(int(size.y) * i + j);
////            }
//        }


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
            if (event.type == Event::Closed) {
                window.close();
                return 0;
            }
        }

        window.draw(s);
        // Отрисовка окна
        window.display();
    }
    return 0;
}
