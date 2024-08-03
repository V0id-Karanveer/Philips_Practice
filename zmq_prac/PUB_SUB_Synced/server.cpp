#include <zmq.hpp>
#include <bits/stdc++.h>

using namespace std;

int main(){
    zmq::context_t context(1);
    zmq::socket_t publisher(context , zmq::socket_type::pub);
    zmq::socket_t rep(context , zmq::socket_type::rep);
    rep.bind("tcp://*:5555");
    publisher.bind("tcp://*:5556");
    int expected_subs = 3;
    for(int i=0;i<expected_subs;i++){
        zmq::message_t msg;
        rep.recv(msg);
        cout<<"Sub "<<i<<" connected"<<endl;
        string text = "READY";
        memcpy(msg.data() , text.data() , text.size());
        rep.send(msg);
    }
    while(1){
        string messsage_to_be_published;
        cout<<"Enter message to publish: ";
        cin>>messsage_to_be_published;
        zmq::message_t message(messsage_to_be_published.size());
        memcpy(message.data() , messsage_to_be_published.data() , messsage_to_be_published.size());
        publisher.send(message,zmq::send_flags::none);
    }
    return 0;
}