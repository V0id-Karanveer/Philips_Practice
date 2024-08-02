cmake_minimum_required(VERSION 3.10) 
project(0mq_prac)  

set(ZeroMQ_INCLUDE_DIR "/usr/include")
set(ZeroMQ_LIBRARIES "/usr/lib/x86_64-linux-gnu/libzmq.so")

include_directories(${ZeroMQ_INCLUDE_DIR})

add_executable(ventilator PUSH-PULL/ventilator.cpp)  
add_executable(worker1 PUSH-PULL/worker1.cpp)
add_executable(worker2 PUSH-PULL/worker2.cpp)
add_executable(sink PUSH-PULL/sink.cpp)

target_link_libraries(ventilator ${ZeroMQ_LIBRARIES})
target_link_libraries(worker1 ${ZeroMQ_LIBRARIES})
target_link_libraries(worker2 ${ZeroMQ_LIBRARIES})
target_link_libraries(sink ${ZeroMQ_LIBRARIES})
