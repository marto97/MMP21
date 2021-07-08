using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorMovement : MonoBehaviour
{

    public float speed;
    private bool facingRight = true;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (transform.position.x > target.position.x && facingRight)
        {
            facingRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (transform.position.x < target.position.x && !facingRight)
        {
            facingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
