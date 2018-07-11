// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
//1 tinting med en ny färg
//2 tinting med UVkoordinater
//3 lerpa mellan 2 texturer mha Tween
//4 gör tiled sprites (ej clamped texture)

Shader "LEARN/LearningShader" {
	Properties
	{
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_DisplaceTex ("Displacement Texture", 2D) = "white"{}
		_Magnitude ("Magnitude", Range(0,0.5)) = 0
		//_RimColor ("Rim Color (RGB)", Color) = (1,1,1,1)
		//_RimPower ("Rim Power", Range(0.0,10.0)) = 1.0
		_Speed ("Speed", float) = 1.0
	}
	SubShader
	{
		Tags
		{
			"PreviewType" = "Plane"
			"Queue" = "Transparent"
		}
		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"


			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			sampler2D _MainTex;
			sampler2D _DisplaceTex;
			float _Magnitude;
			float4 _RimColor;
			float _RimPower;
			float _Speed;
			//_SinTime och _CosTime kan man använda
			float4 frag (v2f i) : SV_Target
			{
				float2 distuv = float2(i.uv.x, i.uv.y * _SinTime.x +_Time.x * _Speed);
				float2 disp = tex2D(_DisplaceTex, distuv).xy;
				disp = ((disp * 2) - 1) * _Magnitude;
				float4 col = tex2D(_MainTex, i.uv + disp);
				//col = dot(col, _MainTex);
				return col;
			}
			ENDCG
		}
	}
}