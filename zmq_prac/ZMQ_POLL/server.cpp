#include <zmq.hpp>
#include <bits/stdc++.h>

using namespace std;

int main(){
    zmq::context_t context(1);
    zmq::socket_t publisher(context , zmq::socket_type::pub);
    publisher.bind("tcp://*:5556");
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