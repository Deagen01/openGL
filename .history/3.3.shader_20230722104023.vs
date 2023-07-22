#version 330 core
layout (location = 0) in vec3 aPos;

Uniform float xOffset;
void main()
{
    gl_Position = vec4(aPos.x+xoffset, aPos.y, aPos.z, 1.0);
}