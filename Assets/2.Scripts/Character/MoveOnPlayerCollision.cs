using UnityEngine;

public class MoveOnPlayerCollision : MonoBehaviour
{
    public GameObject object1;

    public Vector3 moveDirection = Vector3.up;
    public float moveSpeed = 5f;

    private bool CanMove = false;

    private void Update()
    {
        if(CanMove)
        {
            object1.transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CanMove = true;
        }
    }
}
