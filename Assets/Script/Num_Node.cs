using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Num_Node : MonoBehaviour
{

    private List<GameObject> nodes;
    private GameObject parent;
    void Start()
    {
        nodes = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (parent != null)
            {
                Destroy(parent);

            }
            else
            {
                nodes = new List<GameObject>(GameObject.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[]);
                nodes.ForEach(x =>
                {
                    if (x.GetComponent<Node_Base>() == null)
                    {
                        nodes.Remove(x);
                    }
                });
                parent = new GameObject();
                parent.transform.parent = GameObject.Find("Canvas").transform;
                nodes.ForEach(x =>
                {
                    if (x.GetComponent<Node_Base>() != null)
                    {
                        var textObj = new GameObject();
                        textObj.name = "node_num";
                        textObj.transform.parent = parent.transform;
                        textObj.transform.localScale = Vector3.one * 0.1f;
                        var text = textObj.AddComponent<Text>();
                        text.alignment = TextAnchor.MiddleCenter;
                        text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                        text.text = x.GetComponent<Node_Base>().id.ToString();
                        textObj.transform.position = x.transform.position;
                    }
                });
            }
        }
    }
}
