using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Node_ExportShader : Node_Base
{
    public Dropdown queue;
    public Dropdown blend_srcAlpha;
    public Dropdown blend_dstAlpha;
    override public void Start()
    {
        VariableName = "ExportShader";
        id = 0;
        importer[0]._Base = GetComponent<Node_Base>();
        base.Start();
    }
    public void OnClick()
    {
        NodeManager.Instance.Node_sort(GetComponent<Node_Base>());
        var shaderText = string.Empty;
        shaderText += "Shader \"Custom/export\"";
        shaderText += "{\n" +
            "Properties\n" +
            "{\n" +
            "_MainTex(\"Texture\", 2D) = \"white\" { }\n" +
            "}\n" +
            "SubShader\n" +
            "{\n" +
            "Tags {\"Queue\" =\"" + queue.options[queue.value].text + "\"}\n" +
            "Blend " + blend_srcAlpha.options[blend_srcAlpha.value].text + " " + blend_dstAlpha.options[blend_dstAlpha.value].text + "\n" +
            "Cull Off ZWrite On ZTest LEqual\n" +
            "Pass\n" +
            "{\n" +
            "CGPROGRAM\n" +
            "#pragma vertex vert\n" +
            "#pragma fragment frag\n" +
            "# include \"UnityCG.cginc\"\n" +
           "struct appdata\n" +
            "{\n" +
            "float4 vertex : POSITION;\n" +
            "float2 uv : TEXCOORD0;\n" +
            "};\n" +
            "struct v2f\n" +
            "{\n" +
            "float2 uv : TEXCOORD0;\n" +
            "float4 vertex : SV_POSITION;\n" +
            "};\n" +
            "v2f vert(appdata v)\n" +
            "{\n" +
            "v2f o;\n" +
            "o.vertex = UnityObjectToClipPos(v.vertex);\n" +
            "o.uv = v.uv;\n" +
            "return o;\n" +
            "}\n" +
           "sampler2D _MainTex;\n" +
            "float4 _ExportColor;\n" +
            "fixed4 frag(v2f i) : SV_Target\n" +
            "{\n";

        for (var i = NodeManager.Instance.node_bases.Count - 1; i >= 0; i--)
        {
            var get = NodeManager.Instance.node_bases[i];
            shaderText += get.actionString;
        }
        shaderText += "return " + importer[0].importVariableName + ";\n";
        shaderText += File.ReadAllText(Application.dataPath + "/Shader/shader_template_end.txt");
        File.WriteAllText(Application.dataPath + "/Shader/export.shader", shaderText);
        AssetDatabase.Refresh();
    }
}
