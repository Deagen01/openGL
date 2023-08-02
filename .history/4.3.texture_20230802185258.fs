#version 330 core
in vec3 ourColor;
in vec2 TexCoord;

out vec4 FragColor;

uniform sampler2D texture1;
uniform sampler2D texture2;

void main()
{
    // Exercises1 in Textures
    // FragColor = mix(texture(texture1, TexCoord), texture(texture2,vec2(1-TexCoord.x,TexCoord.y)), 0.5);
    FragColor = mix(texture(texture1, TexCoord), texture(texture2,TexCoord), 0.5);
}