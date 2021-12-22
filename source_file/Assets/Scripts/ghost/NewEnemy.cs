using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class NewEnemy : MonoBehaviour {
	
	
	private Animator anim;
	//private CharacterController controller;
	private int battle_state = 0;
	public float speed = 6.0f;
	public float runSpeed = 3.0f;
	public float turnSpeed = 60.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	private float w_sp = 0.0f;
	private float r_sp = 0.0f;

	private GameObject m_camera;

	public GameObject bornpoint;

	
	// Use this for initialization
	void Start () 
	{						
		anim = GetComponent<Animator>();
		//controller = GetComponent<CharacterController> ();
		m_camera=GameObject.Find("FirstPersonCamera");
		w_sp = speed; //read walk speed
		r_sp = runSpeed; //read run speed
		battle_state = 0;
		runSpeed = 1;

	}
	
	// Update is called once per frame
	void Update () 
	{		
		roar();
		Invoke("walk",1.0f);

        anim.SetInteger ("moving", 1);
		// RotateCtrl();
		// if (Input.GetKey ("1"))  // turn to still state
		// { 		
		// 	anim.SetInteger ("battle", 0);
		// 	battle_state = 0;
		// 	runSpeed = 1;
		// }
		// if (Input.GetKey ("2")) // turn to battle state
		// { 
		// 	anim.SetInteger ("battle", 1);
		// 	battle_state = 1;
		// 	runSpeed = r_sp;
		// }
			
		// if (Input.GetKey ("up")) 
		// {
		// 	anim.SetInteger ("moving", 1);//walk/run/moving
		// }
		// else 
		// 	{
		// 		anim.SetInteger ("moving", 0);
		// 	}


		// if (Input.GetKey ("down")) //walkback
		// {
		// 	anim.SetInteger ("moving", 12);
		// 	runSpeed = 1;
		// }
		// if (Input.GetKeyUp ("down")) 
		// {
		// 	if (battle_state == 0) runSpeed = 1;
		// 	else if (battle_state >0) runSpeed = r_sp;
		// }
	
		// if (Input.GetMouseButtonDown (0)) { // attack1
		// 	anim.SetInteger ("moving", 2);
		// }
		// if (Input.GetMouseButtonDown (1)) { // attack2
		// 	anim.SetInteger ("moving", 3);
		// }
		// if (Input.GetMouseButtonDown (2)) { // attack3
		// 	anim.SetInteger ("moving", 4);
		// }
		// if (Input.GetKeyDown ("space")) { //jump
		// 	anim.SetInteger ("moving", 6);
		// }
		// if (Input.GetKeyDown ("c")) { //roar/howl
		// 	anim.SetInteger ("moving", 7);
		// }
		// if (Input.GetKeyDown ("y")) { //powerhit
		// 	anim.SetInteger ("battle", 1);
		// 	battle_state = 1;
		// 	runSpeed = r_sp;
		// 	anim.SetInteger ("moving", 5);
		// }


		
		// if (Input.GetKeyDown ("u")) //hit
		// { 			  
		// 	battle_state = 1;
		// 	runSpeed = r_sp;
		// 	anim.SetInteger ("battle", 1);
				
		// 	int n = Random.Range (0, 2);
		// 	if (n == 1) 
		// 		{
		// 			anim.SetInteger ("moving", 8);
		// 		} 
		// 	else 
		// 		{
		// 			anim.SetInteger ("moving", 9);
		// 		}
		// }

		// if (Input.GetKeyDown ("k")) { //rising
		// 	anim.SetInteger ("battle", 1);
		// 	battle_state = 1;
		// 	runSpeed = r_sp;
		// 	anim.SetInteger ("moving", 15);
		// }


		
		// if (Input.GetKeyDown ("i")) anim.SetInteger ("moving", 13); //die/fall
		// if (Input.GetKeyDown ("o")) anim.SetInteger ("moving", 14); //die2
		

		// if (controller.isGrounded) 
		// {
		// 	moveDirection=transform.forward * Input.GetAxis ("Vertical") * speed * runSpeed;
		// 	float turn = Input.GetAxis("Horizontal");
		// 	transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);						
		// }
		// moveDirection.y -= gravity * Time.deltaTime;
		// controller.Move (moveDirection * Time.deltaTime);
	}

	private void RotateCtrl() {
        Vector3 tempRot = m_camera.transform.position;
        tempRot.y = transform.position.y;
        Vector3 targetRot = transform.position - tempRot;
        transform.rotation = Quaternion.LookRotation(targetRot);
    }

	void roar(){
		anim.SetInteger ("moving", 7);
	}

	void walk(){
		anim.SetInteger ("moving", 1);
		gameObject.GetComponent<NavMeshAgent>().speed=1;
	}

	public void born(){
		gameObject.transform.position=bornpoint.transform.position;
	}
}



