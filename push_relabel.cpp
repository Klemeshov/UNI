#include "push_relabel.h"
#include <algorithm>
#include <limits.h>


using namespace std;

const int inf = INT_MAX;

push_relabel::push_relabel(const std::vector<node>& nodes,
                           std::map<std::pair<int, int>, edge> edges) {
    this->nodes = nodes;
    this->edges = edges;
    this->isVisit.resize(nodes.size());
}

void push_relabel::push(int u, int v) {
    cout << "push(" << u << ", " << v << "); = ";
    int d = std::min(nodes[u].e, edges[{u, v}].c - edges[{u, v}].f);

    edges[{u, v}].f += d;
    edges[{v, u}].f -= d;
    nodes[u].e -= d;
    nodes[v].e += d;

    cout << d << endl;

    if (d && nodes[v].e == d)
        q.push(v);

}

void push_relabel::relabel(int u) {
    cout << "relabel(" << u << ");"<< " = ";
    int min_h = inf;
    for (int i = 0; i < nodes[u].neighbours.size(); i++) {
        if (edges[{u, nodes[u].neighbours[i]}].c
        != edges[{u, nodes[u].neighbours[i]}].f)
            min_h = min(min_h, nodes[i].h);
    }
    nodes[u].h = min_h + 1;
    cout << nodes[u].h<<endl;
}

void push_relabel::discharge(int u) {
    int v = 0;
    while (nodes[u].e > 0) {
        auto nodesN = nodes[u].neighbours;
        if (v < nodesN.size()) {
            if (edges[{u,nodes[nodesN[v]].number}].c - edges[{u,nodes[nodesN[v]].number}].f > 0
            && nodes[u].h > nodes[nodesN[v]].h) {
                push(u, nodes[nodesN[v]].number);
                v++;
            } else
                v++;
        } else {
            relabel(u);
            v = 0;
        }
    }
}

long long push_relabel::max_flow(int s, int t) {
    for (auto &node : nodes) {
        node.h = 0;
        node.e = 0;
    }
    nodes[s].h = nodes.size();
    nodes[s].e = inf;

    for (auto &i : edges)
            i.second.f = 0;

    for (int i = 0; i < nodes[s].neighbours.size(); i++)
        push(s, nodes[s].neighbours[i]);
    nodes[s].e = 0;


    while (!q.empty()) {
        int u = q.pop();
        if (u != s && u != t)
            discharge(u);
    }

    long long max_flow = 0;
    for (int i = 0; i < nodes.size(); i++)
        max_flow += edges[{i, t}].f;
    return max_flow;
}

vector<node> push_relabel::dfs(int u){
    vector<node> ans;
    isVisit[u] = true;
    ans.push_back(nodes[u]);

    for (auto v : nodes[u].neighbours)
        if(edges[{u, nodes[v].number}].c - edges[{u, nodes[v].number}].f > 0)
            for (auto& k: dfs(nodes[v].number))
                ans.push_back(k);

    return ans;
};

vector<node> push_relabel::min_cut(int s, int t) {
    max_flow(s, t);
    fill(isVisit.begin(), isVisit.end(), 0);
    return dfs(s);
}