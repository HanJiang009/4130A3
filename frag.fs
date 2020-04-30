#version 300 es

precision mediump float;
uniform vec4 light_ambient;
uniform vec4 light_diffuse;
uniform vec4 light_specular;
uniform vec4 material_ambient;
uniform vec4 material_diffuse;
uniform vec4 material_emissive;
uniform float u_shinniness;
uniform vec3 u_eye_position;
uniform vec3 u_light_Dir;

in vec3 v_normal;
flat in int instance_id;

out vec4 fragColor;

vec3 hsv2rgb(vec3 c)
{
    vec4 K = vec4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
    vec3 p = abs(fract(c.xxx + K.xyz) * 6.0 - K.www);
    return c.z * mix(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
}

void main(){
    
    float instanceID = float(instance_id);
    vec3 N = normalize(v_normal);
    vec3 light_Dir = u_light_Dir;
    light_Dir = normalize(light_Dir);
    float dotValue = max(0.0, dot(N, light_Dir));
	
	float attenuation = 1.0;
    vec3 H = normalize(light_Dir + normalize(u_eye_position));
    float spacular = pow(max(dot(N, H), 0.0), u_shinniness);
	
	// change shinniness of the fifth row(from bottom up)
    if(instance_id == 28) spacular = pow(max(dot(N, H), 0.0), u_shinniness * 0.1);
    if(instance_id == 29) spacular = pow(max(dot(N, H), 0.0), u_shinniness * 0.2);
    if(instance_id == 30) spacular = pow(max(dot(N, H), 0.0), u_shinniness * 0.5);
    if(instance_id == 31) spacular = pow(max(dot(N, H), 0.0), u_shinniness * 1.0);
    if(instance_id == 32) spacular = pow(max(dot(N, H), 0.0), u_shinniness * 2.0);
    if(instance_id == 33) spacular = pow(max(dot(N, H), 0.0), u_shinniness * 5.0);
    if(instance_id == 34) spacular = pow(max(dot(N, H), 0.0), u_shinniness * 10.0);

    float diffuse = dotValue * attenuation;
    vec4 surface_color = vec4(1,1,1,1);
    
    // vary the emissive, ambient, diffuse and specular colours in the first four rows of the grid for the first 4 rows.(from bottom up)
    for(int i=0; i<7; i++){
        vec4 color_scale = vec4(1,1,1,1);
        if(i == 0){
            color_scale = vec4(hsv2rgb(vec3(0.5, 1.0, 1.0)), 1);
            if(instance_id == 0)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse + spacular * light_specular + material_emissive;
            if(instance_id == 7)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse + spacular * light_specular * color_scale + material_emissive;
            if(instance_id == 14)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse * color_scale + spacular * light_specular + material_emissive;
            if(instance_id == 21)
                surface_color *= material_ambient * light_ambient * color_scale + material_diffuse * diffuse + spacular * light_specular + material_emissive;
        } 
        if(i == 1) {
            color_scale = vec4(hsv2rgb(vec3(0.9, 1.0, 1.0)), 1);
            if(instance_id == 1)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse + spacular * light_specular + material_emissive;
            if(instance_id == 8)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse + spacular * light_specular * color_scale + material_emissive;
            if(instance_id == 15)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse * color_scale + spacular * light_specular + material_emissive;
            if(instance_id == 22)
                surface_color *= material_ambient * light_ambient * color_scale + material_diffuse * diffuse + spacular * light_specular + material_emissive;
        }
        if(i == 2) {
            color_scale = vec4(hsv2rgb(vec3(0.95, 1.0, 1.0)), 1);
            if(instance_id == 2)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse + spacular * light_specular + material_emissive;
            if(instance_id == 9)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse + spacular * light_specular * color_scale + material_emissive;
            if(instance_id == 16)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse * color_scale + spacular * light_specular + material_emissive;
            if(instance_id == 23)
                surface_color *= material_ambient * light_ambient * color_scale + material_diffuse * diffuse + spacular * light_specular + material_emissive;
        }
        if(i == 3) {
            color_scale = vec4(hsv2rgb(vec3(1.0, 1.0, 1.0)), 1);
            if(instance_id == 3)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse + spacular * light_specular + material_emissive;
            if(instance_id == 10)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse + spacular * light_specular * color_scale + material_emissive;
            if(instance_id == 17)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse * color_scale + spacular * light_specular + material_emissive;
            if(instance_id == 24)
                surface_color *= material_ambient * light_ambient * color_scale + material_diffuse * diffuse + spacular * light_specular + material_emissive;
        }
        if(i == 4) {
            color_scale = vec4(hsv2rgb(vec3(1.05, 1.0, 1.0)), 1);
            if(instance_id == 4)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse + spacular * light_specular + material_emissive;
            if(instance_id == 11)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse + spacular * light_specular * color_scale + material_emissive;
            if(instance_id == 18)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse * color_scale + spacular * light_specular + material_emissive;
            if(instance_id == 25)
                surface_color *= material_ambient * light_ambient * color_scale + material_diffuse * diffuse + spacular * light_specular + material_emissive;
        }
        if(i == 5) {
            color_scale = vec4(hsv2rgb(vec3(1.1, 1.0, 1.0)), 1);
            if(instance_id == 5)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse + spacular * light_specular + material_emissive;
            if(instance_id == 12)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse + spacular * light_specular * color_scale + material_emissive;
            if(instance_id == 19)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse * color_scale + spacular * light_specular + material_emissive;
            if(instance_id == 26)
                surface_color *= material_ambient * light_ambient * color_scale + material_diffuse * diffuse + spacular * light_specular + material_emissive;
        }
        if(i == 6) {
            color_scale = vec4(hsv2rgb(vec3(1.5, 1.0, 1.0)), 1);
            if(instance_id == 6)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse + spacular * light_specular + material_emissive;
            if(instance_id == 13)
                surface_color *= material_ambient * light_ambient + material_diffuse * diffuse + spacular * light_specular * color_scale + material_emissive;
            if(instance_id == 20)
                surface_color *= material_ambient * light_ambient+ material_diffuse * diffuse * color_scale + spacular * light_specular + material_emissive;
            if(instance_id == 27)
                surface_color *= material_ambient * light_ambient * color_scale + material_diffuse * diffuse + spacular * light_specular + material_emissive;
        }
    }

    vec4 light_reflect = light_ambient + light_diffuse * diffuse; //Combine

    fragColor = surface_color + light_reflect; // Combine and out put
}