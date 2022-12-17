using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float walkingMuscleForce;
    public float jumpingMuscleForce;
   
    public bool isCurrentlyColliding;
    public float walking_multiplier;
    public float jumping_multiplier;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Patapon";
        myRigidbody.gravityScale = 10;
        myRigidbody.freezeRotation = true;
        walkingMuscleForce = 5;
        jumpingMuscleForce = 40;
        walking_multiplier = 0.1f;
        jumping_multiplier = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.D) == true)
        {
            myRigidbody.velocity += Vector2.right * walkingMuscleForce* walking_multiplier;
        
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            myRigidbody.velocity += Vector2.left * walkingMuscleForce * walking_multiplier;
            
        
        }
        
        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            if (grounded)
            {
              myRigidbody.velocity += Vector2.up * jumpingMuscleForce * jumping_multiplier;
                Debug.Log("does the code even reach here?");
            }
              
        }
        

    }
    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        // Debug-draw all contact points and normals
       
        
            grounded = true;
    
            
        
    }
    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        grounded = false;
    }
}
