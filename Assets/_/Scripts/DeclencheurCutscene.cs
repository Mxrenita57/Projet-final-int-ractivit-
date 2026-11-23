
using UnityEngine;

public class DeclencheurCutscene : MonoBehaviour
{
    [Header("Camera de cinematique")]
    public GameObject cameraCutscene;

    private bool cutsceneDeclenchee = false;

    private void Start()
    {
        if (cameraCutscene != null)
        {
            cameraCutscene.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (cutsceneDeclenchee) return;

        if (other.CompareTag("Player"))
        {
            cutsceneDeclenchee = true;

            if (cameraCutscene != null)
            {
                cameraCutscene.SetActive(true);
            }
        }
    }
}
