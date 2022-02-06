using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    Vector2 movement;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Flip the sprite on horizontal axis
        if(movement.x < -0.1f)
        {
            spriteRenderer.flipX = true;
        } else if (movement.x > 0.1f) {
            spriteRenderer.flipX = false;
        }

        // Control the animation
        if(Mathf.Abs(movement.x) > 0.1f || Mathf.Abs(movement.y) > 0.1f)
        {
            anim.SetBool("running", true);
        } else
        {
            anim.SetBool("running", false);
        }

        // Replay game
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
}
