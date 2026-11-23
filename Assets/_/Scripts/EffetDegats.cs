
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EffetDegats : MonoBehaviour
{
    public Image flashRouge;
    public float dureeFlash = 0.2f;
    public float opaciteFlash = 0.45f;

    private Coroutine flashCoroutine;

    public void JouerFlash()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        flashCoroutine = StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        Color couleur = flashRouge.color;
        couleur.a = opaciteFlash;
        flashRouge.color = couleur;

        yield return new WaitForSeconds(dureeFlash);

        couleur.a = 0f;
        flashRouge.color = couleur;

        flashCoroutine = null;
    }
}
