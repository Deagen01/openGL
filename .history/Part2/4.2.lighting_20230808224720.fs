#version 330 core 

struct Material {
    // sampler2D diffuse;
    // sampler2D specular;
    // sampler2D emission;
    float     shininess;
};

struct Light {
    vec3 position;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

in vec3 FragPos;
in vec3 Normal;
in vec2 TexCoords;

out vec4 color;

uniform sampler2D diffuseMap;
uniform sampler2D specularMap;
uniform sampler2D emissionMap;

uniform vec3 viewPos;
uniform Material material;
uniform Light light;
uniform float time;

void main()
{
    
    
    /*Ambient */
    vec3 ambient = light.ambient * vec3(texture(diffuseMap, TexCoords));   /*use specular texture */
    
    /*Diffuse */
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(light.position - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * diff * vec3(texture(diffuseMap, TexCoords));   /*use specular texture */
    
    /*Specular */
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    vec3 specular = light.specular * spec * vec3(texture(specularMap, TexCoords));    /*use specular texture */
    
    
    /*Emission */
    vec3 emission = vec3(0.0);
    if (texture(specularMap, TexCoords).r == 0.0)   /*rough check for blackbox inside spec texture */
    {
        /*apply emission texture */
        emission = texture(em, TexCoords).rgb;
        
        /*some extra fun stuff with "time uniform" */
        emission = texture(material.emission, TexCoords + vec2(0.0,time)).rgb;   /*moving */
        emission = emission * (sin(time) * 0.5 + 0.5) * 2.0;                     /*fading */
    }
    
   /*output */
    color = vec4(ambient + diffuse + specular + emission, 1.0f);
}