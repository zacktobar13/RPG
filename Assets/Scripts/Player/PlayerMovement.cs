using UnityEngine;
using Rewired;

/** This class reaches out to the Player Input game object and applies basic movement
  * based off of that. The names and properties of our Input axes and buttons are found in
  * Edit >> Project Settings >> Input. */

public class PlayerMovement : MonoBehaviour
{
   
    [SerializeField]
    float movementSpeed;

    float upDown;
    float leftRight;

    Vector3 xVelocity;
    Vector3 yVelocity;
    Vector3 previous;

    CharacterStats characterStats;

    void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        // Known problem: can't go slower than full speed
        Vector3 movement = new Vector3(PlayerInput.movementHorizontal, PlayerInput.movementVertical, 0f);
        movement = movement.normalized * Time.deltaTime * movementSpeed;
        transform.Translate(movement);

        // Capturing movement stats and sending it to CharacterStats component.
        xVelocity.x = (transform.position.x - previous.x) / Time.deltaTime;
        yVelocity.y = (transform.position.y - previous.y) / Time.deltaTime;
        previous = transform.position;

        // Debugging
        characterStats.xVelocity = xVelocity.x;
        characterStats.yVelocity = yVelocity.y;

        UpdateDirection();
    }

    // First determine which axis is receiving a greater value of input. Then, determine which
    // polarity (left/right, up/down), is occuring within that axis for proper direction handling.
    void UpdateDirection()
    {
        if (Mathf.Abs(yVelocity.y) >= Mathf.Abs(xVelocity.x))
        {
            if (yVelocity.y >= .01f)
            {
                characterStats.ChangeCharacterDirection(CharacterStats.CharacterDirection.Up);
            }
            else if (yVelocity.y <= -.01f)
            {
                characterStats.ChangeCharacterDirection(CharacterStats.CharacterDirection.Down);
            }
        }
        else
        {
            if (xVelocity.x >= .01f)
            {
                characterStats.ChangeCharacterDirection(CharacterStats.CharacterDirection.Right);
            }
            else if (xVelocity.x <= -.01f)
            {
                characterStats.ChangeCharacterDirection(CharacterStats.CharacterDirection.Left);
            }
        }
    }
}
