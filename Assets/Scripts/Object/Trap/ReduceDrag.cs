using UnityEngine;

public class ReduceDrag : MonoBehaviour
{
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.drag = 0; // 공기 저항 최소화
        }
    }
}
