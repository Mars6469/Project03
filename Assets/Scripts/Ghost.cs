using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    vacuumPush vc;

    public bool pullIn;
    public bool pushOut;

    private void Start()
    {
        vc = FindObjectOfType<vacuumPush>();
    }

    public void ActivatebeingPulled()
    {
        transform.rotation = vc.transform.rotation;
    }

    public void ActivatebeingPushed()
    {
        transform.rotation = vc.transform.rotation;
    }
}
