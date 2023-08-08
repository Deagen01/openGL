#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D emmisionMap;
void main()
{
    FragColor = vec4(vec3(texture(emmisionMap,TexCoords).rgb),1.0); // set all 4 vector values to 1.0
}