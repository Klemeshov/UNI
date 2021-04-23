#include <iostream>
#include <vector>
#include <fstream>
#include "queue.h"
#include <algorithm>
#include "push_relabel.h"

using namespace std;


int main() {
    std::vector<node> nodes;
    std::vector<std::vector<edge> > edges;

    fstream in;
    in.open("C:\\Users\\dima-\\Desktop\\input.txt", ios::in);
    if (!in.is_open()){
        cout << "file is not open";
        return 0;
    }
    int n, m;
    in >> n>> m;

    for (int i = 0; i < n; i++) {
        nodes.push_back(node{i, 0, 0});
        vector<edge> b(n);
        fill(b.begin(), b.end(), edge{0,0});
        edges.push_back(b);
    }
    nodes[0].h = n;

    for (int i =0; i < m; i++){
        int f, s, c;
        in >> f>>s>>c;

        edges[f-1][s-1] = edge{c,0};
        edges[s-1][f-1] = edge{-c, 0};
        nodes[f-1].neighbours.push_back(s-1);
    }

    push_relabel a(nodes, edges);
    in.close();
    return 0;
}
