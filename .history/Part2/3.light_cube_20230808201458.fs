#version 330 core
out vec4 FragColor;

uniform sampler2D lightTexture;
void main()
{
    FragColor = texture(li); // set all 4 vector values to 1.0
}