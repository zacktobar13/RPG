using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    // Idle Animations
    public AnimationClip[,] idleAnimations = new AnimationClip[1,4];

    public AnimationClip idleLeft;
    public AnimationClip idleRight;
    public AnimationClip idleUp;
    public AnimationClip idleDown;

    public Animator animator;

    PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Use this for initialization
    void Start () {
        idleAnimations[0, 0] = idleLeft;
        idleAnimations[0, 1] = idleRight;
        idleAnimations[0, 2] = idleUp;
        idleAnimations[0, 3] = idleDown;
    }
	
	// Update is called once per frame
	void Update () {
       // animator.Play(idleAnimations[0, playerMovement.facing].ToString());
	}
}
