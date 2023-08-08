#version 330 core
out vec4 FragColor;

in vec2 texCoords;

uniform sampler2D lightTexture;
void main()
{
    FragColor = vec3(texture(lightTexture,texCoords).rgb); // set all 4 vector values to 1.0
}