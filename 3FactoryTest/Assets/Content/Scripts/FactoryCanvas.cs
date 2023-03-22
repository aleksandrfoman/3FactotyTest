using TMPro;
using UnityEngine;

namespace Content.Scripts
{
    public class FactoryCanvas : MonoBehaviour
    {
        [SerializeField]
        private Factory factory;
        [SerializeField] 
        private TMP_Text infoText;

        private void Awake()
        {
            factory.OnUpdateUi.AddListener(UpdateAlert);
        }
        public void UpdateAlert(string alert)
        {
            if(alert!=infoText.text)
                infoText.text = alert;
        }
    }
}
