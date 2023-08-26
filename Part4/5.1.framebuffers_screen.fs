#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D screenTexture;

void main()
{
    vec3 col = texture(screenTexture, TexCoords).rgb;
    // FragColor = vec4(col, 1.0);
    // 1.inversion
    // FragColor = vec4(vec3(1.0 - texture(screenTexture, TexCoords)), 1.0);
    // 2.grayscale
    // float average = (col.r + col.g + col.b) / 3.0;
    // 符合人眼的灰度 对绿色感知更高
    float average = 0.2126 * col.r + 0.7152 * col.g + 0.0722 * col.b;
    FragColor = vec4(vec3(average), 1.0);
} 