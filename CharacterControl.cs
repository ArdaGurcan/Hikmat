using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 1f;
    bool facingRight = false;
    Animator animator;
    public GameObject bomb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Bombing", 10f, 5f);
            
    }

    void Bombing()
    {
        Instantiate(bomb, transform.position + Vector3.right * Random.RandomRange(-100, 100) + Vector3.forward * Random.RandomRange(60, 100), Quaternion.identity);
    }

    void Update()
    {
        if(transform.position.x > -30)
        {

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);

        //if (Input.GetButtonDown("Jump"))
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, 0);
        //    rb.AddForce(Vector3.up * 4f, ForceMode2D.Impulse);
        //}
        }
        else
        {
            animator.SetBool("dead", true);
            StartCoroutine("Die");
        }

        if (Mathf.Abs(rb.velocity.x) > 0.1f)
        {
            if(facingRight != rb.velocity.x > 0)
            {
                facingRight = rb.velocity.x > 0;
                if (facingRight)
                {
                    transform.position += new Vector3(2, 0, 0);
                }
                else
                {
                    transform.position -= new Vector3(2, 0, 0);
                }
            }

        }
        transform.localScale = new Vector3(facingRight ? 0.5f : -0.5f, transform.localScale.y, transform.localScale.z);

        animator.SetBool("idle", Mathf.Abs(rb.velocity.x) < 0.3f);
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        animator.enabled = false;
    }
}
