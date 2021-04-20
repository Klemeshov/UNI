//
// Created by dima- on 20.04.2021.
//

#include <iostream>
#include <vector>

template<typename V>
class queue{
public:
    queue(){
        f = 0;
    }
    void push (V e){
        this->array.push_back(e);
    }
    V pop(){
        if (this->f == this->array.size())
            return nullptr;
        else
            return this->array[this->f++];
    }
    V top(){
        if (this->f == this->array.size())
            return nullptr;
        else
            return this->array[this->f];
    }
private:
    std::vector<V> array;
    int f;
};
