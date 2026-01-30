using UnityEngine;

public class Destruidor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Tudo que tocar aqui "evapora"
        Destroy(other.gameObject);
        Debug.Log("Objeto descartado no fim da esteira.");
    }
}