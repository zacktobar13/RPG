using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    Text destinationText;

    public string destination;

    void Awake()
    {
        destinationText = GetComponentInChildren<Text>();
    }

    void Start()
    {
        destinationText.text = destination;
    }

    /// <summary>
    /// Sets destination to a specific target and updates the portals UI text to display the
    /// correct destination.
    /// </summary>
    /// <param name="dest"></param>
    public void SetDestination(string dest)
    {
        destination = dest;
        destinationText.text = destination;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PortToDestination();
        }
    }

    void PortToDestination()
    {
        SceneManager.LoadSceneAsync(destination);
    }
}
