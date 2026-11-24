using UnityEngine;

public class AttaquePersonnage : MonoBehaviour
{
    public Camera cameraJoueur;
    public float porteeAttaque = 2f;
    public int degats = 8;
    public float delaiEntreAttaques = 0.7f;
private float prochaineAttaque = 0f;

    void Update()
    {
        if (UnityEngine.InputSystem.Keyboard.current != null &&
    UnityEngine.InputSystem.Keyboard.current.fKey.wasPressedThisFrame &&
    Time.time >= prochaineAttaque)
{
    Attaquer();
    prochaineAttaque = Time.time + delaiEntreAttaques;
}
    }

    void Attaquer()
    {
        RaycastHit hit;

        if (Physics.Raycast(cameraJoueur.transform.position,
            cameraJoueur.transform.forward,
            out hit, porteeAttaque))
        {
            SanteEnnemi ennemi = hit.collider.GetComponentInParent<SanteEnnemi>();

if (ennemi != null)
{
    ennemi.RecevoirDegats(degats);
}
        }
    }
}
