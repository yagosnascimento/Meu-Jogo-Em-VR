using UnityEngine;

public class SlotScore : MonoBehaviour
{
    // Agora o campo aceita arrastar o Prefab ou Objeto
    public GameObject targetObject;

    private void OnTriggerEnter(Collider other)
    {
        // Verificamos se o nome do objeto que entrou começa com o nome do alvo
        // Isso ignora o "(Clone)" que o Unity adiciona ao spawnar
        if (other.name.StartsWith(targetObject.name))
        {
            ScoreManager.instance.AddScore(10);

            // Feedback visual: desativa o objeto que entrou
            other.gameObject.SetActive(false);

            Debug.Log("Objeto correto encaixado!");
        }
    }
}