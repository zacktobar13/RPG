using UnityEngine;
using UnityEngine.SceneManagement;

public class AbilityPortal : MonoBehaviour {

    public GameObject portal;
    GameObject currentPortal = null;
    string currentSceneName;

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
        if (Input.GetButtonDown("CastPortal"))
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

        currentPortal = Instantiate(portal, new Vector3(transform.position.x, transform.position.y, transform.position.z + 4), Quaternion.identity);
        currentPortal.GetComponent<Portal>().SetDestination(SceneNames.HomeBase);
    }
}
