using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScenes : MonoBehaviour
{
    public void AllerAccueil()
    {
        SceneManager.LoadScene("Accueil");
    }

    public void AllerNiveau1()
{
    SceneManager.LoadScene("Scène01");
}

public void QuitterJeu()
{
    Application.Quit();
}
}