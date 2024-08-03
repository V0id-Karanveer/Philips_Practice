#include <zmq.hpp>
#include <bits/stdc++.h>

using namespace std;

int main(){
    zmq::context_t context(1);
    zmq::socket_t sink(context , ZMQ_PULL);
    zmq::socket_t killer(context , zmq::socket_type::pub);
    sink.bind("tcp://*:8081");
    killer.bind("tcp://*:5555");
    zmq::message_t msg;
    for(int i=0;i<100;i++){
        auto result = sink.recv(msg,zmq::recv_flags::none);
        if(result){
            string txt(static_cast<char *>(msg.data()),msg.size());
            cout<<txt;
        }
        else{
            cout<<"Error while receiving";
        }
    }
    string text = "KILL";
    memcpy(msg.data() , text.data() , text.size());
    killer.send(msg,zmq::send_flags::none);
}