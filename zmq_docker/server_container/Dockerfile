FROM gcc:latest

WORKDIR /usr/src/app

COPY . .

RUN apt-get update
RUN apt-get install libzmq3-dev -y
RUN g++ -o server server.cpp -lzmq


CMD ["sh", "-c", "while true; do sleep 3600; done"]

