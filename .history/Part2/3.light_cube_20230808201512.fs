#version 330 core
out vec4 FragColor;

in  vec2 texCoords;

uniform sampler2D lightTexture;
void main()
{
    FragColor = texture(lightTexture,texCoords); // set all 4 vector values to 1.0
}