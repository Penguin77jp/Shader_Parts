using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node_ExportColor : Node_Base
{
    public RenderTexture export_R;
    public RenderTexture export_G;
    public RenderTexture export_B;
    public RenderTexture export_A;
    [SerializeField] private Material mat;
    [SerializeField] private Dropdown ExportType;

    override public void Start()
    {
        VariableName = "ExportColor";

        importer[0]._Base = GetComponent<Node_Base>();
        exporter[0]._Base = exporter[1]._Base = exporter[2]._Base = exporter[3]._Base = GetComponent<Node_Base>();

        base.Start();
    }

    void Update()
    {
        if (importer[0].pipline != null)
        {

            //export
            exporter[0].VariableName = VariableName.ToString() + "R_" + id.ToString();
            exporter[1].VariableName = VariableName.ToString() + "G_" + id.ToString();
            exporter[2].VariableName = VariableName.ToString() + "B_" + id.ToString();
            exporter[3].VariableName = VariableName.ToString() + "A_" + id.ToString();
            var imp0 = importer[0].importVariableName;
            if (ExportType.value == 0)
            {
                actionString = "float " + VariableName + "R_" + id + " = " + imp0 + ".x; \n" +
           "float " + VariableName + "G_" + id + " = " + imp0 + ".y; \n";

            }
            else if (ExportType.value == 1)
            {
                actionString = "float " + VariableName + "R_" + id + " = " + imp0 + ".x; \n" +
           "float " + VariableName + "G_" + id + " = " + imp0 + ".y; \n" +
           "float " + VariableName + "B_" + id + " = " + imp0 + ".z; \n";

            }
            else if (ExportType.value == 2)
            {
                actionString = "float " + VariableName + "R_" + id + " = " + imp0 + ".x; \n" +
           "float " + VariableName + "G_" + id + " = " + imp0 + ".y; \n" +
           "float " + VariableName + "B_" + id + " = " + imp0 + ".z; \n" +
             "float " + VariableName + "A_" + id + " = " + imp0 + ".w; \n";
            }
        }
    }

    public void ChangedExportType()
    {
        exporter[2].gameObject.SetActive(ExportType.value >= 1);
        exporter[3].gameObject.SetActive(ExportType.value >= 2);
        SetTerminalPosition();
    }
}
