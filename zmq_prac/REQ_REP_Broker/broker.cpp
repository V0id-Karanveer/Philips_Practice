#include <zmq.hpp>
#include <bits/stdc++.h>

using namespace std;

int main(){
    zmq::context_t context(1);
    zmq::socket_t frontend(context, ZMQ_ROUTER);
    frontend.bind("tcp://*:5559");
    zmq::socket_t backend(context,ZMQ_DEALER);
    backend.bind("tcp://*:5560");

    zmq::proxy(static_cast<void *>(frontend) , static_cast<void *>(backend) , nullptr);
}