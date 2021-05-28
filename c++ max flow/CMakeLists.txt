cmake_minimum_required(VERSION 3.17)
project(Graph_Project)

set(CMAKE_CXX_STANDARD 14)



#set(CMAKE_MODULE_PATH "${CMAKE_SOURCE_DIR}/cmake/Modules" ${CMAKE_MODULE_PATH})


find_package(SFML COMPONENTS graphics REQUIRED)

include_directories(${SFML_INCLUDE_DIR})
add_executable(Graph_Project main.cpp queue.h push_relabel.h push_relabel.cpp )

target_link_libraries(Graph_Project sfml-graphics)
