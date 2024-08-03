#include <zmq.hpp>
#include <bits/stdc++.h>

using namespace std;

void worker_routine(zmq::context_t& ctx) {
    try {
        zmq::socket_t sock(ctx, ZMQ_REP);
        sock.connect("inproc://workers");
        while (true) {
            zmq::message_t msg;
            sock.recv(msg, zmq::recv_flags::none);
            string text(static_cast<char*>(msg.data()), msg.size());
            cout << "Received: " << text;
            this_thread::sleep_for(chrono::seconds(1));
            string rep = "Done-" + text;
            zmq::message_t reply(rep.size());
            memcpy(reply.data(), rep.data(), rep.size());
            sock.send(reply, zmq::send_flags::none);
        }
    } catch (const zmq::error_t& e) {
        cerr << "Worker error: " << e.what() << endl;
    }
}

int main() {
    try {
        zmq::context_t ctx(1);
        zmq::socket_t client(ctx, zmq::socket_type::router);
        client.bind("tcp://*:5555");

        zmq::socket_t workers(ctx, zmq::socket_type::dealer);
        workers.bind("inproc://workers");

        vector<thread> worker_threads;
        for (int i = 0; i < 5; i++) {
            worker_threads.emplace_back([&ctx] { worker_routine(ctx); });
        }

        zmq::proxy(static_cast<void *>(client), static_cast<void *>(workers), nullptr);

        for (auto& thread : worker_threads) {
            thread.join();
        }
    } catch (const zmq::error_t& e) {
        cerr << "Error: " << e.what() << endl;
    }

    return 0;
}
