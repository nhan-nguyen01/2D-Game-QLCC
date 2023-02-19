using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private Animator anim;
    private float dirX = 0f;
    [SerializeField] private float MoveSpeed = 7f;
    [SerializeField] private float JumpForce = 14f;

    private enum MovementState {idle, run, jump, fall }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
        if(Input.GetButtonDown("Jump"))
            {
            rb.velocity = new Vector2(rb.velocity.x, 14f); 
            }
        UpdateAnimationUpdate();
    }
    private void UpdateAnimationUpdate()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.run;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if(rb.velocity.y < -.1f)
            {
                state = MovementState.fall;
            }
        anim.SetInteger("state", (int)(state));
    }
}