using UnityEngine;
using UnityEngine.Events;
public class OutputTrigger : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent<Player> OnTrigger;
    private bool isInTrigger;
    private Player curPlayer;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player!=null)
        {
            isInTrigger = true;
            curPlayer = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<Player>();
        
        if (player!=null)
        {
            isInTrigger = false;
        }
    }

    private void Update()
    {
        if (isInTrigger)
        {
            OnTrigger.Invoke(curPlayer);
        }
    }
}
