FROM gcc:latest

WORKDIR /usr/src/app

COPY . .

RUN apt-get update
RUN apt-get install libzmq3-dev -y
RUN g++ -o client client.cpp -lzmq

#CMD [ "./client" ]
CMD ["sh", "-c", "while true; do sleep 3600; done"]


