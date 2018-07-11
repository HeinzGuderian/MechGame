Shader "LEARN/White Color" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _NormalMap ("NormalMap", 2D) = "white"{}
      _DetailTex ("Detail Texture", 2D) = "gray"{}

      _RimColor ("Rim Color (RGB)", Color) = (1,1,1,1)
      _RimPower ("Rim Power", Range(0, 5)) = 3.0
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
          float2 uv_DetailTex;
          float2 uv_NormalMap;
          float3 viewDir;
          float4 screenPos;
          float3 worldPos;
      };
      sampler2D _MainTex;
      sampler2D _NormalMap;
      sampler2D _DetailTex;
      float4 _RimColor;
      float _RimPower;
      

      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          clip (frac((IN.worldPos.y+IN.worldPos.z*0.1) * 3) - 0.5); //clips along vertical axis
          //uv scale detail texture:
          //o.Albedo *= tex2D (_DetailTex, IN.uv_DetailTex).rgb * 2;
          o.Normal = UnpackNormal(tex2D (_NormalMap, IN.uv_NormalMap));
          half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
          o.Emission = _RimColor.rgb * pow(rim, _RimPower);
          float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
          //screenUV *= float2(1,10); //tiling av detailtexturen i U och V led
          o.Albedo *= tex2D(_DetailTex, screenUV).rgb;
          
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }