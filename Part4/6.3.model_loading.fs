#version 330 core
out vec4 FragColor;
//SpotLights
struct Light {
    vec3 position;  

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
	
    // float constant;
    float linear;
    float quadratic;
};

in vec2 TexCoords;
in vec3 Normal;
in vec3 FragPos;

uniform sampler2D texture_diffuse1;
uniform sampler2D texture_specular1;
uniform sampler2D texture_normal1;
uniform sampler2D texture_height1;

uniform samplerCube skybox;
uniform vec3 CameraPos;
uniform Light light;
uniform float shininess;
void main()
{       
    //光源方向
    vec3 lightDir = normalize(light.position - FragPos);
    //观察方向
    vec3 viewDir = normalize(CameraPos - FragPos);
    //ambient
    vec3 ambient = light.ambient * texture(texture_diffuse1,TexCoords).rgb;
    //diffuse
    float diff = max(dot(lightDir,normalize(Normal)),0.0);
    vec3 diffuse = light.diffuse * diff * texture(texture_diffuse1,TexCoords).rgb;
    //specular
    float spec= pow(max(dot(viewDir,reflect(-lightDir,normalize(Normal))),0.0),shininess);
    vec3 specular =spec* light.specular * texture(texture_specular1,TexCoords).rgb;
    //reflecction
    vec3 reflectDir = reflect(-lightDir,normalize(Normal));
    vec3 reflect = texture(texture_height1,TexCoords).rgb * texture(skybox,reflectDir).rgb;
    // vec3 skybox = texture(skybox,reflectDir).rgb;
    vec3 color = ambient + diffuse + specular +reflect;
    FragColor = vec4(color,1.0);
}