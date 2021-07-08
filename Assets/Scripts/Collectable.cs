using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private float smoothCurve;
    public float offset;

    // Use this for initialization
    void Start()
    {

        //Sets the object to your starting point
        //this.transform.position = startPosition;

    }

    // Update is called once per frame
    void Update()
    {

        Move();

    }


    void Move()
    {
        smoothCurve = Mathf.Sin(offset) * 0.01f;
        if (offset > 6.28f)
            offset = 0.0f;
        else
            offset += 0.05f;
        Vector3 temp = transform.position;
        temp.y += smoothCurve;
        transform.position = temp;
    }
}