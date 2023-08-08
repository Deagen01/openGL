#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D emissionMap;
void main()
{
    FragColor = vec4(1.0);
    // FragColor = texture(emissionMap,TexCoords); // set all 4 vector values to 1.0
}