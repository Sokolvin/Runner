using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScenes(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }

    public void RestartScene()
    {
        int activeScene=SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(activeScene);
    }


    public void Exit()
    {
        Application.Quit();
    }
}
