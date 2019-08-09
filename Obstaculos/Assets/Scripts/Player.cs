using UnityEngine;

public class Player : MonoBehaviour
{
	private Animator animator;

    private Grabber grabber;

	void Awake ()
	{
		animator = GetComponent<Animator>();
        grabber = GetComponent<Grabber>();
	}

	void Update ()
	{
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		Vector3 movementForward = Vector3.Scale (Camera.main.transform.forward, new Vector3 (1, 0, 1)).normalized;
		Vector3 movementRight = Camera.main.transform.right;

        // Rotating
		if (h != 0 || v != 0)
			transform.forward = h * movementRight + v * movementForward;

        // Moving
		animator.SetFloat ("speed", Mathf.Max (Mathf.Abs (h), Mathf.Abs (v)));

        // Crouching
        animator.SetFloat("crouching", Input.GetKey(KeyCode.LeftShift) ? 1 : 0);

        // Jumping
        if (Input.GetKeyDown (KeyCode.Z) && OnGround())
        {
            animator.SetTrigger("jump");
        }

        // Attacking
        if (Input.GetKeyDown (KeyCode.X))
        {
            animator.SetInteger("attackType", 0);
            animator.SetTrigger("attack");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetInteger("attackType", 1);
            animator.SetTrigger("attack");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            animator.SetInteger("attackType", 2);
            animator.SetTrigger("attack");
        }

        // Grab item
        grabber.Grab();
    }

    bool OnGround ()
    {
        return Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out RaycastHit hitInfo, 0.2f);
    }
}