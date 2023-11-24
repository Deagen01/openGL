#version 330 core
layout (location = 0) in vec2 aPos;
layout (location = 1) in vec3 aColor;
layout (location = 2) in vec2 aOffset;

out vec3 fColor;

void main()
{
    fColor = aColor;
    //记得加上小数点 不然全黑
    vec2 pos = aPos*((gl_InstanceID+5)/100.0);
    // gl_Position = vec4(aPos + aOffset, 0.0, 1.0);
    gl_Position = vec4(pos + aOffset, 0.0, 1.0);
}