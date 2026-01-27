using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public GameObject objetoAlvo; // Arraste o Prefab do Cubo/Triângulo aqui

    private void OnTriggerEnter(Collider other)
    {
        // Se o nome do que entrou começar com o nome do alvo (ex: Cubo)
        if (objetoAlvo != null && other.name.StartsWith(objetoAlvo.name))
        {
            ScoreManager.instance.AddScore(10);
            Destroy(other.gameObject); // Faz o objeto sumir
            Debug.Log("PONTO! Objeto correto.");
        }
    }
}