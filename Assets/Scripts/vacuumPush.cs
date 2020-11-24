using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.SceneManagement;
using System;

public class vacuumPush : MonoBehaviour
{
    [SerializeField] AudioSource vacuumOut;

    private CharacterController character;

    public string GhostTag;

    public float pushOut = 1.0f;

    public Rig vacuumRig;

    private Rigidbody rb;

    public ParticleSystem vacuumOutparticle;
    public List<ParticleCollisionEvent> collisionEvents;

    Animator anim;
    float amount;

    private void Start()
    {
        character = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        vacuumOutparticle = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        rb = GetComponent<Rigidbody>();
        vacuumOut = GetComponent<AudioSource>();
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("collided " + gameObject.name);
    }
    private void Update()
    {
        //reset the level
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

        //blowing air out to push objects forward
        if (Input.GetKeyDown(KeyCode.K))
        {
            vacuumOutparticle.Play();
            vacuumOut.Play();
            rb.AddForce(transform.forward * pushOut);
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            vacuumOutparticle.Stop();
            vacuumOut.Stop();
        }
    }
}
