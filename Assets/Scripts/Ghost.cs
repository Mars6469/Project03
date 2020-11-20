using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    vacuumPush vc;
    Rotation rot;

    public bool pullIn;
    public bool pushOut;

    private void Start()
    {
        rot = GetComponent<Rotation>();
        vc = FindObjectOfType<vacuumPush>();
    }

    public void ActivatebeingPulled()
    {
        Destroy(rot);
        transform.rotation = vc.transform.rotation;
    }

    public void ActivatebeingPushed()
    {
        Destroy(rot);
        transform.rotation = vc.transform.rotation;
    }
}
