#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aColor;
uniform float xOffset;

out vec4 myColor;
void main()
{
    gl_Position = vec4(aPos.x+xOffset, aPos.y, aPos.z, 1.0);
    myColor = aColor;
    // myColor = gl_Position;
}