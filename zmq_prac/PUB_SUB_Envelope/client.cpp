#include <zmq.hpp>
#include <iostream>
#include <string>

using namespace std;

int main() {
    zmq::context_t context(1);
    zmq::socket_t subscriber(context, zmq::socket_type::sub);
    subscriber.connect("tcp://localhost:5556");
    subscriber.set(zmq::sockopt::subscribe, "B");

    while (true) {
        zmq::message_t tag_message;
        zmq::message_t update_message;
        auto res1 = subscriber.recv(tag_message, zmq::recv_flags::none);
        auto res2 = subscriber.recv(update_message, zmq::recv_flags::none);

        if (res1 && res2) {
            string tag(static_cast<char*>(tag_message.data()), tag_message.size());
            string message(static_cast<char*>(update_message.data()), update_message.size());
            cout << tag << " - " << message << endl;
        } else {
            cout << "Error while receiving the message" << endl;
        }
    }

    return 0;
}
