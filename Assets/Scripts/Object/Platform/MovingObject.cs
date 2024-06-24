using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private List<Transform> movePoint = new List<Transform> { };
    List<Vector3> movePosition = new List<Vector3> { };
    Vector3 targetPosition;
    int targetIndex;
    int lastIndex;
    int direction;
 
    

    private void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();

        foreach(Transform point in movePoint)
        {
            movePosition.Add(point.position);
        }

        lastIndex = movePosition.Count - 1;
        targetIndex = 1;
        targetPosition = movePosition[targetIndex];
        direction = 1;
    }



    void FixedUpdate()
    {
        _rigidbody.MovePosition(Vector3.MoveTowards(_rigidbody.position, targetPosition, moveSpeed * Time.deltaTime));

        if(Vector3.Distance(_rigidbody.position, targetPosition) < 0.01f)
        {
            if(targetIndex == 0) direction = 1;
            else if(targetIndex == lastIndex) direction = -1;

            targetIndex += direction;

            targetPosition = movePosition[targetIndex];
        }

    }
}
