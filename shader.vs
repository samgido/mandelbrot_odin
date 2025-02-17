#version 330

in vec3 vertexPosition;
in vec2 vertexTexCoord;
in vec4 vertexColor;

out vec2 fragTexCoord;
out vec4 fragColor;
out vec2 fragPosition;

uniform mat4 mvp;

void main()
{
    fragTexCoord = vertexTexCoord;
    fragColor = vertexColor;

    vec4 clipSpacePosition = mvp * vec4(vertexPosition, 1.0);
    fragPosition = clipSpacePosition.xy / clipSpacePosition.w;

    gl_Position = clipSpacePosition;
}