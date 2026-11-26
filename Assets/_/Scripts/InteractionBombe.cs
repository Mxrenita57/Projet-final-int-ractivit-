
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionBombe : MonoBehaviour
{
    public GameObject panneauBombe;
    public Transform joueur;
    public float distanceInteraction = 3f;

    private bool miniJeuOuvert = false;

    void Update()
    {
        if (joueur == null || panneauBombe == null)
            return;

        float distance = Vector3.Distance(
            transform.position,
            joueur.position
        );

        if (distance <= distanceInteraction &&
            Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            miniJeuOuvert = !miniJeuOuvert;
            panneauBombe.SetActive(miniJeuOuvert);

            Cursor.visible = miniJeuOuvert;
            Cursor.lockState = miniJeuOuvert
                ? CursorLockMode.None
                : CursorLockMode.Locked;
        }
    }
}

