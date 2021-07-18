using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorMovement : MonoBehaviour
{

    public float speed;
    private Transform target;
    private bool facingRight = true;
    public bool isAlive = true;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
            moveTowardsPlayer();
    }

    void moveTowardsPlayer()
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            isAlive = false;
            animator.SetBool("isAlive", false);
            this.transform.localRotation = Quaternion.Euler(0, 0, -90);
            //yield return new WaitForSeconds(2);
            //Destroy(this.gameObject);
        }
    }
}
