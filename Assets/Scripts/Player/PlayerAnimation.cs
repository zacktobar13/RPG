using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    Animator animator;

	void Awake () {
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        animator.SetBool("IsRunning", (PlayerInput.movementVertical != 0f || PlayerInput.movementHorizontal != 0f));

        animator.SetBool("RunningVertical", Mathf.Abs(PlayerInput.movementVertical) > .1f);

        animator.SetBool("RunningRight", PlayerInput.movementHorizontal > .1f);
    }
}
