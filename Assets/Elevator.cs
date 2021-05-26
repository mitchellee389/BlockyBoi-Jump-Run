using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private float movement = 0.005f;
    private float moveRate = 5.5f;
    private float nextSwitch = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSwitch)
        {
            movement = -(movement);
            nextSwitch = moveRate + Time.time;
        }
        float yposition = gameObject.transform.position.y;
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, yposition + movement);
    }
}
