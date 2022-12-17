using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float walkingMuscleForce;
    public float jumpingMuscleForce;
    private int cannotDoubleJump;
    public bool isCurrentlyColliding;
    // Start is called before the first frame update
    void Start()
    {
 
        myRigidbody.gravityScale = 10;
        myRigidbody.freezeRotation = true;
        walkingMuscleForce = 5;
        jumpingMuscleForce = 40;

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.D) == true)
        {
            myRigidbody.velocity = Vector2.right * walkingMuscleForce;
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            myRigidbody.velocity = Vector2.left * walkingMuscleForce;
        }
        if (isCurrentlyColliding == false)
        {
            if (Input.GetKeyDown(KeyCode.W) == true)
            {
                myRigidbody.velocity = Vector2.up * jumpingMuscleForce;
                cannotDoubleJump++;
            }
        }

    }
    void OnCollisionStay(Collision collisionInfo)
    {
        // Debug-draw all contact points and normals
        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
        }
    }
}
