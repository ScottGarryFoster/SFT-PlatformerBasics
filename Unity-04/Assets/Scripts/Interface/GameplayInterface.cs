using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayInterface : MonoBehaviour
{
    public PlayerInventory PlayerInventoryComponent;

    public Text PointsText;

    [Header("Health")]
    public int HealthPoints;
    private int healthPoints;

    public List<RawImage> Hearts;

    [Header("Gameover")]
    public GameObject GamoverObject;

    private void Start()
    {
        healthPoints = -1;
    }

    public void ControlGameoverInterface(bool showInterface)
    {
        GamoverObject.SetActive(showInterface);
    }

    private void Update()
    {
        PointsText.text = PlayerInventoryComponent.Points.ToString();
        HealthPoints = PlayerInventoryComponent.Health;

        if(healthPoints != HealthPoints)
        {
            for(int i = 0; i < Hearts.Count; ++i)
            {
                if (HealthPoints >= i + 1)
                {
                    Hearts[i].enabled = true;
                }
                else
                {
                    Hearts[i].enabled = false;
                }
            }
            healthPoints = HealthPoints;
        }
    }
}
