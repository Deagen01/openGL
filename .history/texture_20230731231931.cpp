#define STB_IMAGE_IMPLEMENTATION
#include "stb_image.h"
#include <glad/gl.h>
#include <GLFW/glfw3.h>

#include <shader_s.h>

#include <iostream>
int width, height, nrChannels;
unsigned char *data = stbi_load("./pics/container.jpg", &width, &height, &nrChannels, 0); 

unsigned int texture;
glGenTextures(1, &texture); 
