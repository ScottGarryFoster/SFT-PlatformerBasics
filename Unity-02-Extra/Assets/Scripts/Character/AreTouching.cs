using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreTouching : MonoBehaviour
{
    public string TouchingTag;

    private int thingsTouching;

    // Start is called before the first frame update
    void Start()
    {
        if(TouchingTag == "")
        {
            TouchingTag = "Ground";
        }
    }

    public bool IsTouching()
    {
        return thingsTouching > 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(TouchingTag))
        {
            ++thingsTouching;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TouchingTag))
        {
            --thingsTouching;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TouchingTag))
        {
            ++thingsTouching;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TouchingTag))
        {
            --thingsTouching;
        }
    }
}
