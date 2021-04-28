#include "push_relabel.h"
#include <algorithm>


using namespace std;

const int inf = 1e6;

push_relabel::push_relabel(std::vector<node> nodes, std::vector<std::vector<edge>> edges) {
    this->nodes = nodes;
    this->edges = edges;
}

void push_relabel::push(int u, int v) {
    cout <<"push("<< u<<", "<<v<<");";
    int d = std::min(nodes[u].e, edges[u][v].c - edges[u][v].f);
    edges[u][v].f+=d;
    edges[v][u].f-=d;
    nodes[u].e-=d;
    nodes[v].e+=d;

    cout <<" "<<d<<endl;

    if (d && nodes[v].e == d)
        q.push(v);

}

void push_relabel::relabel(int u) {
    cout<<"relabel("<<u<<");"<<endl;
    int min_h = inf;
    for (int i = 0; i < nodes.size(); i++){
        if ( edges[u][i].c != edges[u][i].f)
            min_h = min(min_h, nodes[i].h);
    }
    nodes[u].h = min_h +1;
}
void push_relabel::discharge(int u) {
    int v = 0;
    while (nodes[u].e > 0){
        if (v < nodes.size()) {
            if (edges[u][v].c - edges[u][v].f > 0 && nodes[u].h > nodes[v].h) {
                push(u, v);
                v++;
            }
            else
                v++;
        } else {
            relabel(u);
            v = 0;
        }
    }
}

int push_relabel::max_flow(int s, int t) {
    for (auto &node : nodes){
        node.h = 0;
        node.e = 0;
    }
    nodes[s].h = nodes.size();
    nodes[s].e = inf;

    for (auto &i : edges)
        for (auto &j : i)
            j.f = 0;

    for (int i = 0; i < nodes[s].neighbours.size(); i++)
        push(s, nodes[s].neighbours[i]);
    nodes[s].e = 0;


    while (!q.empty()) {
        int u = q.pop();
        if (u != s && u != t)
            discharge(u);
    }

    int max_flow = 0;
    for (int i = 0; i < nodes.size(); i++)
        max_flow += edges[i][t].f;
    return max_flow;
}