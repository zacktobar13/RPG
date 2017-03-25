using UnityEngine;

public class CharacterStats : MonoBehaviour {

	public enum CharacterType {
		Player,
		Enemy
	}

	public enum CharacterClass {
		Warrior
	}

	public CharacterType characterType;
	public CharacterClass characterClass;

	ObjectDebugGUI objectDebugGUI;

	[HideInInspector]
	public float xVelocity;
	[HideInInspector]
	public float zVelocity;

	//[HideInInspector]
	public bool selected = false;

	[SerializeField]
	int maxHealth;
	int currentHealth = 1;

	public string nameInHierarchy;

	void Awake() {
		objectDebugGUI = GameObject.FindGameObjectWithTag("Object Debug GUI").GetComponent<ObjectDebugGUI>();
	}

	void Start() {
		currentHealth = maxHealth;
		nameInHierarchy = gameObject.name;
	}

	void Update() {
		if (currentHealth <= 0) {
			Destroy(gameObject);
		}

		if (selected) {
			RefreshDebugGUI();
		}
	}

	void RefreshDebugGUI() {
		objectDebugGUI.UpdateVelocity(xVelocity, zVelocity);
	}
}
