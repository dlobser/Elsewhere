

Shader "OceansVR/Sky/SKY"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
		_Shadow ("Shadow", Float) = 1
		_Tile ("Scale", Float) = 12

    }
    SubShader
    {
        Pass
        {

              Tags { "Queue" = "Transparent" "RenderType"="Transparent"} 

         ZWrite Off // don't write to depth buffer 
//            // in order not to occlude other objects
//
         Blend SrcAlpha OneMinusSrcAlpha // use alpha blending
         LOD 100
//
//         

//            Tags {"LightMode"="ForwardBase"}
        
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

            struct v2f
            {
                float2 uv : TEXCOORD0;
                fixed4 diff : COLOR0;
//                float4 diff2: COLOR1;
                float4 vertex : SV_POSITION;
            };

            float4 _Color;
            float _Shadow;
			sampler2D _MainTex;
			float4 _MainTex_ST;

            v2f vert (appdata_base v)
            {
                v2f o;
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);//UnityObjectToClipPos(v.vertex);
//                o.uv = v.texcoord;
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                float3 viewDir = normalize(ObjSpaceViewDir(v.vertex));
                half3 worldNormal = UnityObjectToWorldNormal(v.normal);
                float nl = max(0, min(1.0,(dot(normalize(v.normal), viewDir ))));
                o.diff =nl;//nl;//(min(1.0,max(0.0,nl)*1.) );


//
//                nl = max(0, dot(worldNormal*-1, _WorldSpaceLightPos0.xyz))+.1;
//                o.diff2 = min(1.0,max(0.0,lerp(_Shadow,1.0,nl)*5.));

//                 v2f o;
//                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
//                o.uv = v.texcoord;
//                half3 worldNormal = UnityObjectToWorldNormal(v.normal);
//                half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
//                o.diff = .25+(min(1.0,max(0.0,nl)*5.) * _LightColor0);

                // the only difference from previous shader:
                // in addition to the diffuse lighting from the main light,
                // add illumination from ambient or light probes
                // ShadeSH9 function from UnityCG.cginc evaluates it,
                // using world space normal
//                o.diff.rgb += ShadeSH9(half4(worldNormal,1));
                return o;
            }
           


            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
//                col *= i.diff;
//                col.a = i.diff.x;
                return i.diff * col * _Color * pow(_Color.a,2)*5.;//fixed4(col.rgb,i.diff.x);
            }
            ENDCG
        }
    }
}