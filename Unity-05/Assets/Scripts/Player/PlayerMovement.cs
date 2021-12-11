using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2DComponent;

    private AreTouching areTouchingComponent;

    private Animator animatorController;

    private SpriteRenderer spriteRendererComponent;

    private EDirection currentDirection;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2DComponent = gameObject.GetComponent<Rigidbody2D>();
        areTouchingComponent = gameObject.GetComponent<AreTouching>();
        animatorController = gameObject.GetComponent<Animator>();
        spriteRendererComponent = gameObject.GetComponent<SpriteRenderer>();
        currentDirection = EDirection.Right;
    }

    // Update is called once per frame
    void Update()
    {
        int speed = 340;
        float movementAmount = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        rigidbody2DComponent.AddForce(new Vector2(movementAmount, 0));
        UpdateDirection();

        bool areOnGround = areTouchingComponent.IsTouching();
        if (areOnGround && Input.GetButtonUp("Jump"))
        {
            rigidbody2DComponent.AddForce(new Vector2(0, speed));
        }

        // Update Animator
        animatorController.SetBool("AreOnGround", areOnGround);
        animatorController.SetFloat("Speed", rigidbody2DComponent.velocity.magnitude);
        animatorController.SetFloat("VerticalDirection", rigidbody2DComponent.velocity.y);

        // Change this when we actually do attacking
        if(Input.GetButtonUp("Fire2"))
        {
            animatorController.SetTrigger("Attack");
        }
    }

    private void UpdateDirection()
    {
        if (currentDirection == EDirection.Right && Input.GetAxis("Horizontal") < 0)
        {
            spriteRendererComponent.flipX = true;
            currentDirection = EDirection.Left;
        }
        else if (currentDirection == EDirection.Left && Input.GetAxis("Horizontal") > 0)
        {
            spriteRendererComponent.flipX = false;
            currentDirection = EDirection.Right;
        }
    }
}
