using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;



public class TileGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _start;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _turnLeft_R;
    [SerializeField] private GameObject _turnLeft_Wr;
    [SerializeField] private GameObject _turnRight_R;
    [SerializeField] private GameObject _turnRight_Wr;

    private Vector3 _previousTilePosition;
    public float distanceBetweenTiles = 5.0F;
    private bool _tilesGenerated;

    private Vector3 direction, mainDirection = new Vector3(0, 0, 1), otherDirectionRight = new Vector3(1, 0, 0), otherDirectionLeft = new Vector3(-1, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        _previousTilePosition = transform.position;
        _tilesGenerated = false;
    }

    // Update is called once per frame
    void Update()
    {







    }

    private void GenerateTile(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        
        Instantiate(prefab, position, rotation);
        _previousTilePosition = position;
        

    }

    


    void OnTriggerEnter(Collider other)
    {
        if (!_tilesGenerated && other.tag == "Player")
        {
            Vector3 lookDirection = transform.forward;

            Quaternion playerRotation = transform.rotation;

            int _tilesCount = Random.Range(7, 16);

            for (int i = 0; i < _tilesCount; i++)
            {
                direction = mainDirection;
                GenerateTile(_tilePrefab, _previousTilePosition + distanceBetweenTiles * lookDirection, playerRotation);

            }

            int Turning = Random.Range(0, 2);
            int Arrow = Random.Range(0, 2);

            if (Turning == 0)
            {
                if (Arrow == 0)
                {

                    GenerateTile(_turnLeft_R, _previousTilePosition + distanceBetweenTiles * lookDirection, playerRotation);
                }
                else
                {
                    GenerateTile(_turnLeft_Wr, _previousTilePosition + distanceBetweenTiles * lookDirection, playerRotation);
                }


            }
            else if (Turning == 1)
            {
                if (Arrow == 0)
                {

                    GenerateTile(_turnRight_R, _previousTilePosition + distanceBetweenTiles * lookDirection, playerRotation);
                }
                else
                {
                    GenerateTile(_turnRight_Wr, _previousTilePosition + distanceBetweenTiles * lookDirection, playerRotation);
                }

            }

            _tilesGenerated = true;

        }

    }
}
