using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _distance;
    [SerializeField] private TextMeshProUGUI _bestDistanceText;
    
    public Player player;
    public float currentDistance;
    void Update()
    {
        
        currentDistance = player.GetCurrentDistance();
        float bestDistance = player.GetBestDistance();
        
        _distance.text = currentDistance.ToString("F0");
        _bestDistanceText.text = bestDistance.ToString("F0");
    }

  
}
