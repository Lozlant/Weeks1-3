using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public Transform Object1;
    public Transform Object2;
    public Transform Object3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos= Camera.main.ScreenToWorldPoint( Input.mousePosition );
        if (Input.GetMouseButtonDown(0))
        {
            Object1.position=mousePos;
        }

        Vector3 pos2 = Object2.position;
        float distance=Vector2.Distance( pos2, mousePos );
        if(distance < 1.0f)
        {
            pos2 = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height)));
            pos2.z=0.0f;
        }
        Object2.position = pos2;

        Vector2 direction = mousePos - (Vector2)Object3.position;
        //Object3.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        Object3.up=direction;
        if (Input.GetMouseButton(0))
        {
            Object3.Translate(direction * Time .deltaTime);
        }
    }
}
