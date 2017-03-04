Shader "Custom/earth" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_MainTex2 ("Albedo (RGB)", 2D) = "white" {}
		_MainTex3 ("brighten",2D) = "white"{}
		_BrightenTint ("tint",color) = (1,1,1,1)
		_Mix("mix",float)=0
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _MainTex2;
		float _Mix;
		float4 _BrightenTint;
		sampler2D _MainTex3;

		struct Input {
			float2 uv_MainTex;
			float2 uv_MainTex3;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c2 = tex2D (_MainTex2, IN.uv_MainTex);
			fixed4 c3 = tex2D (_MainTex3, IN.uv_MainTex3) * _BrightenTint;

			fixed4 c = lerp(tex2D (_MainTex, IN.uv_MainTex),c2,_Mix) * _Color;

			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Emission = c3;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
