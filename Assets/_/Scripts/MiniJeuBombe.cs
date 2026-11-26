
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniJeuBombe : MonoBehaviour
{
    public TMP_Text texteResultat;

    private int etape = 0;

    public void ChoisirRouge()
    {
        if (etape == 0)
        {
            etape++;
            Afficher("Rouge : correct ! Choisis le jaune.");
        }
        else
        {
            Echec();
        }
    }

    public void ChoisirJaune()
    {
        if (etape == 1)
        {
            etape++;
            Afficher("Jaune : correct ! Choisis le bleu.");
        }
        else
        {
            Echec();
        }
    }

    public void ChoisirBleu()
    {
        if (etape == 2)
        {
            etape++;
            Afficher("BRAVO ! La bombe est désamorcée !");
            DesactiverBoutons();
        }
        else
        {
            Echec();
        }
    }

    private void Afficher(string message)
    {
        if (texteResultat != null)
            texteResultat.text = message;
    }

    private void Echec()
    {
        SceneManager.LoadScene("Échec");
    }

    private void DesactiverBoutons()
    {
        foreach (UnityEngine.UI.Button bouton in
                 GetComponentsInChildren<UnityEngine.UI.Button>())
        {
            bouton.interactable = false;
        }
    }
}

