using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int Points;

    public int Health;

    public int MaxHealth;

    public GameController GameControllerComponent;

    private Transform checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        Health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectable-Idol"))
        {
            Points++;
        }
        else if (collision.gameObject.CompareTag("Damage-Spikes"))
        {
            ReduceHeath(1);
            SpawnAtCheckpoint();
        }
        else if (collision.gameObject.CompareTag("Checkpoint"))
        {
            checkpoint = collision.gameObject.transform;
        }
        else if (collision.gameObject.CompareTag("Collectable-Health1"))
        {
            IncreaseHealth(1);
        }
    }

    private void ReduceHeath(int amount)
    {
        Health -= amount;
        if(Health <= 0)
        {
            GameControllerComponent.GameOver();
        }
    }

    private void IncreaseHealth(int amount)
    {
        Health += amount;
        Health = Health > MaxHealth ? MaxHealth : Health;
    }

    private void SpawnAtCheckpoint()
    {
        gameObject.transform.position = checkpoint.position;
    }
}
