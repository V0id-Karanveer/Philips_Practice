#include <zmq.hpp>
#include <bits/stdc++.h>

using namespace std;

int main(){
    zmq::context_t context(1);
    zmq::socket_t sock1(context , ZMQ_PULL);
    zmq::socket_t sock2(context , zmq::socket_type::sub);
    sock1.connect("tcp://localhost:8080");
    sock2.connect("tcp://localhost:5556");
    sock2.setsockopt(ZMQ_SUBSCRIBE,"",0);

    zmq::pollitem_t poll_items[] = {
        {static_cast<void *>(sock1) , 0 , ZMQ_POLLIN , 0},
        {static_cast<void *>(sock2) , 0 , ZMQ_POLLIN , 0},
    };
    while(1){
        zmq::poll(&poll_items[0],2,-1);
        zmq::message_t msg;

        if(poll_items[0].revents && ZMQ_POLLIN){
            sock1.recv(&msg);
            string msg_text(static_cast<char *>(msg.data()),msg.size());
            cout<<"Received: " + msg_text;
        }

        if(poll_items[1].revents && ZMQ_POLLIN){
            sock2.recv(&msg);
            string msg_text(static_cast<char *>(msg.data()),msg.size());
            cout<<"Received: " + msg_text;
        }
    }
}