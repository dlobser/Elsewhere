Shader "Unlit/TransparentMultiAdditive"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_MainTex2 ("Texture", 2D) = "white" {}
		_Speed ("speed",float) = 0
		_Color("Color",color) = (1,1,1,1)

	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue" = "Transparent"}
		Blend One One
		ZWrite Off

		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD2;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD2;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _MainTex2;
			float4 _MainTex2_ST;
			float _Speed;
			float4 _Color;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv2 = TRANSFORM_TEX(v.uv, _MainTex2);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 col2 = tex2D(_MainTex2, i.uv2+float2(_Time.z*_Speed,_Time.z*_Speed));
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col2);
				return col2*col.a*_Color;
			}
			ENDCG
		}
	}
}
