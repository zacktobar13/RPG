using UnityEngine;
using Rewired;

public class PlayerInput : MonoBehaviour {

    [HideInInspector]
    public int playerId = 0; // The Rewired player id of this character
    private Player player; // The Rewired Player

    public static float movementHorizontal = 0f;
    public static float movementVertical = 0f;
    public static float attackHorizontal = 0f;
    public static float attackVertical = 0f;

    public static bool castPortal = false;

    // Use this for initialization
    void Awake () {
        player = ReInput.players.GetPlayer(playerId);
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        movementHorizontal = player.GetAxis("Move Horizontal");
        movementVertical = player.GetAxis("Move Vertical");

        attackHorizontal = player.GetAxis("Attack Horizontal");
        attackVertical = player.GetAxis("Attack Vertical");

        castPortal = player.GetButtonDown("Cast Portal");
    }
}
