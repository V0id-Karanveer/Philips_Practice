#include <zmq.hpp>
#include <bits/stdc++.h>

using namespace std;

int main() {
    zmq::context_t context(1);
    zmq::socket_t publisher(context, zmq::socket_type::pub);
    publisher.bind("tcp://*:5556");

    while (true) {
        string tag = "B";
        string message_to_be_published = "Received this";

        zmq::message_t tag_message(tag.size());
        memcpy(tag_message.data(), tag.data(), tag.size());
        publisher.send(tag_message, zmq::send_flags::sndmore);

        zmq::message_t message(message_to_be_published.size());
        memcpy(message.data(), message_to_be_published.data(), message_to_be_published.size());
        publisher.send(message, zmq::send_flags::none);

        tag = "A";
        message_to_be_published = "Should not Receive this";

        zmq::message_t tag_message2(tag.size());
        memcpy(tag_message2.data(), tag.data(), tag.size());
        publisher.send(tag_message2, zmq::send_flags::sndmore);

        zmq::message_t message2(message_to_be_published.size());
        memcpy(message2.data(), message_to_be_published.data(), message_to_be_published.size());
        publisher.send(message2, zmq::send_flags::none);

        this_thread::sleep_for(chrono::milliseconds(100));
    }

    return 0;
}
