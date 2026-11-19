
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetourScene1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Quelque chose est entré dans le déclencheur : " + other.name);

        if (other.transform.root.CompareTag("Player"))
        {
            Debug.Log("Objet détecté : " + other.name);
Debug.Log("Tag de l'objet : " + other.tag);
Debug.Log("Parent le plus haut : " + other.transform.root.name);
Debug.Log("Tag du parent : " + other.transform.root.tag);
        }
    }
}




