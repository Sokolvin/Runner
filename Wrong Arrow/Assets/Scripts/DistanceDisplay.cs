using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text distanceText; 

    void Start()
    {
        
        distanceText = GetComponent<Text>();
    }

    // ��������� ��������� ���� � ����������� � ���������� ����������
    public void UpdateDistance(float distance)
    {
        distanceText.text = "Distance: " + distance.ToString("F1") + " m"; // ����������� ������ � �����������
    }
}
