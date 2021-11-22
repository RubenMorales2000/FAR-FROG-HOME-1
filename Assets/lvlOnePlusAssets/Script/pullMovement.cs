using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullMovement : MonoBehaviour
{
    public GameObject player;
    private bool dragging = false;
    private Vector3 mousePos;
    private Vector3 playerStartPos;
    private Vector3 fixedPos;

    private void Start() {
        this.GetComponent<SpriteRenderer>().enabled = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            fixedPos = setPosToMousePos();
            dragging = true;
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //this.GetComponent<SpriteRenderer>().enabled = false;
            dragging = false;
        }

        if (dragging)
        {
            setPosToMousePos();
            var pos = transform.position;
            var dir = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3)) - pos;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.parent.transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
        }
    }

    private Vector3 setPosToMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3));
        this.transform.position = mousePos;
        return mousePos;
    }
}
