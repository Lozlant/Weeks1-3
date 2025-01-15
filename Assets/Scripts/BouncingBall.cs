using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BouncingBall : MonoBehaviour
{
    public Vector2 speed;
    public float sizeChangingSpeed;
    public float acce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 ballInScreenSpace = Camera.main.WorldToScreenPoint(pos);
        if (ballInScreenSpace.x <= 0 || ballInScreenSpace.x >= Screen.width)
        {
            speed.x *= -1;
        }
        if(ballInScreenSpace.y <= 0 || ballInScreenSpace.y >= Screen.height)
        {
            speed.y *= -1;
        }

        ballInScreenSpace.x = Mathf.Clamp(ballInScreenSpace.x, 0, Screen.width);
        ballInScreenSpace.y = Mathf.Clamp(ballInScreenSpace.y, 0, Screen.height);
        pos = Camera.main.ScreenToWorldPoint(ballInScreenSpace);

        Vector2 scale = transform.localScale;
        Vector2 sizechange = new Vector2(sizeChangingSpeed,sizeChangingSpeed) * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            scale += sizechange;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            scale -= sizechange;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float speedMagnitude = Mathf.Clamp(speed.magnitude - acce*Time.deltaTime, 0.1f, speed.magnitude);
            speed = speed.normalized * speedMagnitude;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float speedMagnitude = Mathf.Clamp(speed.magnitude + acce * Time.deltaTime, 0.1f, speed.magnitude + acce);
            speed = speed.normalized * speedMagnitude;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            pos = Vector2.zero;
            speed = new Vector2(Random.Range(0.1f,15f), Random.Range(0.1f, 15f));
        }

        pos += speed * Time.deltaTime;
        
        transform.position = pos;
        transform.localScale = scale;

        


        

    }
}
