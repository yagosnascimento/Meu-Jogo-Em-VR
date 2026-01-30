using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public GameObject objetoCorreto; // arraste o PREFAB correto aqui
    public int pontosAcerto = 10;
    public int pontosErro = -5;

    private void OnTriggerEnter(Collider other)
    {
        // compara o prefab pelo nome base (ignora "(Clone)")
        string nomeObjeto = other.gameObject.name.Replace("(Clone)", "");

        if (nomeObjeto == objetoCorreto.name)
        {
            // Adiciona 10 pontos e 5 segundos de bônus
            ScoreManager.instance.AddScore(10, 5f);
            Debug.Log("ACERTO");
        }
        else
        {
            // Adiciona 10 pontos e 5 segundos de bônus
            ScoreManager.instance.AddScore(-10, -5f);
            Debug.Log("ERRO");
        }

        // Dentro do seu OnTriggerEnter, quando o objeto for o correto:
        ScoreManager.instance.AddScore(10, 5f); // Adiciona 10 pontos e 5 segundos
        Destroy(other.gameObject);

        Destroy(other.gameObject);
    }
}
