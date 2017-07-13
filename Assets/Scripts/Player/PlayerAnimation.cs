using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    Animator animator;

	void Awake () {
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        animator.SetBool("IsRunning", (PlayerInput.movementVertical != 0f || PlayerInput.movementHorizontal != 0f));

        animator.SetBool("RunningUp", PlayerInput.movementVertical > .1f);

        animator.SetBool("RunningVertical", PlayerInput.movementVertical < -.1f);

        animator.SetBool("RunningRight", PlayerInput.movementHorizontal > .1f);

        animator.SetBool("RunningLeft", PlayerInput.movementHorizontal < -.1f);
    }
}
