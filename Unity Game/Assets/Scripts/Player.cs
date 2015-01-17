using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3,5);
	public bool standing;
	public float jumpSpeed = 15f;

	private Animator animator;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		var forceX = 0f;
		var forceY = 0f;

		var absVelX = Mathf.Abs (rigidbody2D.velocity.x);
		var absVelY = Mathf.Abs (rigidbody2D.velocity.y);

		if(absVelY < .2f){
			standing = true;
		} else {
			standing = false;
		}

		if (Input.GetKey ("up")) {
			animator.SetInteger("AnimState", 2);
		}

		else if (Input.GetKey ("right")) {
			if(absVelX < maxVelocity.x)
				forceX = speed;
			// Flipping player back and forth
			transform.localScale = new Vector3(1,1,1);
			
			animator.SetInteger("AnimState", 1);
		} else if(Input.GetKey("left") ) { 
			if(absVelX < maxVelocity.x)
				forceX = -speed;
			transform.localScale = new Vector3(-1,1,1);
			
			animator.SetInteger("AnimState", 1);
		} else{
			animator.SetInteger("AnimState", 0);
		}

		if(Input.GetKey("up")){
			if(absVelY < maxVelocity.y)
				forceY = jumpSpeed;
		}
		rigidbody2D.AddForce(new Vector2(forceX, forceY));
	
	}
}
