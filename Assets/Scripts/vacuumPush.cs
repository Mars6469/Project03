using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.SceneManagement;
using Cinemachine;
using System;

public class vacuumPush : MonoBehaviour
{
    public CinemachineVirtualCamera gameCamera;

    private CharacterController character;

    public string GhostTag;

    public float pushOut = 1.0f;

    public Ghost ghost;

    public Rig vacuumRig;

    private Vector3 axis;
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
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("collided " + gameObject.name);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

        if (Input.GetKeyDown(KeyCode.K))
        {
            vacuumOutparticle.Play();
            rb.AddForce(transform.forward * pushOut);
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            vacuumOutparticle.Stop();
        }
    }
}
