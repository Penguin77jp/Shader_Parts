using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class Node_Base : MonoBehaviour
{
    public string actionString;
    public int id;
    public List<Node_importer> importer;
    public List<Node_exporter> exporter;
    private EventTrigger trigger;

    public string VariableName;
    virtual public void Awake()
    {
        id = -1;
        foreach (var get in importer)
        {
            get._Base = GetComponent<Node_Base>();
        }
        foreach (var get in exporter)
        {
            get._Base = GetComponent<Node_Base>();
        }
    }

    virtual public void Start()
    {
        if (VariableName == string.Empty)
        {
            Debug.LogError("変数名が設定されてません" + gameObject.name);
        }
        trigger = gameObject.AddComponent<EventTrigger>();
        var triggerEntry = new EventTrigger.Entry();
        triggerEntry.eventID = EventTriggerType.Drag;
        triggerEntry.callback.AddListener((eventData) => { PositioneMove(); });
        trigger.triggers.Add(triggerEntry);
        SetTerminalPosition();
        //set base
        foreach (var get in importer)
        {
            get._Base = GetComponent<Node_Base>();
        }
        foreach (var get in exporter)
        {
            get._Base = GetComponent<Node_Base>();
        }
    }

    public void SetTerminalPosition()
    {
        //transform
        var mySize = 2f;
        System.Func<List<GameObject>, List<GameObject>> gameObjectActives = (get) =>
          {
              return get.FindAll(x => x.active);
          };
        var _copyGameObjectActive = gameObjectActives(importer.ConvertAll(x => x.gameObject));
        for (int i = 0; i < _copyGameObjectActive.Count; i++)
        {
            _copyGameObjectActive[i].transform.position = transform.position + new Vector3(0, (_copyGameObjectActive.Count - i) * mySize / (float)(_copyGameObjectActive.Count + 1), 0) + new Vector3(-mySize, -mySize, 0) * 0.5f;
        }
        _copyGameObjectActive = gameObjectActives(exporter.ConvertAll(x => x.gameObject));
        for (int i = 0; i < _copyGameObjectActive.Count; i++)
        {
            _copyGameObjectActive[i].transform.position = transform.position + new Vector3(0, (_copyGameObjectActive.Count - i) * mySize / (float)(_copyGameObjectActive.Count + 1), 0) + new Vector3(mySize, -mySize, 0) * 0.5f;
        }
    }

    public void PositioneMove()
    {
        var mousePosi = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z);
        var cam2worldPoint = Camera.main.ScreenToWorldPoint(mousePosi);
        transform.position = new Vector3(cam2worldPoint.x, cam2worldPoint.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            NodeManager.Instance.node_bases.Remove(GetComponent<Node_Base>());
            Destroy(gameObject);
            foreach (var get in importer)
            {
                if (get.pipline != null)
                {
                    Destroy(get.pipline.gameObject);
                }
            }
            foreach (var get in exporter)
            {
                if (get.pipline != null)
                {
                    Destroy(get.pipline.gameObject);
                }
            }
        }
    }
}