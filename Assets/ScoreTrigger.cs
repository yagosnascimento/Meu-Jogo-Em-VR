using UnityEngine;
using System.Collections; // Necessário para a Coroutine

public class ScoreTrigger : MonoBehaviour
{
    public GameObject objetoCorreto;
    public int pontosAcerto = 10;
    public int pontosErro = -10;

    [Header("Configurações de Áudio")]
    public AudioSource audioSource;
    public AudioClip somAcerto;
    public AudioClip somErro;

    private void OnTriggerEnter(Collider other)
    {
        // Pegamos o nome e limpamos (conforme sua lógica)
        string nomeObjeto = other.gameObject.name.Replace("(Clone)", "").Trim();

        if (nomeObjeto == objetoCorreto.name)
        {
            // ACERTOU
            ScoreManager.instance.AddScore(pontosAcerto, 5f);
            TocarSom(somAcerto);
            StartCoroutine(FeedbackVisualEDestruir(other.gameObject, Color.green));
        }
        else
        {
            // ERROU
            ScoreManager.instance.AddScore(pontosErro, -5f);
            TocarSom(somErro);
            StartCoroutine(FeedbackVisualEDestruir(other.gameObject, Color.red));
        }
    }

    void TocarSom(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    IEnumerator FeedbackVisualEDestruir(GameObject obj, Color cor)
    {
        // 1. Desativa o Collider para a caixa não bater em nada enquanto brilha
        Collider col = obj.GetComponent<Collider>();
        if (col) col.enabled = false;

        // 2. Muda a cor da caixinha
        Renderer rend = obj.GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            // Isso cria uma instância temporária do material na cor desejada
            rend.material.color = cor;
        }

        // 3. Espera um curto tempo (0.3 segundos) para o jogador ver o brilho
        yield return new WaitForSeconds(0.3f);

        // 4. Agora sim, destrói o objeto
        Destroy(obj);
    }
}