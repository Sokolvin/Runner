using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathscreen : MonoBehaviour
{
    public GameObject GameOver;
    public Player IsDead;
    // Start is called before the first frame update
    void Start()
    {
        ShowDeathScreen(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver != null)
        {
            if (Player.IsDead)
            {
                ShowDeathScreen(true);
            }

        }
    }

    public void ShowDeathScreen(bool show)
    {
        GameOver.SetActive(show);
    }
}
