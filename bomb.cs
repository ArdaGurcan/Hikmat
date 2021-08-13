using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        transform.position += Vector3.up * transform.position.z * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < transform.position.z * -0.5f -5)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            animator.enabled = true;
            StartCoroutine("coroutine");
        }
    }
    IEnumerator coroutine()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
