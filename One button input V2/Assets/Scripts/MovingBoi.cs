using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MovingBoi : MonoBehaviour
{
    private Vector3 startingPoint;
    private Vector3 openPosition;
    [SerializeField] private Vector3 direction = Vector3.down;
    [SerializeField] private float distance;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 3f;
    [SerializeField] private float slowTime = .008f;
    private bool isOpen = false;
    private float nextTimeIceMoves;
    Coroutine running;

    [SerializeField] private bool _isMoving = false;

    NavMeshObstacle obstacle;

    // The following is properties "get" or "set"
    public bool IsLocked
    {
        set//can be wrtien or changed
        {
            _isMoving = value;

            if (value) //value==true
            {
                if (running != null) StopCoroutine(running);
                if (obstacle != null) obstacle.carving = true;
            }
            else
            {
                if (obstacle != null) obstacle.carving = true;
            }
        }
        get//is read only
        {
            return _isMoving;
        }
    }
    private void OnValidate()
    {
        if (_isMoving)
        {
            if (running != null) StopCoroutine(running);
            if (obstacle != null) obstacle.carving = true;
        }
        else
        {
            if (obstacle != null) obstacle.carving = true;
        }

    }
    private void Awake()
    {
        obstacle = GetComponent<NavMeshObstacle>();
    }
    void Start()
    {
        startingPoint = transform.position;
        openPosition = transform.position + (direction.normalized * distance);

        nextTimeIceMoves = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        OpenCloseDoor();
    }

    void OpenCloseDoor()
    {
        if (IsLocked)
        {
            return;
        }

        if (nextTimeIceMoves < Time.time)
        {
            nextTimeIceMoves = Time.time + waitTime;
            if (isOpen)
            {   //Closing
                if (running != null) StopCoroutine(running);
                running = StartCoroutine(MoveDoor(startingPoint));
                isOpen = false;
            }
            else
            {//Opening
                isOpen = true;
                if (running != null) StopCoroutine(running);
                running = StartCoroutine(MoveDoor(openPosition));
                //test dont do this
                IsLocked = false;
            }
            Debug.Log("Ice Move");
        }
    }
    IEnumerator MoveDoor(Vector3 position)
    {
        while (Vector3.Distance(transform.position, position) > slowTime)
        {
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * speed);
            yield return null;
        }

    }
}