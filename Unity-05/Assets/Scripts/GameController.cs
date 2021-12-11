using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameplayInterface GameplayInterfaceComponent;

    private bool isPaused
    {
        get => pausedRealValue;
        set
        {
            if(value)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            pausedRealValue = value;
        }
    }
    private bool pausedRealValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        GameplayInterfaceComponent.ControlGameoverInterface(true);
        isPaused = true;
    }

    public void RespawnInScene()
    {
        isPaused = false;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
