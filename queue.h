#ifndef GRAPH_PROJECT_QUEUE_H
#define GRAPH_PROJECT_QUEUE_H
#include <iostream>
#include <exception>
#include <vector>


template<typename V>
class queue{
public:
    queue(){
        f = 0;
    }
    void push (V e){
        array.push_back(e);
    }
    V pop(){
        if (f == array.size())
            throw "Out";
        else
            return array[f++];
    }
    V top(){
        if (f == array.size())
            throw "Out";
        else
            return array[f];
    }
    int size(){
        return array.size() - f;
    }
private:
    std::vector<V> array;
    int f;
};

#endif
