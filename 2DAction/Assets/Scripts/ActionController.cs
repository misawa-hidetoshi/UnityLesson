using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ActionController : MonoBehaviour
{
    Rigidbody2D rigidbody = null;
    [SerializeField] float movePower = 50.0f;
    [SerializeField] float jumpPower = 10.0f;
    [SerializeField] float maxSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(Vector2.right * movePower);
            key = 1;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(Vector2.left * movePower);
            key = -1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        if(Mathf.Abs(rigidbody.velocity.x)>maxSpeed)
        {
            var velocity = rigidbody.velocity;
            velocity.x = maxSpeed * key;
            rigidbody.velocity = velocity;
        }
    }
}
