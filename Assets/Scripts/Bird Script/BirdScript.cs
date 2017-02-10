using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class BirdScript : MonoBehaviour {

	public static BirdScript instance;

	[HideInInspector]
	public bool isAlive;
	[HideInInspector]
	public int score;

	[Header ("Debug Menu")]
	public bool isInvincible = false;

	[Header ("Speed Control")]
	[SerializeField]
	private float forwardSpeed = 3f;
	[SerializeField]
	private float bounceSpeed = 4f;
	
	private bool didFlap;
	
	private Rigidbody2D myRigidBody;
	private Animator anim;

	public float GetPositionX () {
		return transform.position.x;
	}
	
	public void FlapTheBird() {
		didFlap = true;
	}
	
	void Awake () {
		
		InitInstance ();
		InitBird ();
		SetCameraOffset ();
	}
	
	private void InitInstance () {
		if (instance == null) {
			instance = this;
		}
	}
	
	private void InitBird () {
		isAlive = true;
		myRigidBody = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
	}
	
	private void SetCameraOffset () {
		CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1;
	}
	
	void FixedUpdate () {
		
		if (!isAlive) {
			return;
		}
		
		MoveForward ();
		Bounce ();
		Tilt ();
	}

	private void MoveForward () {
		
		Vector3 temp = transform.position;
		temp.x += forwardSpeed * Time.deltaTime;
		transform.position = temp;
	}
	
	private void Bounce () {
		if (!didFlap) {
			return;
		}
		
		didFlap = false;
		
		myRigidBody.velocity = new Vector2(0, bounceSpeed);
		TriggerFlapAnimation();
	}
		
	private void TriggerFlapAnimation () {
		anim.SetTrigger("Flap");
	}
	
	private void Tilt () {
		float angle = 0;
		
		if (myRigidBody.velocity.y < 0) {
			angle = Mathf.Lerp (0, -90, -myRigidBody.velocity.y/7);
		}
		
		transform.rotation = Quaternion.Euler (0, 0, angle);
	}
	
	void OnCollisionEnter2D (Collision2D target) {
		
		if (!IsCollisionTarget (target.gameObject)) {
			return;
		}
		
		if (isAlive) {
			KillBird ();
		}
		
	}
	
	private bool IsCollisionTarget (GameObject target) {
		return target.tag == "Ground" || 
			target.tag == "Pipe";
	}
	
	private void KillBird () {
		if (isInvincible)
			return;
		
		
		isAlive = false;
		TriggerDeathAnimation ();
		GameplayController.instance.GameoverShowPanel ();
	}


	private void TriggerDeathAnimation () {
	}
	
	void OnTriggerEnter2D (Collider2D target) {
		
		if (!IsPipeGap (target.gameObject)) {
			return;
		}
		
		Score ();
	}
	
	private bool IsPipeGap (GameObject target) {
		return target.tag == "PipeHolder";
	}

	private void Score () {
		score++;
		GameplayController.instance.SetScore (score);
	}
	
}
