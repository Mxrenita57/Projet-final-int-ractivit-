
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MinuteurBombe : MonoBehaviour
{
    public TMP_Text texteMinuteur;
    public float tempsInitial = 60f;

    private float tempsRestant;
    private bool actif = false;

    void Start()
    {
        tempsRestant = tempsInitial;
        ActualiserAffichage();
    }

    void Update()
    {
        if (!actif) return;

        tempsRestant -= Time.deltaTime;

        if (tempsRestant <= 0)
        {
            tempsRestant = 0;
            ActualiserAffichage();
            SceneManager.LoadScene("Échec");
            actif = false;
            return;
        }

        ActualiserAffichage();
    }

    public void DemarrerMinuteur()
    {
        tempsRestant = tempsInitial;
        actif = true;
        ActualiserAffichage();
    }

    private void ActualiserAffichage()
    {
        if (texteMinuteur != null)
        {
            int secondes = Mathf.CeilToInt(tempsRestant);
            texteMinuteur.text = "BOMBE : 00:" + secondes.ToString("00");
        }
    }

    public void ArreterMinuteur()
    {
        actif = false;
    }
}

