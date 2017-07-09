using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    Animator animator;

	void Awake () {
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        animator.SetFloat("Movement Blend", Mathf.Abs(PlayerInput.movementHorizontal));
    }
}
