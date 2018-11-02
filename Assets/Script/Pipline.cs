using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pipline : MonoBehaviour
{
    public Node_exporter pointExporter;
    public Node_importer pointImporter;
    public LineRenderer line
    {
        private set;
        get;
    }
    private bool once = false;
    public string actionString;
    public string VariableName;

    void Awake()
    {
        if (GetComponent<LineRenderer>() != null)
        {
            line = GetComponent<LineRenderer>();
        }
        else
        {
            line = gameObject.AddComponent<LineRenderer>();
        }
        line.SetWidth(0.2f, 0.2f);
    }

    void Update()
    {
        var posi = new List<Vector3>();
        if (pointExporter != null)
        {
            posi.Add(pointExporter.transform.position);
        }
        if (pointImporter != null)
        {
            posi.Add(pointImporter.transform.position);
        }
        if (pointImporter != null && pointExporter != null)
        {
            pointImporter.importVariableName = pointExporter.VariableName;
            pointExporter.pipline = pointImporter.pipline = GetComponent<Pipline>();
            if (!once)
            {
                if (pointExporter._Base.importer.Count == 0)
                {
                    Add_NodeBase(pointExporter._Base);
                }
                Add_NodeBase(pointImporter._Base);
                once = true;
            }
        }
        line.SetPositions(posi.ToArray());
    }

    void Add_NodeBase(Node_Base get)
    {
        var copy = new List<Node_Base>(NodeManager.Instance.node_bases);
        if (copy.TrueForAll(x => x != get))
        {
            NodeManager.Instance.node_bases.Add(get);
        }
    }
}