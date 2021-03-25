/*  # 1: Title: "2D Character Movement in Unity / 2021" | Author: Distorted Pixel Studios | Source: https://www.youtube.com/watch?v=n4N9VEA2GFo&list=WL&index=26&t=2s | Date retrieved: 1/29/2021 @ 7:30pm
    #
    # 
    # 2: Title: "HOLD JUMP KEY TO JUMP HIGHER - 2D PLATFORMER CONTROLLER - UNITY TUTORIAL" | Author: Blackthornprod | Source: https://www.youtube.com/watch?v=j111eKN8sJw&list=WL&index=28 | Date retrieved: 2/3/2021 @ 2:05pm
    #
    #
    # 3: Title: "2D Movement in Unity (Tutorial)" | Author: Brackeys | Source: https://www.youtube.com/watch?v=dwcT-Dch0bA&t=1036s, https://github.com/Brackeys/2D-Movement/blob/master/2D%20Movement/Assets/CharacterController2D.cs | Date retrieved: Date retrieved: 1/27/2021 @ 8:30pm
    #
    # 4: Title: "HOW TO MAKE A WORKING 2D MOVING PLATFORM-Unity Tutorial" | Author: bblakeyyy | Source: https://www.youtube.com/watch?v=Q8Lb9IhqY0s&list=WL&index=70 | Date retrieved: 2/11/2021 @ 10:00am
    #
    # 5: Title: "HOW TO MAKE 2D LADDERS IN UNITY - EASY TUTORIAL" | Author: Blackthornprod | Source: https://www.youtube.com/watch?v=Ln7nv-Y2tf4&list=WL&index=134 | Date retrieved: 3/14/2021 @ 1:00pm
    #
*/

// #2: ####################################################################################################################################################
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour{
    public ParticleSystem dust;
   public GameObject player;
   public Animator animator;
// #3: ####################################################################################################################################################
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;				// A collider that will be disabled when crouching

	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
// ####################################################################################################################################################

    private Rigidbody2D rb; // This variable will be used to refrence unity RigidBody2D  component
    public float speed; // Initializing how fast the player moves.
    public float jumpForce; //  Initializing the amount of force added when the player jumps.
    private float moveInput =36f; // This code detects Weather the user is holding down the left or right arrow keys.
    private bool isGrounded; // Checks if player is on the ground.
    public Transform feetPos; // This code will detect if the players feet is on the ground so it can jump.
    public float checkRadius; // This code just enables the  user to change how large they want the radius around the players feet to be.
    public LayerMask whatIsGround; //  Initializing what will be consider solid ground for the player to move on.
    private float jumpTimeCounter; // This code is used as a Increment of how many times the user jumps.
    public float jumpTime; //  Initializing the amount of pressure holding down the spacebar to make player jump higher.
    private bool isJumping = false; // Checks if player is jumping.
    public bool crouch; // Checks if player is crouching
    public EnemyAction enemy; // I referenced from the EnemyAction script
    public float distance; //This varaible will be used to determine how far the ray from the raycast will go 
    public LayerMask whatIsLadder; /* This will create a drop down menu in the inspector so that you can choose different layers
                                   also this will be how the ray can detect using the layers
                                   */
    private bool isClimbing; // Checks if player is climbing
    private float inputVertical; // This inputVertical variable will be used to detect weather player is holding up or down keys

    void Start(){
        rb = GetComponent<Rigidbody2D>(); //This line of code is just calling the Rigidbody2D Component which is attached to my player.
    }

    void FixedUpdate(){ // The FixedUpdate method is used to manipulate all physics aspects of the game

        moveInput = Input.GetAxisRaw("Horizontal"); // This line of code determines how the charater moves on the horizontal axis using the left & right arrow keys.
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); // This code implements movement to the player.

         // #5: ####################################################################################################################################################

        /*This line of code will shoot a invisible ray from the player to detect when it hits a object of layer "Ladder" and it then will allow 
        player to move up and down with arrow key on the ladder if object is of layer Ladder
        */
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if(hitInfo.collider != null){   /* This entire if statment is saying if ray has collided with layer of 
                                          ladder and if player is pressing up arrow key then player is climbing.
                                        */
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                isClimbing = true;
            }
        } 
        else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){ /*This else if statment is saying if
                                                                                               player get input from left or right key arrow then climbing ladder is false
                                                                                              */
            isClimbing = false;
            }
        

        /* 
        This block of code is saying if climbing is true and the ray
        from the raycaster hits layer of ladder then player can go up the ladder at a certain speed with a gravity of 0
        so player doesn't fall off while climbing and if player isn't climbing then gravity goes back to 15;
        */
        if(isClimbing == true && hitInfo.collider != null){
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
            rb.gravityScale = 0;
        }else{
           rb.gravityScale = 15;
        }
         // #5: ####################################################################################################################################################
    }

   // #3: ####################################################################################################################################################
        public void Move(float move, bool crouch, bool jump){
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, whatIsGround))
			{
				crouch = true;
			}
		}
        // If crouching
		if (crouch){
			// Reduce the speed by the crouchSpeed multiplier
			   move *= m_CrouchSpeed;

			    // Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} 
            else{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;
			}
    }
    // ####################################################################################################################################################
    
    void Update(){
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        
        if(moveInput > 0){ 
            transform.eulerAngles = new Vector3(0, 0, 0); // This code enables the player to face right when user is moving right.
        }
        else if(moveInput < 0){
            transform.eulerAngles = new Vector3(0, 180, 0); // This code enables the player to face left when user is moving left. 
        }else{
            FindObjectOfType<AudioManager>().Play("PlayerRun");
        }
        // #1: ####################################################################################################################################################
         if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f){ // This code enables the spacebar to activate chracter jump when pressed down.
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);// The code also stops charater from jumping Continuously in the air.
             animator.SetBool("IsJumping", true);
        //####################################################################################################################################################
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            CreateDust();
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true){ // This code checks how long the user is holding down the spacebar.

            if(jumpTimeCounter > 0){ // This if block is saying if jumpTimeCounter is greater than 0 then the player can keep jumping higher.
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;// Also this piece of code will The deincrement the jumpTimeCounter so that the player falls to the ground.
            }
            else{
                isJumping = false;
                animator.SetBool("IsJumping", false);
            }
        }

        if(Input.GetKeyUp(KeyCode.Space)){ // This if block just detects if the player is holding down on spacebar if not then player will not jump.
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }
        // #3: ####################################################################################################################################################
        if (Input.GetButtonDown("Crouch")){
			crouch = true;
		} 
        else if (Input.GetButtonUp("Crouch")){
			crouch = false;
		}
        // ####################################################################################################################################################
    }
    
     public void OnLanding () 
    {

        animator.SetBool("IsJumping", false);

    }

    // #4: ####################################################################################################################################################
        void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.CompareTag("Ground")) //this if block just makes sure once the player jumps in the air that it cant jump again.
            {
                isJumping = false;
            }

            if(other.gameObject.CompareTag("MGround")) //This if statement is just saying whenever the player collides with the object with tag MGround then player object will become a child of that object.
            {
                this.transform.parent = other.transform;
                isJumping = false;
            }
        }

      /*  void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "FallDetection")
            {
            SceneManager.LoadScene("IntroductoryLevelScene");
            }
        }*/

         void OnCollisionExit2D(Collision2D other) 
        {
            if(other.gameObject.CompareTag("Ground")) 
            {
                isJumping = true;
            }

            if(other.gameObject.CompareTag("MGround"))// This if block is saying once the player jumps from the game object tagged MGround that it will become its own parent again.
            {
                this.transform.parent = null;
                isJumping = true;
            }
        }

        void CreateDust()
    {
        dust.Play();
    }

}       // #4: ####################################################################################################################################################

// ####################################################################################################################################################