using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int SecondsBetweenRespawns;

    public bool IsCollectedByDefault;

    private Collider2D collider2DComponent;

    private SpriteRenderer spriteRendererComponent;

    private bool isCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRendererComponent = gameObject.GetComponent<SpriteRenderer>();
        collider2DComponent = gameObject.GetComponent<Collider2D>();

        if(IsCollectedByDefault)
        {
            SetCollectableState(false);
        }
    }

    public void SetCollectableState(bool isCollectable)
    {
        if(isCollectable)
        {
            isCollected = false;
            spriteRendererComponent.color = new Color(255, 255, 255, 255);
            collider2DComponent.enabled = true;
        }
        else
        {
            isCollected = true;
            spriteRendererComponent.color = new Color(0, 0, 0, 0);
            collider2DComponent.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SetCollectableState(false);
            if (SecondsBetweenRespawns > 0)
            {
                StartCoroutine("ReenableCollectable");
            }
        }
    }

    private IEnumerator ReenableCollectable()
    {
        yield return new WaitForSeconds(SecondsBetweenRespawns);
        SetCollectableState(true);
    }
}
