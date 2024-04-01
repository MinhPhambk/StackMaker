using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IObject : MonoBehaviour
{
    protected Vector3 brickSizeY;

    void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        brickSizeY = new Vector3(0, 0.25f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnTrigger(other);
    }

    protected abstract void OnTrigger(Collider other);

    protected abstract void SetPlayerPosition(Collider other);
}
