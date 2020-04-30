#version 300 es
uniform mat4 u_mvp_matrix;
in vec4 a_vertex;
in vec3 a_normal;
in mat4 a_model_matrix;
out vec3 v_normal;
flat out int instance_id;

void main(){
    v_normal = mat3(a_model_matrix) * a_normal;
    gl_Position = u_mvp_matrix * a_model_matrix * a_vertex;
    instance_id = gl_InstanceID; // pass the InstanceID
}