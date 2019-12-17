Shader "TShader/OutLightling"
{
	Properties
	{
		_MainTex("Texture(RGB)", 2D) = "grey"  {}
		_Color("Color", color) = (0, 0, 0, 1)
		_AtmoColor("Atmosphere", color) = (0, 0.4, 1.0, 1)
		_Size("Size", Float) = 0.1
		_OutLightPow("Falloff",Float) = 5
		_OutLightStrength("Transparency", Float) = 15
	}

	SubShader
	{
		pass
		{
			Name "PlaneBase"
			Tags{"LightMode" = "Always"}
			Cull Back
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
				uniform	sampler2D _MainTex;
				uniform float4 _MainTex_ST;
				uniform float4 _Color;
				uniform float4 _AtmoColor;
				uniform float _Size;
				uniform float _OutLightPow;
				uniform float _OutLightStrength;
			
			struct vertexOutput
			{
				float4 pos:SV_POSITION;
				float3 normal:TEXCOORD;
				float3 worldvertpos:TEXCOORD1;
				float2 texcoord:TEXCOORD2;
			};

			vertexOutput vert(appdata_base v)
			{
				vertexOutput o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.normal = v.normal;
				o.worldvertpos = mul(unity_ObjectToWorld, v.vertex).xyz;
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			
			float4 frag(vertexOutput i) :COLOR
            {   
                float4 color = tex2D(_MainTex, i.texcoord);
                return color*_Color;
            }

			ENDCG
		}

		pass
		{
			Name "AtmosphereBase"
			Tags{"LightMode" = "Always"}
			Cull Front
			Blend SrcAlpha One

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
				uniform float4 _Color;
	            uniform float4 _AtmoColor;
		        uniform float _Size;
			    uniform float _OutLightPow;
				uniform float _OutLightStrength;

			struct vertexOutput
            {
                float4 pos:SV_POSITION;
                float3 normal:TEXCOORD0;
                float3 worldvertpos:TEXCOORD1;
            };
			
			vertexOutput vert(appdata_base v)
			{
				vertexOutput o;
                v.vertex.xyz += v.normal*_Size;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                o.worldvertpos = mul(unity_ObjectToWorld, v.vertex);
                return o;
			}

			float4 frag(vertexOutput i):COLOR
            {
                i.normal = normalize(i.normal);
                float3 viewdir = normalize(i.worldvertpos.xyz - _WorldSpaceCameraPos.xyz);// normalize(i.worldvertpos - _WorldSpaceCamerePos);
                float4 color = _AtmoColor;
                color.a = pow(saturate(dot(viewdir, i.normal)), _OutLightPow);
                color.a *= _OutLightStrength*dot(viewdir, i.normal);
                return color;
            }

			ENDCG
		}
	}
	FallBack "DIFFUSE"
}