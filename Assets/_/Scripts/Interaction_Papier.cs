using UnityEngine.InputSystem;
using UnityEngine;
using StarterAssets;

public class InteractionPapier : MonoBehaviour
{
    public GameObject interactionPrompt;
    public GameObject documentPanel;
    public GameObject questHUD;

    public FirstPersonController playerController;

    private bool joueurProche = false;
    private bool documentOuvert = false;

    void Update()
    {
        if (joueurProche && !documentOuvert &&
    Keyboard.current != null &&
    Keyboard.current.eKey.wasPressedThisFrame)
{
    OuvrirDocument();
}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            joueurProche = true;
            interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            joueurProche = false;
            interactionPrompt.SetActive(false);
        }
    }

    void OuvrirDocument()
    {
        documentOuvert = true;
        documentPanel.SetActive(true);
        interactionPrompt.SetActive(false);

        playerController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void FermerDocument()
    {
        documentOuvert = false;
        documentPanel.SetActive(false);

        playerController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        questHUD.SetActive(true);
    }
}


