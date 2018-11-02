Shader "Custom/export"{
Properties
{
_MainTex("Texture", 2D) = "white" { }
}
SubShader
{
Tags {"Queue" ="Transparent"}
Blend SrcAlpha OneminusSrcAlpha
Cull Off ZWrite On ZTest LEqual
Pass
{
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
# include "UnityCG.cginc"
struct appdata
{
float4 vertex : POSITION;
float2 uv : TEXCOORD0;
};
struct v2f
{
float2 uv : TEXCOORD0;
float4 vertex : SV_POSITION;
};
v2f vert(appdata v)
{
v2f o;
o.vertex = UnityObjectToClipPos(v.vertex);
o.uv = v.uv;
return o;
}
sampler2D _MainTex;
float4 _ExportColor;
fixed4 frag(v2f i) : SV_Target
{
float2 UV_14 = i.uv; 
float ExportColorR_13 = UV_14.x; 
float ExportColorG_13 = UV_14.y; 
float Multi_12 = ExportColorG_13*5; 
float Multi_11 = ExportColorR_13*5; 
float Frac_10 = frac(Multi_12);
float Frac_9 = frac(Multi_11);
float Float_8 = 0.5; 
float Float_7 = 0.5; 
float2 UV_6 = i.uv; 
float2 Merge4_5 = fixed2(Frac_9,Frac_10); 
float2 Merge4_4 = fixed2(Float_7,Float_8); 
float ExportColorR_3 = UV_6.x; 
float ExportColorG_3 = UV_6.y; 
float Distance_2 = distance(Merge4_4,Merge4_5); 
float Pow_1 = pow(Distance_2,ExportColorR_3); 
return Pow_1;
			}
			ENDCG
		}
	}
}
