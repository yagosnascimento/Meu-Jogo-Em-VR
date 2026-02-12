using System.Collections.Generic;
using UnityEngine;
using System.IO; // Necessário para mexer com arquivos
using System.Linq; // Necessário para ordenar listas facilmente

public class LeaderboardManager : MonoBehaviour
{
    // O nome do arquivo onde vamos salvar. No Quest 2, isso fica numa pasta interna segura.
    private string filePath;

    // A nossa lista de recordes carregada na memória
    public List<LeaderboardEntry> entries = new List<LeaderboardEntry>();

    // Limite de quantos nomes aparecem no placar (Top 10)
    private int maxEntries = 10;

    private void Awake()
    {
        // Define o caminho do arquivo: .../Android/data/com.seu.jogo/files/leaderboard.json
        filePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");

        // Carrega os dados assim que o jogo abre
        LoadLeaderboard();
    }

    // Função para adicionar um novo Recorde
    public void AddEntry(string name, int score)
    {
        // 1. Cria o novo registro
        LeaderboardEntry newEntry = new LeaderboardEntry(name, score);

        // 2. Adiciona na lista
        entries.Add(newEntry);

        // 3. Ordena a lista (Maior pontuação primeiro) e remove o excesso (mantém só Top 10)
        entries = entries.OrderByDescending(x => x.score).Take(maxEntries).ToList();

        // 4. Salva no disco
        SaveLeaderboard();
    }

    private void SaveLeaderboard()
    {
        // Precisamos de um "pacote" para salvar a lista, pois o JsonUtility do Unity não salva Listas puras diretamente
        LeaderboardData data = new LeaderboardData { entries = entries };

        // Transforma os dados em TEXTO (JSON)
        string json = JsonUtility.ToJson(data, true);

        // Escreve o texto no arquivo
        File.WriteAllText(filePath, json);

        Debug.Log("Leaderboard salvo em: " + filePath);
    }

    private void LoadLeaderboard()
    {
        // Verifica se o arquivo existe antes de tentar ler
        if (File.Exists(filePath))
        {
            // Lê o texto do arquivo
            string json = File.ReadAllText(filePath);

            // Transforma o TEXTO de volta em DADOS (C#)
            LeaderboardData data = JsonUtility.FromJson<LeaderboardData>(json);

            // Atualiza nossa lista local
            entries = data.entries;
        }
    }

    // Classe auxiliar interna apenas para ajudar o JsonUtility a salvar a lista
    [System.Serializable]
    private class LeaderboardData
    {
        public List<LeaderboardEntry> entries;
    }
}