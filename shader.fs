#version 330

in vec2 fragPosition;
in vec2 fragTexCoord;
in vec4 fragColor;

out vec4 finalColor;

uniform vec2 screenResolution;

void main()
{  
    float screenX = gl_FragCoord.x;
    float screenY = gl_FragCoord.y;
    // float screenX = fragPosition.x;
    // float screenY = fragPosition.y;

    float realX = screenX - (screenResolution.x / 2);
    float realY = screenY - (screenResolution.y / 2);

    float radius = 50;

    if (realX * realX + realY * realY < radius * radius)
    {
        finalColor = vec4(1,1,1,1);
    }
    else 
    {
        finalColor = vec4(1,1,1,0);
    }
}