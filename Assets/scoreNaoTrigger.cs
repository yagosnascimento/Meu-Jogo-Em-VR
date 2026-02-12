using UnityEngine;

public class ScoreNaoTrigger : MonoBehaviour
{
    public GameObject objetoCorreto;
    public int pontosAcerto = 10;
    public int pontosErro = -5; // Pode usar isso se quiser deixar din�mico

    private void OnTriggerEnter(Collider other)
    {
        // DICA: Adicionei um .Trim() para garantir que n�o tenha espa�os vazios atrapalhando o nome
        string nomeObjeto = other.gameObject.name.Replace("(Clone)", "").Trim();

        if (nomeObjeto == objetoCorreto.name)
        {
            // ERROU
            ScoreManager.instance.AddScore(-0, -5f);
            Debug.Log("ACERTO");
        }
        else
        {
            // ERROU
            ScoreManager.instance.AddScore(-0, -5f);
            Debug.Log("ERRO");
        }

        // --- AQUI ESTAVA O PROBLEMA ---
        // Apaguei o "AddScore" que estava sobrando aqui embaixo.
        // S� deixe o Destroy:

        Destroy(other.gameObject);
    }
}