using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class vacuumPull : MonoBehaviour
{
    [SerializeField] AudioSource vacuumIn = null;

    private CharacterController character;

    public string GhostTag;

    public Rig vacuumRig;

    private Rigidbody rb;

    public ParticleSystem vacuumInparticle;
    public List<ParticleCollisionEvent> collisionEvents;

    public float pullIn = 1.0f;

    Animator anim;

    void Start()
    {
        character = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        vacuumInparticle = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        rb = GetComponent<Rigidbody>();
        vacuumIn = GetComponent<AudioSource>();
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("collided " + gameObject.name);
        Vector3 direction = gameObject.transform.position - transform.position;
        rb.AddForce(transform.position.z * direction);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        //air pulls in objects
        if (Input.GetKeyDown(KeyCode.J))
        {
            vacuumInparticle.Play();
            vacuumIn.Play();
            //rb.AddForce(transform.position - transform.position);
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            vacuumInparticle.Stop();
            vacuumIn.Stop();
        }
    }
}
