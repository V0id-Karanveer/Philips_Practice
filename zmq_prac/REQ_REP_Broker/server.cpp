#include <zmq.hpp>
#include <string>
#include <iostream>
#include <unistd.h>

using namespace std;

int main(){
    zmq::context_t context (1);
    zmq::socket_t socket (context, zmq::socket_type::rep);
    socket.connect("tcp://localhost:5560");
    cout << "Starting server..." <<  endl;

    while (true) {
        zmq::message_t request;
        
        auto result = socket.recv(request, zmq::recv_flags::none);
        string message (static_cast<char*>(request.data()));
        if(result){
            cout << "Client: " + message <<endl;
        }
        else{
            cout<<"Message receieved faced an error";
        }
        string reply_text;
        cout << "Server: ";
        cin >> reply_text;
        zmq::message_t reply (reply_text.size());
        memcpy (reply.data(), reply_text.data(), reply_text.size());
        socket.send (reply, zmq::send_flags::none);
    }
    return 0;
}
