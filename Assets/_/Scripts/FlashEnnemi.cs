using UnityEngine;
using System.Collections;

public class FlashEnnemi : MonoBehaviour
{
    private Renderer[] renderers;
    private MaterialPropertyBlock[][] blocsOriginaux;
    private int[][] proprietesCouleur;

    private Coroutine flashCoroutine;

    private void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();

        blocsOriginaux = new MaterialPropertyBlock[renderers.Length][];
        proprietesCouleur = new int[renderers.Length][];

        for (int i = 0; i < renderers.Length; i++)
        {
            Material[] materiaux = renderers[i].sharedMaterials;

            blocsOriginaux[i] = new MaterialPropertyBlock[materiaux.Length];
            proprietesCouleur[i] = new int[materiaux.Length];

            for (int j = 0; j < materiaux.Length; j++)
            {
                MaterialPropertyBlock bloc = new MaterialPropertyBlock();
                renderers[i].GetPropertyBlock(bloc, j);
                blocsOriginaux[i][j] = bloc;

                if (materiaux[j].HasProperty("_BaseColor"))
                    proprietesCouleur[i][j] = Shader.PropertyToID("_BaseColor");
                else if (materiaux[j].HasProperty("_Color"))
                    proprietesCouleur[i][j] = Shader.PropertyToID("_Color");
            }
        }
    }

    public void JouerFlash()
    {
        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine);

        flashCoroutine = StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            for (int j = 0; j < proprietesCouleur[i].Length; j++)
            {
                if (proprietesCouleur[i][j] == 0)
                    continue;

                MaterialPropertyBlock bloc = new MaterialPropertyBlock();
                renderers[i].GetPropertyBlock(bloc, j);
                bloc.SetColor(proprietesCouleur[i][j], Color.red);
                renderers[i].SetPropertyBlock(bloc, j);
            }
        }

        yield return new WaitForSeconds(0.15f);

        for (int i = 0; i < renderers.Length; i++)
        {
            for (int j = 0; j < blocsOriginaux[i].Length; j++)
            {
                renderers[i].SetPropertyBlock(blocsOriginaux[i][j], j);
            }
        }

        flashCoroutine = null;
    }
}