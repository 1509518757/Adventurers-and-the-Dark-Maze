using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 lookDirection = new Vector2(0,0);

    Rigidbody2D rbody;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveVector = new Vector2(moveX, moveY);
        if (moveVector.x == 0 || moveVector.y == 0) {
            lookDirection = moveVector;
        }
        anim.SetFloat("moveX", lookDirection.x);
        anim.SetFloat("moveY", lookDirection.y);


        Vector2 position = rbody.position;
        position.x += moveX * speed * Time.fixedDeltaTime;
        position.y += moveY * speed * Time.fixedDeltaTime;
        rbody.MovePosition(position);

    }
}