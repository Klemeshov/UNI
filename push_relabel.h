#ifndef GRAPH_PROJECT_PUSH_RELABEL_H
#define GRAPH_PROJECT_PUSH_RELABEL_H
#include <vector>
#include "queue.h"


struct edge{
    int c;//capacity
    int f;//flow
};

struct node{
    int number;
    int e;//error
    int h;//height
    std::vector<int> neighbours;
};

class push_relabel {
public:
    push_relabel(std::vector<node> nodes,std::vector<std::vector<edge> > edges);
    int max_flow(int s, int t);
private:
    void push(int u, int v);
    void relabel(int u);
    void discharge(int u);
    std::vector<node> nodes;
    std::vector<std::vector<edge> > edges;
    queue<int> q;
};


#endif //GRAPH_PROJECT_PUSH_RELABEL_H
