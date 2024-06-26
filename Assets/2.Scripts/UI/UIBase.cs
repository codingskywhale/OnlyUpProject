using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIBase : MonoBehaviour
{
    public UnityAction<object[]> opened;
    public UnityAction<object[]> closed;

    private void Awake()
    {
        opened = OnOpened;
        closed = OnClosed;
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public virtual void HideDirect() { }

    public virtual void OnOpened(object[] param) { }
    public virtual void OnClosed(object[] param) { }
}
