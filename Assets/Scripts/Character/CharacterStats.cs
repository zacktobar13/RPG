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

    ObjectDebugGUI objectDebugGUI;

    [HideInInspector]
    public float xVelocity;
    [HideInInspector]
    public float zVelocity;

    [HideInInspector]
    public bool selected = false;

    [HideInInspector]
    public string nameInHierarchy;

    void Awake()
    {
        objectDebugGUI = GameObject.FindGameObjectWithTag("Object Debug GUI").GetComponent<ObjectDebugGUI>();
    }

    void Start()
    {
        nameInHierarchy = gameObject.name;
    }

    void Update()
    {
        if (selected)
        {
            RefreshDebugGUI();
        }
    }

    void RefreshDebugGUI()
    {
        objectDebugGUI.UpdateVelocity(xVelocity, zVelocity);
    }

    // Changes current characterDirection and refreshes static info in debug menu.
    public void ChangeCharacterDirection(CharacterDirection direction)
    {
        characterDirection = direction;
        objectDebugGUI.UpdateStaticInfo();
    }
}
