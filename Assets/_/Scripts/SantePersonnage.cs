
using UnityEngine;
using UnityEngine.UI;

public class SantePersonnage : MonoBehaviour
{
    [Header("Points de vie")]
    public int vieMaximale = 100;
    public int vieActuelle = 100;

    [Header("Degats")]
    public int degatsParCoup = 5;

    [Header("Interface")]
    public Slider barreDeVie;

    [Header("Effet visuel")]
    public EffetDegats effetDegats;

    private void Start()
    {
        vieActuelle = vieMaximale;

        if (barreDeVie != null)
        {
            barreDeVie.maxValue = vieMaximale;
            barreDeVie.value = vieActuelle;
            barreDeVie.gameObject.SetActive(false);
        }
    }

    public void RecevoirDegats(int degats)
    {
        vieActuelle = Mathf.Max(0, vieActuelle - degats);

        if (barreDeVie != null)
        {
            barreDeVie.gameObject.SetActive(true);
            barreDeVie.value = vieActuelle;
        }

        if (effetDegats != null)
        {
            effetDegats.JouerFlash();
        }

        Debug.Log("Vie restante : " + vieActuelle);

        if (vieActuelle <= 0)
        {
            Debug.Log("Le joueur est mort !");
        }
    }

    public void RecevoirDegatsAttaque()
    {
        RecevoirDegats(degatsParCoup);
    }
}

