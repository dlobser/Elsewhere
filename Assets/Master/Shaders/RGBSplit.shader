Shader "Unlit/RGBSplit"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_MainTex2B ("Texture", 2D) = "white" {}
		_MainTex2 ("Texture", 2D) = "white" {}
		_MainTex3 ("Texture", 2D) = "white" {}
		_Fader ("Fader",float) = 0
		_Color ("Color", Color) = (0,0,0,0)
		_ColorR ("ColorR", Color) = (0,0,0,0)
		_ColorG ("ColorG", Color) = (0,0,0,0)
		_ColorB ("ColorB", Color) = (0,0,0,0)
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
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD0;
				float2 uv3 : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD2;
				float2 uv3 : TEXCOORD3;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _MainTex2;
			float4 _MainTex2_ST;
			sampler2D _MainTex2B;
			sampler2D _MainTex3;
			float4 _MainTex3_ST;
			float4 _Color;
			float4 _ColorR;
			float4 _ColorG;
			float4 _ColorB;
			float _Fader;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv2 = TRANSFORM_TEX(v.uv2, _MainTex2);
				o.uv3 = TRANSFORM_TEX(v.uv3, _MainTex3);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 col2 = tex2D(_MainTex2, i.uv2);
				fixed4 col2b = tex2D(_MainTex2B, i.uv2);
				fixed4 col2c = lerp(col2,col2b,_Fader);
				fixed4 col3 = tex2D(_MainTex3, i.uv3);
				fixed4 colR = col.r*_ColorR*_ColorR.a*3;
				fixed4 colG = col.g*_ColorG*_ColorG.a*3;
				fixed4 colB = col.b*_ColorB*_ColorB.a*3;
				fixed4 fCol = colR+colG+colB;
				fCol*=col2c*col3;
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, fCol);
				return fCol+_Color;
			}
			ENDCG
		}
	}
}
