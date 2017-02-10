Shader "ON/Simple/TextureTint2"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_MainTex2 ("Texture", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
		_Color2 ("Color Lighten", Color) = (0,0,0,0)
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
				float4 color :COLOR;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD2;
				float4 color : COLOR;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _MainTex2;
			float4 _MainTex2_ST;
			fixed4 _Color;
			fixed4 _Color2;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv2 = TRANSFORM_TEX(v.uv2, _MainTex2);
				o.color = v.color;
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 colb = tex2D(_MainTex2, i.uv2+col.xy+float2(_Time.x,_Time.y));
				fixed4 col2 = ((lerp(col, _Color2, _Color2.a)) + (i.color * col * 5 * float4(1, .5, 0, 0))) *_Color;
				float overone = max(0.0,min(1.0,(1-i.uv.x)*1000000));
				fixed4 col3 = lerp(colb,col2,overone);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col3);
				return col3;// * overone;// ((lerp(col, _Color2, _Color2.a)) + (i.color * col * 5 * float4(1, .5, 0, 0))) *_Color;
			}
			ENDCG
		}
	}
}
