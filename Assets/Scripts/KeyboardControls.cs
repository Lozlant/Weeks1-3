using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{
    public float speed;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.Translate(direction * speed * Time.deltaTime);

        Vector2 posInScreenSpace = Camera.main.WorldToScreenPoint(transform.position);
        posInScreenSpace.x = Mathf.Clamp(posInScreenSpace.x, 0, Screen.width);
        posInScreenSpace.y = Mathf.Clamp(posInScreenSpace.y, 0, Screen.height);
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(posInScreenSpace);
    }
}
