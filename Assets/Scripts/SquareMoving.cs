using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMoving : MonoBehaviour
{
    float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 screenpos = Camera.main.WorldToViewportPoint(pos);
        if (screenpos.x > 1 || screenpos.x <0)
        {
            speed *= -1;
        }
        pos.x += speed;
        transform.position = pos;

    }
}
