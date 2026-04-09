using UnityEngine;

public class XpGem : MonoBehaviour
{
    public int xpValue = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            XpController.instance.GainXP(xpValue);
            Destroy(gameObject);
        }
    }
}