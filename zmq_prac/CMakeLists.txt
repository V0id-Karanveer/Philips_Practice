cmake_minimum_required(VERSION 3.10) 
project(0mq_prac)  

set(ZeroMQ_INCLUDE_DIR "/usr/include")
set(ZeroMQ_LIBRARIES "/usr/lib/x86_64-linux-gnu/libzmq.so")

include_directories(${ZeroMQ_INCLUDE_DIR})

add_executable(client PUB_SUB_Envelope/client.cpp)   
add_executable(server PUB_SUB_Envelope/server.cpp)  

target_link_libraries(client ${ZeroMQ_LIBRARIES})
target_link_libraries(server ${ZeroMQ_LIBRARIES})



