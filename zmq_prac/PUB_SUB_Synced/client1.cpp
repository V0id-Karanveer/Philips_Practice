#include <zmq.hpp>
#include <bits/stdc++.h>

using namespace std;

int main(){
    zmq::context_t context(1);
    zmq::socket_t subscriber(context , zmq::socket_type::sub);
    zmq::socket_t req(context , zmq::socket_type::req);
    req.connect("tcp://localhost:5555");
    zmq::message_t msg1;
    req.send(msg1);
    req.recv(msg1);
    subscriber.connect("tcp://localhost:5556");
    subscriber.set(zmq::sockopt::subscribe, "");
    while(1){
        zmq::message_t message;
        auto res = subscriber.recv(message , zmq::recv_flags::none);
        if(res){
            string update_message(static_cast<char *>(message.data()) , message.size());
            cout<< "Update Received: " + update_message <<endl;
        }
        else{
            cout<<"Error while receiving the message";
        }
    }
}