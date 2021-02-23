sampler uImage0 : register(s0); // The texture that you are currently drawing.
sampler uImage1 : register(s1); // A secondary texture that you can use for various purposes. This is usually a noise map.
float3 uColor;
float3 uSecondaryColor;
float uOpacity;
float uSaturation;
float uRotation;
float uTime;
float4 uSourceRect; // The position and size of the currently drawn frame.
float2 uWorldPosition;
float uDirection;
float3 uLightSource; // Used for reflective dyes.
float2 uImageSize0;
float2 uImageSize1;
float2 uTargetPosition;
float2 uScreenPosition;
float2 uScreenResolution;
float PI;
float uProgress;

float4 Shockwave(float4 position : SV_POSITION, float2 coords : TEXCOORD0) : COLOR0
{
    float2 targetCoords = (uTargetPosition - uScreenPosition) / uScreenResolution;
    float2 centreCoords = (coords - targetCoords) * (uScreenResolution / uScreenResolution.y);
    float dotField = dot(centreCoords, centreCoords);
    float ripple = dotField * uColor.y * PI - uProgress * uColor.z;

    if (ripple < 0 && ripple > uColor.x * -2 * PI)
    {
        ripple = saturate(sin(ripple));
    }
    else
    {
        ripple = 0;
    }

    float2 sampleCoords = coords + ((ripple * uOpacity / uScreenResolution) * centreCoords);

    return tex2D(uImage0, sampleCoords);
}

technique Technique1
{
    pass Shockwave
    {
        PixelShader = compile ps_2_0 Shockwave();
    }
}