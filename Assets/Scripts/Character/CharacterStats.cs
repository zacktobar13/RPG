using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public enum CharacterType
    {
        Player,
        NPC,
        Enemy
    }

    public enum CharacterClass
    {
        Warrior
    }

    public enum CharacterDirection
    {
        Down,
        Left,
        Up,
        Right
    }

    public CharacterType characterType;
    public CharacterClass characterClass;
    public CharacterDirection characterDirection;

    [HideInInspector]
    public float xVelocity;
    [HideInInspector]
    public float yVelocity;

    [HideInInspector]
    public string nameInHierarchy;

    void Start()
    {
        nameInHierarchy = gameObject.name;
    }

    // Changes current characterDirection and refreshes static info in debug menu.
    public void ChangeCharacterDirection(CharacterDirection direction)
    {
        characterDirection = direction;
    }
}
