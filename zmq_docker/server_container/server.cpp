#include <zmq.hpp>
#include <string>
#include <iostream>
#include <unistd.h>

using namespace std;

int main() {
    zmq::context_t context (2);
    zmq::socket_t socket (context, zmq::socket_type::rep);
    socket.bind("tcp://*:8080");
    cout << "Starting server" << endl;

    while (true) {
        zmq::message_t request;

        auto result = socket.recv(request, zmq::recv_flags::none);
        string message(static_cast<char*>(request.data()), request.size());
        if (result) {
            cout << "Client: " + message << endl;
        } else {
            cout << "Message received faced an error" << endl;
        }
        string reply_text;
        cout << "Server: ";
        cin >> reply_text;
        zmq::message_t reply(reply_text.size());
        memcpy(reply.data(), reply_text.data(), reply_text.size());
        cout << "Sending reply: " << reply_text << endl;
        socket.send(reply, zmq::send_flags::none);
    }
    return 0;
}
