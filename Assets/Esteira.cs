using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 5.0f;

    // Este método é chamado enquanto algo estiver encostando na esteira
    private void OnCollisionStay(Collision collision)
    {
        // Tenta pegar o Rigidbody do objeto que caiu na esteira
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Move o objeto na direção "para frente" (forward) da esteira
            Vector3 movement = transform.right * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }
    }
}