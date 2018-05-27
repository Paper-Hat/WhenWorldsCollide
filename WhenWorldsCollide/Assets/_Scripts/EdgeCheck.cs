using UnityEngine;

/// <summary>
/// Check and report the player that went out of bounds
/// </summary>
public class EdgeCheck : MonoBehaviour
{
    public float ArenaSize = 25f;
    public Vector3 ArenaCenter;

    public void Awake(){
        ArenaSize = GetComponent<CircleCollider2D>().radius;
        ArenaCenter = transform.position;
    }

    /// <summary>
    /// why the fuck were we calculating distance every frame
    /// </summary>
    /// <param name="c"></param>
    void OnTriggerExit2D(Collider2D c){
        c.GetComponentInParent<PlayerHealth>().Die();
    }
}
