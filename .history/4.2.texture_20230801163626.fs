#version 330 core
in vec3 ourColor;
in vec2 TexCoord;

out vec4 FragColor;

uniform sampler2D texture1;
// uniform sampler2D texture2;

void main()
{
    FragColor = mix(texture(texture1, TexCoord), vec4(ourColor,1.0), 1.0);
}