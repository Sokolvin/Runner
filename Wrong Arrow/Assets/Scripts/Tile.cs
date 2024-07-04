using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tile : MonoBehaviour
{
    
    [SerializeField] private List<Transform> _points = new List<Transform>();
    [SerializeField] private GameObject _coin;
    public static float _destroyDelay = 5f;
    private bool _isInView = true;

    // Start is called before the first frame update
    void Start()
    {
        int randomPointIndex = Random.Range(0, _points.Count);
        if (_points.Any())
        {
            GameObject newCoin = Instantiate(_coin, _points[randomPointIndex].position, Quaternion.identity);
            newCoin.transform.SetParent(transform);

        }
        

    }

    // Update is called once per frame

    void Update()
    {
        if (!_isInView)
        {
            
            StartCoroutine(DestroyAfterDelay());
        }



    }

    private void OnBecameInvisible()
    {
        _isInView = false;
    }

    
    private void OnBecameVisible()
    {
        _isInView = true;
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(Tile._destroyDelay);
        Destroy(gameObject);
    }
}
