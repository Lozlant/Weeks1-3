using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class DollMoving : MonoBehaviour
{
    public Transform top;
    public Transform bottom;

    public Transform target;

    public AnimationCurve moveInX;
    public AnimationCurve size;

    [Range(0f, 1f)]
    public float speed;

    public bool throwing;
    float t;
    Vector2 throwpos;
    Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos =transform.position;
        if (Input.GetMouseButtonUp(0)) // if releasing the left mousebutton, set the throwing to true and record the start and target position
        {
            throwing = true;
            throwpos = transform.position;
            targetPos = target.position;
        }
        if (throwing)
        {
            t = t + Time.deltaTime * speed; // record the throwing time
            pos.x = Mathf.Lerp(throwpos.x, targetPos.x, moveInX.Evaluate(t)); 
            transform.localScale = Vector3.Lerp(Vector3.one, 2f*Vector3.one, size.Evaluate(t)); // set the size
            if (t >=1.2f) { // the doll have arrived to target and stay for 0.2/speed(s)
                throwing = false; // exit throwing
                t=0; 
                pos.x=throwpos.x; //reset timer and the doll position
            }
        }
        else //if not throwing, make the doll follows the mouse
        {
            pos.y = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, bottom.position.y, top.position.y); // the doll's y position follows the mouse
        }
        transform.position = pos;

    }
}
