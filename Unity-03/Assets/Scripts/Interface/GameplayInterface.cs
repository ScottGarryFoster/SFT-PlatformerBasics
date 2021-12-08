using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayInterface : MonoBehaviour
{
    public PlayerInventory PlayerInventoryComponent;

    public Text PointsText;

    private void Update()
    {
        PointsText.text = PlayerInventoryComponent.Points.ToString();
    }
}
