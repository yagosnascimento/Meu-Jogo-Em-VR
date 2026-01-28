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
            ScoreManager.instance.AddScore(pontosAcerto);
            Debug.Log("ACERTO");
        }
        else
        {
            ScoreManager.instance.AddScore(pontosErro);
            Debug.Log("ERRO");
        }

        Destroy(other.gameObject);
    }
}
