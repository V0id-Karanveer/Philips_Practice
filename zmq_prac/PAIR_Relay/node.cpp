#include <zmq.hpp>
#include <bits/stdc++.h>

using namespace std;

void step1(zmq::context_t& ctx){
    zmq::socket_t relay(ctx , zmq::socket_type::pair);
    relay.connect("inproc://step2");
    cout<<"Step 1 ready , signalling Step 2"<<endl;
    zmq::message_t msg("READY");
    relay.send(msg);
}

void step2(zmq::context_t& ctx){
    zmq::socket_t relay(ctx , zmq::socket_type::pair);
    relay.bind("inproc://step2");
    thread thd(step1 , ref(ctx));
    zmq::message_t msg;
    relay.recv(msg);
    zmq::socket_t relay2(ctx , zmq::socket_type::pair);
    relay2.connect("inproc://step3");
    cout<<"Step 2 completed ,signalling Step 3"<<endl;
    relay2.send(msg);
    thd.join();
}

int main(){
    zmq::context_t ctx(1);
    zmq::socket_t recv(ctx , zmq::socket_type::pair);
    recv.bind("inproc://step3");
    thread thd(step2 , ref(ctx));
    zmq::message_t msg;
    recv.recv(msg);
    cout<<"Succesful , Step 3 completed"<<endl;
    thd.join();
}