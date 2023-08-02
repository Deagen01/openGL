#version 330 core

uniform sampler2D texture1;
uniform sampler2D texture2;
in vec3 ourColor;
in vec2 TexCoord;
void main()
{
    FragColor = mix(texture(texture1, TexCoord), texture(texture2, TexCoord), 0.2);
}