#include <zmq.hpp>
#include <string>
#include <iostream>
#include <unistd.h>

using namespace std;

int main () {
    zmq::context_t context (1);
    zmq::socket_t socket (context, zmq::socket_type::req);
    socket.connect("tcp://172.18.0.1:8081");

    while (true) {
        string req_message;
        cout << "Client: ";
        cin >> req_message;

        zmq::message_t request(req_message.size());
        memcpy(request.data(), req_message.data(), req_message.size());
        socket.send(request, zmq::send_flags::none);

        zmq::message_t reply;
        auto result = socket.recv(reply, zmq::recv_flags::none);
        string reply_message(static_cast<char*>(reply.data()), reply.size());
        if (result) {
            cout << "Server: " + reply_message << endl;
        } else {
            cout << "Error in the message" << endl;
        }
    }
    return 0;
}
