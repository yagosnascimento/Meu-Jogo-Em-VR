using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 2.0f;
    public bool invertDirection = false;

    // Essa propriedade calcula a velocidade real no mundo para quem perguntar
    public Vector3 WorldVelocity
    {
        get
        {
            // Se os itens estavam indo certo com transform.right, mantemos aqui
            Vector3 dir = invertDirection ? -transform.right : transform.right;
            return dir * speed;
        }
    }

    // Mantém a física das CAIXAS (Rigidbody) funcionando
    private void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null && !rb.isKinematic)
        {
            rb.MovePosition(rb.position + WorldVelocity * Time.deltaTime);
        }
    }
    
    // PODE REMOVER O ONTRIGGERSTAY DAQUI, NÃO VAMOS MAIS USAR PARA O PLAYER
}