#include "push_relabel.h"
#include <algorithm>

using namespace std;

const int inf = 1e6;

push_relabel::push_relabel(std::vector<node> nodes, std::vector<std::vector<edge>> edges) {
    this->nodes = nodes;
    this->edges = edges;
}

void push_relabel::push(int u, int v) {
    int d = std::min(nodes[u].e, edges[u][v].c - edges[u][v].f);
    edges[u][v].f+=d;
    edges[v][u].f-=d;
    nodes[u].e-=d;
    nodes[v].e+=d;
}

void push_relabel::relabel(int u) {
    int min_h = inf;
    for (int i = 0; i < nodes[u].neighbours.size(); i++){
        if (edges[u][nodes[u].neighbours[i]].c != edges[u][nodes[u].neighbours[i]].f)
            min_h = min(min_h, nodes[nodes[u].neighbours[i]].h);
    }
    nodes[u].h = min_h +1;
}
void push_relabel::discharge(int u) {
    while (nodes[u].e > 0){

    }
}