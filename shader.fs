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

    int max_iter = 700;
    int iter;
    for (iter = 0; iter < max_iter; iter += 1)
    {
        float tx = z.x;
        float ty = z.y;

        // 'square' the complex number z
        z.x = tx*tx - ty*ty;
        z.y = 2 * tx * ty;

        // add onto it the constant c, which is, in this case, the position of the pixel we are calculating for
        z.x += uv.x;
        z.y += uv.y;
        
        // If the distance from the origin is less than 2
        if (z.x * z.x + z.y * z.y > 6.0)
        {
            in_mandelbrot = false;
            break;
        }
    }

    if (in_mandelbrot)
        finalColor = vec4(0,0,0,1);
    else
        finalColor = vec4(50 * (float(iter) / float(max_iter)),0,0,1);
}