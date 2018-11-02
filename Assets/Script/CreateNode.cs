using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNode : MonoBehaviour
{
    [SerializeField]
    private GameObject new_node;
    void Start()
    {
        new_node.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) || Input.GetMouseButtonDown(1))
        {
            var mousePosi = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z);
            var cam2worldPoint = Camera.main.ScreenToWorldPoint(mousePosi);
            cam2worldPoint = new Vector3(cam2worldPoint.x, cam2worldPoint.y, transform.position.z);
            var obj = Instantiate(new_node, cam2worldPoint, new_node.transform.rotation, new_node.transform.parent.transform);
            obj.SetActive(true);
        }
    }
}
