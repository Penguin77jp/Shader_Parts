using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_move : MonoBehaviour
{
    public float speed;
    public float shiftSpeed;
    public float mouseScrollSpeed;
    public float shiftMouseScrollSpeed;
    private float zoomLevel = 0f;
    void Update()
    {
        var getSpeed = Input.GetKey(KeyCode.LeftShift) ? shiftSpeed : speed;
        getSpeed *= zoomLevel;
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * getSpeed * Time.deltaTime;
        var getScrollSpeed = Input.GetKey(KeyCode.LeftShift) ? shiftMouseScrollSpeed : mouseScrollSpeed;
        zoomLevel -= Input.mouseScrollDelta.y * getScrollSpeed * Time.deltaTime;
        transform.position += new Vector3(0, 0, Input.mouseScrollDelta.y) * getScrollSpeed * Time.deltaTime;
    }
}
