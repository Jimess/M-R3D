Shader "TessellationExample" {
        Properties {
            _Tess ("Tessellation", Range(1,32)) = 4
			// Ground Textures and colors
            _GroundTex ("Ground (RGB)", 2D) = "white" {}
			_GroundColor ("Ground Color", color) = (1,1,1,0)

			_SandTex ("Sand (RGB)", 2D) = "Brown" {}
			_SandColor ("Sand Color", color) = (1,1,1,0)
			// Sand Textures and colors

            _Splat ("SplatMap", 2D) = "black" {}
            _NormalMap ("Normalmap", 2D) = "bump" {}
            _Displacement ("Displacement", Range(0, 4.0)) = 0.3
            
            _SpecColor ("Spec color", color) = (0.5,0.5,0.5,0.5)
        }
        SubShader {
            Tags { "RenderType"="Opaque" }
            LOD 300
            
            CGPROGRAM
            #pragma surface surf BlinnPhong addshadow fullforwardshadows vertex:disp tessellate:tessDistance nolightmap
            #pragma target 4.6
            #include "Tessellation.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float4 tangent : TANGENT;
                float3 normal : NORMAL;
                float2 texcoord : TEXCOORD0;
            };

            float _Tess;

            float4 tessDistance (appdata v0, appdata v1, appdata v2) {
                float minDist = 10.0;
                float maxDist = 25.0;
                return UnityDistanceBasedTess(v0.vertex, v1.vertex, v2.vertex, minDist, maxDist, _Tess);
            }

            sampler2D _Splat;
            float _Displacement;

            void disp (inout appdata v)
            {
                float d = tex2Dlod(_Splat, float4(v.texcoord.xy,0,0)).r * _Displacement;
                v.vertex.xyz -= v.normal * d;
				v.vertex.xyz += v.normal * _Displacement;
            }

            struct Input {
                float2 uv_GroundTex;
				float2 uv_SandTex;
				float2 uv_Splat;
            };

            sampler2D _GroundTex;
			fixed4 _GroundColor;

			sampler2D _SandTex;
			fixed4 _SandColor;

            sampler2D _NormalMap;

            void surf (Input IN, inout SurfaceOutput o) {
				half amount = tex2Dlod(_Splat, float4(IN.uv_Splat,0,0)).r;
				fixed4 c = lerp(tex2D (_SandTex, IN.uv_SandTex) * _SandColor, tex2D (_GroundTex, IN.uv_GroundTex) * _GroundColor, amount);

                //half4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
                o.Albedo = c.rgb;
                o.Specular = 0.2;
                o.Gloss = 1.0;
                //o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_MainTex));
            }
            ENDCG
        }
        FallBack "Diffuse"
    }