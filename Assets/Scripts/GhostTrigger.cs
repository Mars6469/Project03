using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrigger : MonoBehaviour
{
    private vacuumPull pull;
    private vacuumPush push;

    private void Start()
    {
        pull = FindObjectOfType<vacuumPull>();
        push = FindObjectOfType<vacuumPush>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost") && !pull)
            if (pull.ghost != other.GetComponent<Ghost>())
                pull.ghost = other.GetComponent<Ghost>();

        if (other.CompareTag("Ghost") && !push)
            if (push.ghost != other.GetComponent<Ghost>())
                push.ghost = other.GetComponent<Ghost>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ghost") && !pull)
            pull.ghost = null;

        if (other.CompareTag("Ghost") && !push)
            push.ghost = null;
    }
}
