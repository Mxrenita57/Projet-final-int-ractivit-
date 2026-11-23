
using UnityEngine;

public class DegatsHitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SantePersonnage sante = other.GetComponent<SantePersonnage>();

            if (sante == null)
            {
                sante = other.GetComponentInParent<SantePersonnage>();
            }

            if (sante != null)
            {
                sante.RecevoirDegatsAttaque();
            }
        }
    }
}
