Shader "Custom/GradientColor"
{
    Properties
    {
    	
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 pos : TEXCOORD0;
            };

            half _MinC;
            half _MaxC;
            fixed _Mode;	//1 = Y, 2 = X, 3 = Z, 4 = center
            fixed _Weight;	//10 = true, 0 = false
            fixed4 _ColorMin;
            fixed4 _ColorMax;
            half3 _Center;
            
            

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.pos = v.vertex.xyz;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
            	_Mode = _Mode + _Weight;
                // Normalize Y between 0 and 1
                fixed normalizedC = 0.0;
                half3 center = _Center.xyz;
                if (_Mode == 2.0)
                	normalizedC = saturate(abs(2*abs(i.pos.x - _Center.x) / (_MaxC - _MinC)));
                else if (_Mode == 3.0)
                	normalizedC = saturate(abs(2*abs(i.pos.z - _Center.z) / (_MaxC - _MinC)));
                else if (_Mode == 4.0)
                	normalizedC = saturate(distance(_Center, i.pos) / _MaxC);
                else if (_Mode == 11.0)
                	normalizedC = saturate(abs(i.pos.y - _Center.y) / _MaxC);
                else if (_Mode == 12.0)
                	normalizedC = saturate(abs(i.pos.x - _Center.x) / _MaxC);
                else if (_Mode == 13.0)
                	normalizedC = saturate(abs(i.pos.z - _Center.z) / _MaxC);
                else if (_Mode == 14.0)
                	normalizedC = saturate(distance(_Center, i.pos) / _MaxC);
                else
                	normalizedC = saturate(abs(2*abs(i.pos.y - _Center.y) / (_MaxC - _MinC)));
                
                // Blend color between darker and lighter version along Y axis
                fixed4 col = lerp(_ColorMax, _ColorMin, normalizedC);
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}


