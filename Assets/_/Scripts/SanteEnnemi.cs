
using UnityEngine;
using System.Collections;

public class SanteEnnemi : MonoBehaviour
{
    public int vieMaximale = 100;
    private int vieActuelle = 8;

    // animation

    private FlashEnnemi flashEnnemi;

    public GameObject panneauDialogue;
    public TMPro.TMP_Text texteDialogue;

    private void Awake()
    {
        flashEnnemi = GetComponent<FlashEnnemi>();
    }

    private void Start()
    {
        vieActuelle = vieMaximale;
    }

    public void RecevoirDegats(int degats)
    {
        vieActuelle -= degats;

        if (flashEnnemi != null)
        {
            flashEnnemi.JouerFlash();
        }

        Debug.Log("Vie de l'ennemi : " + vieActuelle);

        if (vieActuelle <= 0)
        {
            Mourir();
        }
    }

    private void Mourir()
    {
        Debug.Log("L'ennemi est vaincu !");

        NPCFollower poursuivant = GetComponent<NPCFollower>();

        if (poursuivant != null)
        {
            poursuivant.enabled = false;
        }

        if (panneauDialogue != null && texteDialogue != null)
        {
            panneauDialogue.SetActive(true);

            texteDialogue.text = "Argh... Tu m'as eu! Mais il est déjà trop tard! Mon boss avait prévu que quelqu'un tenterait de saboter son plan. J'ai donc programmé un mécanisme de sécurité... Dans 60 secondes, la bombe explosera! AHAHAHAHA! Tu penses que tu peux l'arrêter ? Écoute bien: Du plus chaud au plus froid... C'est tout ce que je peux dire!";
        }

        StartCoroutine(DisparaitreApresDialogue());
    }

    private IEnumerator DisparaitreApresDialogue()
{
    yield return new WaitForSeconds(10f);

    if (panneauDialogue != null)
    {
        panneauDialogue.SetActive(false);
    }

    // Déclenche l'animation Die
    Destroy(gameObject);
}
}
