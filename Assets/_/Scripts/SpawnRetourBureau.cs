
using UnityEngine;

public class SpawnRetourBureau : MonoBehaviour
{
    private void Start()
    {
        if (RetourScene1.retourDepuisBureau)
        {
            GameObject point = GameObject.Find("PointRetourBureau");

            if (point != null)
            {
                CharacterController controleur =
                    GetComponentInChildren<CharacterController>();

                if (controleur != null)
                    controleur.enabled = false;

                transform.position = point.transform.position;
                transform.rotation = point.transform.rotation;

                if (controleur != null)
                    controleur.enabled = true;

                RetourScene1.retourDepuisBureau = false;

                Debug.Log("Joueur replacé devant la porte !");
            }
            else
            {
                Debug.LogError("PointRetourBureau introuvable !");
            }
        }
    }
}

