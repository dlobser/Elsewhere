Shader "ON/tint"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Mult ("Multiply", float) = 0
		_Data ("Data", vector) = (0,0,0,0)
		_SecondTex("Texture 2", 2D) = "white"{}
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
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _SecondTex;
			float4 _SecondTex_ST;
			float _Mult;
			float4 _Data;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;// TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, TRANSFORM_TEX(i.uv, _MainTex));
				fixed4 col2 = tex2D(_SecondTex, _Data.w*TRANSFORM_TEX(i.uv, _SecondTex) + float2(_Time.z * _Data.x, _Time.z * _Data.y));
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return lerp(col,col2,_Data.z)*_Mult;
			}
			ENDCG
		}
	}
}
