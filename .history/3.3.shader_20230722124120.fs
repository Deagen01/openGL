#version 330 core
in vec4 myColor;
out vec4 FragColor;

void main()
{
    FragColor = vec4(myColor, 1.0f);
    // FragColor = myColor;
} 