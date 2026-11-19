
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetourScene1 : MonoBehaviour
{
    public static bool retourDepuisBureau = false;

    private bool retourEffectue = false;

    private void OnTriggerEnter(Collider other)
    {
        if (retourEffectue)
            return;

        if (other.transform.root.CompareTag("Player"))
        {
            retourEffectue = true;
            retourDepuisBureau = true;

            SceneManager.LoadScene("Scène01");
        }
    }
}







