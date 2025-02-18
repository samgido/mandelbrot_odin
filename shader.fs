#version 330

in vec2 fragPosition;
in vec2 fragTexCoord;
in vec4 fragColor;

out vec4 finalColor;

uniform vec2 screenResolution;

void main()
{  
    /* this works but I don't get it 
    vec2 uv = fragPosition.xy;

    finalColor = vec4(0.);

    uv.x -= .5;

    vec2 z = vec2(0.);
    for (; dot(z, z) + finalColor.x < 7.; finalColor += 0.005)
        z = mat2(z, -z.y, z) * z + uv;
    /*
}