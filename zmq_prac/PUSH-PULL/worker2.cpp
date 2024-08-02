#include <zmq.hpp>
#include <bits/stdc++.h>

using namespace std;

int main(){
    zmq::context_t context(1);
    zmq::socket_t worker(context , ZMQ_PULL);
    worker.connect("udp://localhost:8080");
    zmq::socket_t sink(context , ZMQ_PUSH);
    sink.connect("udp://localhost:8081");
    while(1){
        zmq::message_t msg;
        auto result = worker.recv(msg , zmq::recv_flags::none);
        string text(static_cast<char *>(msg.data()) , msg.size());
        cout<<"Receieved: "+text;
        usleep(5000);

        string res_text = "Done: " + text;
        zmq::message_t res(res_text.size());
        memcpy(res.data() , res_text.data() , res_text.size());

        sink.send(res,zmq::send_flags::none);
    }
}