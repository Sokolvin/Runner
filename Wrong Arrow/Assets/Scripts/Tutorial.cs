using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;
    
    // Start is called before the first frame update
    void Start()
    {
        ShowTutorial(false);
    }

    // Update is called once per frame
    

    public void ShowTutorial(bool show)
    {
        tutorial.SetActive(show);
    }
}
