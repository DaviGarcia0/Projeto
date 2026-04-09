using UnityEngine;

public class XpController : MonoBehaviour
{
    public static XpController instance;

    [Header("XP")]
    public int currentXP = 0;
    public int level = 1;
    public int xpToNextLevel = 20;

    private void Awake()
    {
        instance = this;
    }

    public void GainXP(int amount)
    {
        currentXP += amount;

        Debug.Log("XP: " + currentXP + "/" + xpToNextLevel);

        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        currentXP = 0;
        xpToNextLevel += 10; // aumenta dificuldade

        Debug.Log("SUBIU DE NÍVEL! Level: " + level);
    }
}