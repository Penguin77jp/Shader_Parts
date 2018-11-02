using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Camera : Node_Base
{
    override public void Start()
    {
        VariableName = "CameraSrc";
        exporter[0]._Base = GetComponent<Node_Base>();
        exporter[0].VariableName = VariableName;
        base.Start();
    }

    public void Update()
    {
        // exporter[0].export = NodeManager.Instance.srcTexture;
        // if (exporter[0].export != null)
        // {
        //     actionString = "float4 " + VariableName + "_" + id + " = tex2D(_MainTex, i.uv);\n";
        // }
    }
}
