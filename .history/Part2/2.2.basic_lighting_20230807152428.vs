#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;

out vec3 FragPos;
out vec3 Normal;
out 
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

//view space calculate shading
void main()
{
    FragPos = vec3(view * model * vec4(aPos, 1.0));
    Normal = mat3(transpose(inverse(view * model))) * aNormal;    
    
    gl_Position = projection * vec4(FragPos, 1.0);
}