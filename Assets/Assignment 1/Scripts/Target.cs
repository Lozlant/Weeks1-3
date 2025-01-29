using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Transform doll;
    public Transform left;
    public Transform right;
    float pressingTime;
    [Range(0f, 1f)]
    public float speed;
    public AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))// leftbuttonclicked,reset the timer record
        {
            pressingTime = 0;
        }
        if (Input.GetMouseButton(0))
        {
            pressingTime= (pressingTime + Time.deltaTime * speed) % 1;// Makes the timer cycle in 01
        }

        Vector2 pos;
        pos.x=Mathf.Lerp(right.position.x,left.position.x,curve.Evaluate(pressingTime));// caculate the x pos with curve
        pos.y=doll.position.y;
        transform.position = pos;
    }
}
