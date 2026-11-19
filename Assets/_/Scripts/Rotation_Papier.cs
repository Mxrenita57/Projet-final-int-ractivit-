using UnityEngine;

public class RotationPapier : MonoBehaviour
{
    public float vitesseRotation = 50f;

    void Update()
    {
        transform.Rotate(0f, vitesseRotation * Time.deltaTime, 0f);
    }
}

