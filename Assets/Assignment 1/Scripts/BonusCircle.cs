using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCircle : MonoBehaviour
{
    public AnimationCurve moveInX;
    public AnimationCurve moveInY;

    public Transform lefttop;
    public Transform rightbottom;

    float t;
    [Range(0f, 1f)]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t = (t + Time.deltaTime*speed) % 1;
        Vector2 pos;
        pos.x=Mathf.Lerp(lefttop.position.x,rightbottom.position.x,moveInX.Evaluate(t));
        pos.y = Mathf.Lerp(lefttop.position.y, rightbottom.position.y, moveInY.Evaluate(t));

        transform.position = pos;

    }
}
