using TMPro;
using UnityEngine;

public class DoorB : DoorBase
{
    [SerializeField]
    Transform door;

    [SerializeField]
    private bool isActivating;
    [SerializeField]
    private Quaternion closeRotation = Quaternion.identity;
    [SerializeField]
    private Quaternion openRotation = Quaternion.Euler(0f, 90f, 0f);
    private Quaternion targetRotation;

    //[SerializeField]
    //private AudioSource audioSource; // AudioSource ������Ʈ ����

    private void Start()
    {
        isActivating = false;
    }

    private void FixedUpdate()
    {
        if (isActivating)
        {
            float rotateSpeed = 90f * Time.deltaTime; // ȸ�� �ӵ� (��/��)
            door.localRotation = Quaternion.RotateTowards(door.localRotation, targetRotation, rotateSpeed);

            if (door.localRotation == targetRotation)
            {
                isActivating = false;
            }
        }
    }

    public override void Trigger()
    {
        isActivating = true;
        if (isOpened)
        {
            targetRotation = closeRotation;
        }
        else
        {
            targetRotation = openRotation;
        }
        isOpened = !isOpened;
        PlaySound();
    }
}
