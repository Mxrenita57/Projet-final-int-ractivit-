
using System.Collections;
using UnityEngine;

public class DeclencheurCutscene : MonoBehaviour
{
    [Header("Elements de la cinematique")]
    public GameObject cameraCutscene;
    public GameObject dialoguePanel;

    [Header("Duree du dialogue")]
    public float dialogueDuration = 5f;

    private bool cutsceneDeclenchee = false;

    private void Start()
    {
        if (cameraCutscene != null)
            cameraCutscene.SetActive(false);

        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (cutsceneDeclenchee) return;

        if (other.CompareTag("Player"))
        {
            cutsceneDeclenchee = true;
            StartCoroutine(JouerCutscene());
        }
    }

    private IEnumerator JouerCutscene()
    {
        if (cameraCutscene != null)
            cameraCutscene.SetActive(true);

        if (dialoguePanel != null)
            dialoguePanel.SetActive(true);

        yield return new WaitForSeconds(dialogueDuration);

        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);

        if (cameraCutscene != null)
            cameraCutscene.SetActive(false);
    }
}
