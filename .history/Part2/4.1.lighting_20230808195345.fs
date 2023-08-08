#version 330 core
out vec4 FragColor;

struct Material {
    // int diffuse;
    // vec3 specular;    
    float shininess;
}; 

struct Light {
    vec3 position;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};
in vec2 TexCoords;
in vec3 FragPos;  
in vec3 Normal;  
  
uniform vec3 viewPos;
uniform Material material;
uniform Light light;

uniform sampler2D diffuseMap;
uniform sampler2D specularMap;
void main()
{
    // vec3 diffuse_map_value = vec3(texture(material.diffuse, TexCoords).rgb);
    vec3 diffuse_map_value = vec3(texture(diffuseMap, TexCoords).rgb);
    vec3 specular_map_value = vec3(texture(specularMap, TexCoords).rgb);
    // diffuse_map_value = vec3(texColor.xyz);
    // ambient
    vec3 ambient = light.ambient * diffuse_map_value;
    // diffuse 
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(light.position - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * (diff * diffuse_map_value);
    
    // specular
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);  
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    // vec3 specular = light.specular * spec * specular_map_value;
    vec3 specular = light.specular * spec * (vec3(1.0,1.0,1.0)-specular_map_value);  
        
    vec3 result = ambient + diffuse + specular;
    FragColor = vec4(result, 1.0);
} 