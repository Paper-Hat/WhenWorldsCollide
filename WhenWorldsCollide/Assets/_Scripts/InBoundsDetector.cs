using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Checks for inBounds
/// Ruben Sanchez
/// 
/// </summary>

//DONT USE THIS
public class InBoundsDetector : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D boundryCollider;

    [SerializeField]
    private LayerMask boundryLayer;

    [SerializeField]
    private UnityEvent onOutOfBounds;

    [SerializeField]
    private PlayerHealth[] _players = new PlayerHealth[4];

    private void Start(){
        boundryCollider = gameObject.GetComponentInChildren<CircleCollider2D>();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(boundryCollider.transform.position, boundryCollider.radius, boundryLayer);

        for (int i = 0; i < colliders.Length; i++){
            _players[i] = colliders[i].GetComponent<PlayerHealth>();
        }
    }

    void Update ()
    {
        foreach (var c in _players){
            if (c != null){
                if ((c.transform.position - boundryCollider.transform.position).sqrMagnitude >
                    boundryCollider.radius * boundryCollider.radius){
                    Debug.Log("OUT" + c);
                }
            }
        }
    }
}
