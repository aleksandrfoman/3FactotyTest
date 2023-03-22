using UnityEngine;
using UnityEngine.Events;

namespace Content.Scripts
{
    public class InputTrigger : MonoBehaviour
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
                curPlayer = null;
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
}
