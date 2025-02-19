#version 330

in vec2 fragPosition;
in vec2 fragTexCoord;
in vec4 fragColor;

out vec4 finalColor;

uniform vec2 screenResolution;

void main()
{  
    vec2 uv = fragPosition.xy * 2;
    uv.x -= .5;

    vec2 z = vec2(0.);

    bool in_mandelbrot = true;

    int max_iter = 1000;
    int iter = 0;
    while (iter < max_iter)
    {
        float tx = z.x;
        float ty = z.y;

        z.x = tx*tx - ty*ty;
        z.y = 2 * tx * ty;

        z.x += uv.x;
        z.y += uv.y;
        
        if (z.x * z.x + z.y * z.y > 4.0)
        {
            in_mandelbrot = false;
            break;
        }

        iter += 1;
    }

    if (in_mandelbrot)
        finalColor = vec4(1,1,1,1);
    else
        finalColor = vec4(0,0,0,1);
}