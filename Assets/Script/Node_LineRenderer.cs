using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Node_LineRenderer : MonoBehaviour
{
    private LineRenderer line;
    void OnMouseDown()
    {
        if (LineManager.Instance.lineCreating == null)
        {
            var ob = new GameObject();
            var pip = ob.AddComponent<Pipline>();
            if (gameObject.GetComponent<Node_importer>() != null)
            {
                pip.pointImporter = GetComponent<Node_importer>();
            }
            else if (gameObject.GetComponent<Node_exporter>() != null)
            {
                pip.pointExporter = GetComponent<Node_exporter>();
            }
            LineManager.Instance.lineCreating = pip.line;
        }
        else
        {
            var pip = LineManager.Instance.lineCreating.GetComponent<Pipline>();
            if (gameObject.GetComponent<Node_importer>() != null)
            {
                pip.pointImporter = GetComponent<Node_importer>();
            }
            else if (gameObject.GetComponent<Node_exporter>() != null)
            {
                pip.pointExporter = GetComponent<Node_exporter>();
            }
            LineManager.Instance.lineCreating = null;
        }
    }

    void OnMouseUp()
    {
        // var line = LineManager.Instance.lineCreating;
        // if (line != null && line.GetComponent<Pipline>().startPoint != gameObject)
        // {
        //     line.GetComponent<Pipline>().endPoint = gameObject;
        //     LineManager.Instance.lineCreating = null;
        // }
    }
}
