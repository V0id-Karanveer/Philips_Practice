#include <zmq.hpp>
#include <bits/stdc++.h>

using namespace std;

int main(){
    zmq::context_t context (1);
    zmq::socket_t sender(context , ZMQ_PUSH);
    sender.bind("tcp://*:8080");
    for(int i=0 ; i<100;i++){
        string text = "Task " + to_string(i) +"\n";
        zmq::message_t msg(text.size());
        memcpy(msg.data() , text.data() , text.size());
        sender.send(msg , zmq::send_flags::none);
        cout<<"Sent: "+text;
        sleep(1);
    }
}