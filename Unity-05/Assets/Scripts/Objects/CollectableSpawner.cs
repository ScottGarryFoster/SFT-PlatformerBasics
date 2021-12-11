using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public int SecondsBetweenRespawns;

    public Collectable CollectableInside;

    public Sprite ActivatedSprite;

    private Sprite originalSprite;

    private SpriteRenderer spriteRendererComponent;

    private int playerTagsTouching;

    private bool areEmpty;

    // Start is called before the first frame update
    void Start()
    {
        spriteRendererComponent = gameObject.GetComponent<SpriteRenderer>();
        originalSprite = spriteRendererComponent.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(!areEmpty && playerTagsTouching > 0)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                CollectableInside?.SetCollectableState(true);
                areEmpty = true;
                spriteRendererComponent.sprite = ActivatedSprite;
                if(SecondsBetweenRespawns > 0)
                {
                    StartCoroutine("ReenableCollectable");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ++playerTagsTouching;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            --playerTagsTouching;
        }
    }

    private IEnumerator ReenableCollectable()
    {
        yield return new WaitForSeconds(SecondsBetweenRespawns);
        spriteRendererComponent.sprite = originalSprite;
        areEmpty = false;
    }
}
