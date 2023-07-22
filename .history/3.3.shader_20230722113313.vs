#version 330 core
layout (location = 0) in vec3 aPos;

uniform float xOffset;

out vec4 myColor;
void main()
{
    gl_Position = vec4(aPos.x+xOffset, aPos.y, aPos.z, 1.0);
    myColor = gl_Position
}