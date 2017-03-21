using UnityEngine;

public class SpriteEnableLighting : MonoBehaviour {

	SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}
	void Start() {
		spriteRenderer.receiveShadows = true;
		spriteRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
	}
}
