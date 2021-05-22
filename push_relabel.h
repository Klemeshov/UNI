#ifndef GRAPH_PROJECT_PUSH_RELABEL_H
#define GRAPH_PROJECT_PUSH_RELABEL_H
#include <vector>
#include "queue.h"
#include <map>


struct edge{
    int c;//capacity
    int f;//flow
};


struct node{
    int number;
    int e;//error
    int h;//height
    int x;
    int y;
    std::vector<int> neighbours;
};

class push_relabel {
public:
    push_relabel(const std::vector<node>& nodes,std::map<std::pair<int, int>, edge> edges);

    long long max_flow(int s, int t);
    std::vector<node> min_cut(int s, int t);
private:
    void push(int u, int v);
    void relabel(int u);
    void discharge(int u);
    std::vector<node> dfs(int u);

    std::vector<node> nodes;
    std::map<std::pair<int, int>, edge> edges;
    queue<int> q;
    std::vector<bool> isVisit;
};


#endif //GRAPH_PROJECT_PUSH_RELABEL_H
