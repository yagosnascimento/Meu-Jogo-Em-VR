using UnityEngine;
using TMPro; // Importante para usar os textos bonitos

public class LeaderboardDisplay : MonoBehaviour
{
    [Header("Conexões")]
    public LeaderboardManager leaderboardManager; // O cérebro
    public TextMeshProUGUI[] linhasDeTexto; // As linhas onde vamos escrever (ex: Top 1, Top 2...)

    void Start()
    {
        // Tenta atualizar a lista assim que o objeto aparece
        AtualizarPlacar();
    }

    public void AtualizarPlacar()
    {
        if (leaderboardManager == null) return;

        // 1. Pega a lista de recordes
        var lista = leaderboardManager.entries;

        // 2. Passa por cada linha de texto que criamos na tela
        for (int i = 0; i < linhasDeTexto.Length; i++)
        {
            // Se existir um recorde para esta posição (ex: existe um 3º lugar?)
            if (i < lista.Count)
            {
                // Escreve: "1. Yago - 1500"
                linhasDeTexto[i].text = (i + 1) + ". " + lista[i].playerName + "   " + lista[i].score;
            }
            else
            {
                // Se não tiver ninguém nessa posição, deixa vazio
                linhasDeTexto[i].text = "---";
            }
        }
    }
}