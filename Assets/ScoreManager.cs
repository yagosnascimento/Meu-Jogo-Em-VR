using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Importante para reiniciar o jogo

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText; // Crie um novo texto na Unity e arraste para cá

    [Header("Configurações")]
    public float tempoRestante = 60f;
    private int score = 0;
    private bool jogoFinalizado = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (jogoFinalizado) return;

        if (tempoRestante > 0)
        {
            tempoRestante -= Time.deltaTime;
            UpdateUI();
        }
        else
        {
            FinalizarJogo();
        }
    }

    // Agora este método aceita os pontos E o bônus de tempo
    public void AddScore(int amount, float timeBonus)
    {
        if (jogoFinalizado) return;

        score += amount;
        tempoRestante += timeBonus;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (timerText != null)
            timerText.text = "Tempo: " + Mathf.Ceil(tempoRestante).ToString() + "s";
    }

    void FinalizarJogo()
    {
        jogoFinalizado = true;
        if (timerText != null) timerText.text = "TEMPO ESGOTADO!";
        Debug.Log("Fim de jogo! Pontos: " + score);

        // Reinicia a fase após 3 segundos
        Invoke("ReiniciarFase", 3f);
    }

    void ReiniciarFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}