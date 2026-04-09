using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 5f;
    public float lifetime = 3f;

    void Start()
    {
        // Destrói o projétil após alguns segundos para não pesar o jogo
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move o projétil para frente
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se acertar um inimigo, causa dano e se destrói
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

