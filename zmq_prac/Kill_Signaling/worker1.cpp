#include <zmq.hpp>
#include <bits/stdc++.h>

using namespace std;

int main(){
    zmq::context_t context(1);
    zmq::socket_t worker(context , ZMQ_PULL);
    worker.connect("tcp://localhost:8080");
    zmq::socket_t sink(context , ZMQ_PUSH);
    sink.connect("tcp://localhost:8081");
    zmq::socket_t kill_switch(context , zmq::socket_type::sub);
    kill_switch.connect("tcp://localhost:5555");
    kill_switch.setsockopt(ZMQ_SUBSCRIBE, "", 0);

    zmq::pollitem_t items[] = {
        {worker , 0 , ZMQ_POLLIN , 0},
        {kill_switch , 0 , ZMQ_POLLIN , 0}
    };

    while(1){
        zmq::poll(&items[0] , 2 , -1);

        if(items[0].revents && ZMQ_POLLIN){
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
        
        if(items[1].revents && ZMQ_POLLIN){
            zmq::message_t msg;
            kill_switch.recv(msg, zmq::recv_flags::none);
            string text(static_cast<char*>(msg.data()), msg.size());
            cout<<"Received Kill Command"<<endl;
            break;
        }
    }
}