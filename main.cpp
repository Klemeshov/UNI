#include <iostream>
#include <vector>
#include <fstream>
#include "queue.h"

using namespace std;

struct edge{
    int u;//first node
    int v;//second node
    int c;//capacity
    int f;//flow
};

struct node{
    int number;
    int e;//error
    int h;//height
    vector<edge> edges;
};

vector<node> vertexes;

int main() {
    fstream in;
    in.open("C:\\Users\\dima-\\Desktop\\input.txt", ios::in);
    if (!in.is_open()){
        cout << "file is not open";
        return 0;
    }
    int n, m;
    in >> n>> m;

    for (int i = 0; i < n; i++)
        vertexes.push_back(node{i, 0,0});

    vertexes[0].h = n;

    for (int i =0; i < m; i++){
        int f, s, c;
        in >> f>>s>>c;
        edge k{f-1,s-1,c,0};

        if (k.u == 0)
            k.f = k.c;
        if (k.v == 0)
            k.f = -k.c;

        vertexes[f-1].edges.push_back(k);
    }
    in.close();
    return 0;
}
