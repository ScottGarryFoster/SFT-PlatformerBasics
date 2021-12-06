using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidbody2DComponent;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2DComponent = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int speed = 340;
        float movementAmount = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        rigidbody2DComponent.AddForce(new Vector2(movementAmount, 0));
    }
}
