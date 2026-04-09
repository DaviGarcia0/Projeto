using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Configurações")]
    public GameObject bulletPrefab;
    public float fireRate = 1.5f;
    private float nextFireTime;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Atacar();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Atacar()
    {
        // Encontra todos os inimigos na cena
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        // Lógica para achar o inimigo mais próximo
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            // Calcula a direção para o inimigo
            Vector2 direction = (closestEnemy.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            // Cria o projétil rotacionado para o alvo
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle));
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, -angle));
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 2*angle));
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 2/angle));
        }   
    }
}
