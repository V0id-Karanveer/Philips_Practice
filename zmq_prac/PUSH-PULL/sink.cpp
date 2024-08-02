#include <zmq.hpp>
#include <bits/stdc++.h>

using namespace std;

int main(){
    zmq::context_t context(1);
    zmq::socket_t sink(context , ZMQ_PULL);
    sink.bind("tcp://*:8081");

    while(1){
        zmq::message_t msg;
        auto result = sink.recv(msg,zmq::recv_flags::none);
        if(result){
            string txt(static_cast<char *>(msg.data()),msg.size());
            cout<<txt;
        }
        else{
            cout<<"Error while receiving";
        }
    }
}