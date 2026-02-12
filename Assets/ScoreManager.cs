using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("Conexão com o Placar")]
    public LeaderboardManager leaderboardManager; 

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText; 

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

        // --- [NOVO] SALVANDO NO LEADERBOARD ---
        if (leaderboardManager != null)
        {
            // Por enquanto usamos o nome "Jogador". Na próxima aula podemos mudar isso!
            leaderboardManager.AddEntry("Jogador", score);
            Debug.Log("✅ Pontuação enviada para o Leaderboard!");
        }
        else
        {
            Debug.LogWarning("⚠️ LeaderboardManager não foi conectado no Inspector!");
        }
        // --------------------------------------

        // Reinicia a fase após 3 segundos
        Invoke("ReiniciarFase", 3f);
    }

    void ReiniciarFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}