using UnityEngine;
using UnityEngine.SceneManagement;

public class AbilityPortal : MonoBehaviour {

    public GameObject portal;
    GameObject currentPortal = null;
    string currentSceneName;
    public float portalDistance;

    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.activeSceneChanged += ActiveSceneChanged;
    }

    void ActiveSceneChanged(Scene previousScene, Scene currentScene)
    {
        currentSceneName = currentScene.name;
    }

    void Update()
    {
        if (PlayerInput.castPortal)
        {
            CastPortal();
        }
    }

    void CastPortal()
    {
        if (currentSceneName == SceneNames.HomeBase)
        {
            return;
        }

        if (currentPortal != null)
        {
            Destroy(currentPortal);
        }

        currentPortal = Instantiate(portal, new Vector3(transform.position.x, transform.position.y + portalDistance, transform.position.z), Quaternion.identity);
        currentPortal.GetComponent<Portal>().SetDestination(SceneNames.HomeBase);
    }
}
