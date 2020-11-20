using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Cinemachine;

public class vacuumPull : MonoBehaviour
{
    public CinemachineVirtualCamera gameCamera;

    private CharacterController character;

    public string GhostTag;

    public Ghost ghost;

    public Rig vacuumRig;

    private Vector3 axis;
    private Rigidbody rb;

    public ParticleSystem vacuumInparticle;
    public List<ParticleCollisionEvent> collisionEvents;

    public Transform pullIN;

    public float pullIn = -1.0f;

    Vector3 pullForce;

    public float positionDistanceThreshold;

    public float velocityDistanceThreshold;

    public float maxVelocity;

    Animator anim;
    float amount;

    void Start()
    {
        character = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        vacuumInparticle = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        rb = GetComponent<Rigidbody>();
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("collided " + gameObject.name);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            vacuumInparticle.Play();
            rb.AddForce(transform.forward * pullIn);
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            vacuumInparticle.Stop();
        }
    }

    /*
    void Update()
    {
        RaycastHit hit;
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            vacuumInparticle.Play();
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag.Equals(GhostTag))
                {
                    StartCoroutine(PullObject(hit.transform));
                }
            }
        }
    }

    IEnumerator PullObject(Transform t)
    {
        Rigidbody r = t.GetComponent<Rigidbody>();
        while (true)
        {
            if (Input.GetKeyUp(KeyCode.J))
            {
                break;
            }
        }

        float distanceToVacuum = Vector3.Distance(t.position, pullIN.position);

        Vector3 pullDirection = pullIN.position - t.position;

        pullForce = pullDirection.normalized * modifier;

        if (r.velocity.magnitude < maxVelocity && distanceToVacuum > velocityDistanceThreshold)
        {
            r.AddForce(pullForce, ForceMode.Force);
        } 
        else
        {
            r.velocity = pullDirection.normalized * maxVelocity;
        }

        yield return null;
    }*/
}
