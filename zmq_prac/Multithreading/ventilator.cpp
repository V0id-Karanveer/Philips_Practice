#include <zmq.hpp>
#include <bits/stdc++.h>

using namespace std;

int main(){
    zmq::context_t context (1);
    zmq::socket_t sock(context , zmq::socket_type::req);
    sock.connect("tcp://localhost:5555");
    for(int i=0 ; i<100;i++){
        string text = "Task " + to_string(i) +"\n";
        zmq::message_t msg(text.size());
        memcpy(msg.data() , text.data() , text.size());
        sock.send(msg , zmq::send_flags::none);
        cout<<"Sent: "+text;
        sock.recv(msg);
        string reply(static_cast<char *>(msg.data()),msg.size());
        cout<<"Received: "+reply;
    }
}