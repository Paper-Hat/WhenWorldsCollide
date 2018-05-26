using System.Collections;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages Health for the player
/// Ruben Sanchez
/// 
/// -and only the health
/// Joel
/// </summary>

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int startingHealth;

    [SerializeField]
    private GameObject[] moons;

    [SerializeField]
    private UnityEvent onDeath;

    public delegate void onDeathEvent(int pID);
    public event onDeathEvent Died;

    public int playerID;

    private int currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
    }

    public void DecrementHealth()
    {
        if (currentHealth > 0)
        {
            Destroy(moons[currentHealth - 1]);
            currentHealth--;

            if (currentHealth == 0)
            {
                onDeath.Invoke();
            }
        }
    }

    public void Die(){
        gameObject.SetActive(false);
        ProCamera2D.Instance.RemoveCameraTarget(transform, 0f);
        Died(playerID);
    }

}
