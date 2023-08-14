#version 330 core
out vec4 FragColor;

struct Material {
    // sampler2D diffuse;
    // sampler2D specular;    
    float shininess;
}; 
//SpotLights
struct FlashLight {
    vec3 position;  
    vec3 direction;
    float cutOff;
    float outerCutOff;
    
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
	
    float constant;
    float linear;
    float quadratic;
};

struct PointLight{
    vec3 position;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    float constant;
    float linear;
    float quadratic;
}

struct DirLight{
    vec3 direction;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
}

in vec3 FragPos;  
in vec3 Normal;  
in vec2 TexCoords;
  
uniform vec3 viewPos;
uniform Material material;
uniform FlashLight flashLight;

uniform sampler2D diffsueMap;
uniform sampler2D specularMap;

void main()
{
    // ambient
    vec3 ambient = flashLight.ambient * texture(diffsueMap, TexCoords).rgb;
    
    // diffuse 
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(flashLight.position - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = flashLight.diffuse * diff * texture(diffsueMap, TexCoords).rgb;  
    
    // specular
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);  
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    vec3 specular = flashLight.specular * spec * texture(specularMap, TexCoords).rgb;  
    
    //spotlight (soft edge)
    float theta = dot(lightDir, normalize(-flashLight.direction)); 
    float epsilon = (flashLight.cutOff - flashLight.outerCutOff);
    float intensity = clamp((theta - flashLight.outerCutOff) / epsilon, 0.0, 1.0);
    
    diffuse*=intensity;
    specular*=intensity;
    
    // attenuation
    float distance    = length(flashLight.position - FragPos);
    float attenuation = 1.0 / (flashLight.constant + flashLight.linear * distance + flashLight.quadratic * (distance * distance));    

    ambient  *= attenuation;  
    diffuse   *= attenuation;
    specular *= attenuation;   
        
    vec3 result = ambient + diffuse + specular;
    FragColor = vec4(result, 1.0);     
} 