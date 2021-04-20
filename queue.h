#ifndef GRAPH_PROJECT_QUEUE_H
#define GRAPH_PROJECT_QUEUE_H


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

#endif
