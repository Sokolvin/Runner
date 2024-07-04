using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 15;
    [SerializeField] private float _accelerationMultiply;
    [SerializeField] private CharacterController _characterController;
    private bool _canRotate = false;
    private bool _hasRotated = false;

    public Animator end;
    public static bool IsDead;

    public Deathscreen deathscreen;

    public float currentDistance;
    public float bestDistance;

    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;
    private float _swipeThreshold = 50f;



    // Start is called before the first frame update
    void Start()
    {
        IsDead = false;
        currentDistance = 0f;
        bestDistance = PlayerPrefs.GetFloat("BestDistance", 0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            _characterController.Move(transform.right * _speed * Input.GetAxis("Horizontal") * Time.deltaTime);
            _characterController.Move(transform.forward * _speed * Time.deltaTime);

            ProcessTouchInput();
            ProcessAccelerometerInput();

            float distanceThisFrame = Time.deltaTime * _speed;
            currentDistance += distanceThisFrame;
            if (currentDistance > bestDistance)
            {
                bestDistance = currentDistance;
            }

            if (_canRotate)
            {

                if (Input.GetKeyDown(KeyCode.A))
                {
                    RotatePlayer(-90f);
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    RotatePlayer(90f);
                }

            }


        }
    }

    private void RotatePlayer(float angle)
    {
        transform.Rotate(new Vector3(0f, angle, 0f));
        _canRotate = false;
        _hasRotated = true;
        StartCoroutine(TurnOn());
    }

    private void ProcessTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    _endTouchPosition = touch.position;
                    Vector2 deltaSwipe = _endTouchPosition - _startTouchPosition;

                    if (Mathf.Abs(deltaSwipe.x) > _swipeThreshold)
                    {
                        if (deltaSwipe.x < 0)
                        {
                            RotatePlayer(-90f);
                        }
                        else if (deltaSwipe.x > 0)
                        {
                            RotatePlayer(90f);
                        }
                    }
                    break;
            }
        }
    }


    private void ProcessAccelerometerInput()
    {
        Vector3 acceleration = Input.acceleration;
        _characterController.Move(transform.right * acceleration.x* _accelerationMultiply * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Turn" && !_hasRotated)
        {
            _canRotate = true;
        }

        if (other.tag == "Acceleration")
        {
            _canRotate = false;
            if (_speed < 50)
                _speed += 1f;

            if (Tile._destroyDelay > 2)
                Tile._destroyDelay -= 0.5f;
        }

        if (other.tag == "Dead_end")
        {
            IsDead = true;
            end = _characterController.GetComponent<Animator>();



            end.SetBool("Death", true);
            PlayerPrefs.SetFloat("BestDistance", bestDistance);
            PlayerPrefs.Save();


        }

        if (other.tag=="coin")
        {
            currentDistance += 5;
        }
    }

    private IEnumerator TurnOn()
    {
        yield return new WaitForSeconds(1f);
        _hasRotated = false;
    }

    public float GetCurrentDistance()
    {
        return currentDistance;
    }

    public float GetBestDistance()
    {
        return bestDistance;
    }
}
