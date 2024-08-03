#include <zmq.hpp>
#include <bits/stdc++.h>
#include <csignal>

using namespace std;

int interrupted{0};

void signal_handler(int signal_value) { interrupted = 1; }

void catch_signals() {
  std::signal(SIGINT, signal_handler);
  std::signal(SIGTERM, signal_handler);
  std::signal(SIGSEGV, signal_handler);
  std::signal(SIGABRT, signal_handler);
}

int main(){
    zmq::context_t context(1);
    zmq::socket_t socket(context , zmq::socket_type::rep);
    socket.bind("tcp://*:8080");
    catch_signals();
    while(1){
        zmq::message_t msg;
        try{
            socket.recv(msg);
        }
        catch(zmq::error_t &e){
            cout<<"Interupted while getting msg";
        }
        if(interrupted){
            cout<<"Interrupted";
            break;
        }
    }
}