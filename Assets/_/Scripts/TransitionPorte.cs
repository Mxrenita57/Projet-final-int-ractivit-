using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{
    private bool hasTransitioned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTransitioned)
            return;

        if (other.CompareTag("Player"))
        {
            hasTransitioned = true;

            SceneManager.LoadScene("Bureau");
        }
    }
}
