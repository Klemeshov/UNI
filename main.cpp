#include <iostream>
#include <vector>
#include <fstream>
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

    for (int i =0; i < m; i++){
        int f, s, c;
        in >> f>>s>>c;
        f--;s--;
//        cout << f<<' '<<s<<' '<<c<<endl;
        edges[f][s] = edge{c,0};
        nodes[f].neighbours.push_back(s);
    }

    push_relabel a(nodes, edges);

    cout<< a.max_flow(0,n-1);
    in.close();
    return 0;
}
