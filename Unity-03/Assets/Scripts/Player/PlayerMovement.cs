using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidbody2DComponent;

    private AreTouching areTouchingComponent;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2DComponent = gameObject.GetComponent<Rigidbody2D>();
        areTouchingComponent = gameObject.GetComponent<AreTouching>();
    }

    // Update is called once per frame
    void Update()
    {
        int speed = 340;
        float movementAmount = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        rigidbody2DComponent.AddForce(new Vector2(movementAmount, 0));

        if(areTouchingComponent.IsTouching() && Input.GetButtonUp("Jump"))
        {
            rigidbody2DComponent.AddForce(new Vector2(0, speed));
        }
    }
}
