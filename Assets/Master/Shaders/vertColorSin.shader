Shader "Unlit/vertColorSin"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Data("D", Vector) = (0,0,0,0)
		_Color("Color", Color) = (1,1,1,1)
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" }
		Blend One One
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
				float4 color :COLOR;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 color :COLOR;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Data;
			float4 _Color;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.color = v.color;
				//o.color.x = ((cos(v.color.x * 6.28)-1)*.5);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				float ring = ((cos(( max(0.0, min(1.0,i.color.x + ((_Data.x*1.3))-.65   )) * 6.28) ) - 1)*-.5);

				col *= pow(ring,_Data.y);// ((cos((i.color.x * 6.28) + _Data.x) - 1)*-.5);
				col *= min(1.0, i.color.x * 10);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col * _Color;
			}
			ENDCG
		}
	}
}
