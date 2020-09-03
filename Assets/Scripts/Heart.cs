using UnityEngine;
using UnityEngine.UI;

namespace GandyLabs.MyZelda
{
    public class Heart : MonoBehaviour
    {

        public Image Full;
        public Image Half;
        public Image Empty;
        public float value = 1;

        public void TakeDamage() { value -= 0.5f; }

        private void Update()
        {
            disableAll();
            if (value == 1)
            {
                Full.enabled = true;
            }
            else if (value == 0.5f)
            {
                Half.enabled = true;
            }
            else
            {
                Empty.enabled = true;
            }
        }


        private void disableAll()
        {
            Full.enabled = false;
            Half.enabled = false;
            Empty.enabled = false;
        }
    }
}