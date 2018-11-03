Shader "Custom/export"{
Properties
{
_MainTex("Texture", 2D) = "white" { }
}
SubShader
{
Tags {"Queue" ="Geometry"}
Blend One Zero
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
float Float_3 = 0; 
float Float_2 = 0.5; 
float Distance_1 = distance(Float_2,Float_3); 
return Distance_1;
			}
			ENDCG
		}
	}
}
