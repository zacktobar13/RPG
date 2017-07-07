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
    Vector3 zVelocity;
    Vector3 previous;

    CharacterStats characterStats;

    void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        // Actual movement
        transform.Translate(Vector3.forward * PlayerInput.movementVertical * movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * PlayerInput.movementHorizontal * movementSpeed * Time.deltaTime);

        // Capturing movement stats and sending it to CharacterStats component.
        xVelocity.x = (transform.position.x - previous.x) / Time.deltaTime;
        zVelocity.z = (transform.position.z - previous.z) / Time.deltaTime;
        previous = transform.position;

        characterStats.xVelocity = xVelocity.x;
        characterStats.zVelocity = zVelocity.z;

        UpdateDirection();
    }

    // First determine which axis is receiving a greater value of input. Then, determine which
    // polarity (left/right, up/down), is occuring within that axis for proper direction handling.
    void UpdateDirection()
    {
        if (Mathf.Abs(zVelocity.z) >= Mathf.Abs(xVelocity.x))
        {
            if (zVelocity.z >= .01f)
            {
                characterStats.ChangeCharacterDirection(CharacterStats.CharacterDirection.Up);
            }
            else if (zVelocity.z <= -.01f)
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
