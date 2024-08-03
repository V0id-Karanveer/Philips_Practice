#include <zmq.hpp>
#include <bits/stdc++.h>

using namespace  std;

int main(){
    zmq::context_t context(1);
    zmq::socket_t frontend(context , ZMQ_SUB);
    frontend.connect("tcp://localhost:5556");
    frontend.set(zmq::sockopt::subscribe, "");
    zmq::socket_t backend(context , ZMQ_PUB);
    backend.bind("tcp://*:5555");
    zmq::proxy(static_cast<void *>(frontend) , static_cast<void *>(backend) , nullptr);
}
