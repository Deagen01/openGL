#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D emiss;
void main()
{
    FragColor = vec4(vec3(texture(emiss,TexCoords).rgb),1.0); // set all 4 vector values to 1.0
}