#ifndef GRAPH_PROJECT_QUEUE_H
#define GRAPH_PROJECT_QUEUE_H
#include <iostream>
#include <exception>
#include <vector>
#include <cassert>


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
        assert(f != array.size());
        return array[f++];
    }
    V top(){
        assert(f != array.size());
        return array[f];
    }
    int size(){
        return array.size() - f;
    }
    bool empty(){
        return size() == 0;
    }
private:
    std::vector<V> array;
    int f;
};

#endif
