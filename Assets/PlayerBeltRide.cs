using UnityEngine;

public class PlayerBeltRider : MonoBehaviour
{
    private CharacterController _cc;
    
    [Header("Configurações")]
    public float rayLength = 1.2f; // Ajuste se o player for muito alto/baixo
    public LayerMask beltLayer;    // Importante: Crie uma Layer "Esteira" se puder

    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 1. Verifica o chão logo abaixo do player
        RaycastHit hit;
        // O raio sai do centro do player e vai pra baixo
        if (Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hit, rayLength, beltLayer))
        {
            // 2. Verifica se o chão tem o script da esteira
            ConveyorBelt belt = hit.collider.GetComponent<ConveyorBelt>();
            
            // Tenta pegar no pai também (caso o collider seja filho)
            if (belt == null) belt = hit.collider.GetComponentInParent<ConveyorBelt>();

            if (belt != null)
            {
                // 3. Aplica o movimento EXTRA da esteira
                // O Time.deltaTime já está sendo aplicado lá no MovePosition da esteira? 
                // Não, o Move precisa de deslocamento (Velocidade * Tempo)
                _cc.Move(belt.WorldVelocity * Time.deltaTime);
            }
        }
    }
    
    // Desenha o raio na cena pra você ver se tá alcançando a esteira
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position + Vector3.up * 0.1f, transform.position + Vector3.up * 0.1f + Vector3.down * rayLength);
    }
}