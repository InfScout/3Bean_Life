using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
    {
        public Image[] tabs;
        public GameObject[] pages;

        private void Start()
        {
            ActivateTab(0);
        }

        public void ActivateTab(int tabNo)
        {
            for (int i = 0; i < pages.Length; i++)
            {
                pages[i].SetActive(false);  
                tabs[i].color = Color.grey;
            }
            pages[tabNo].SetActive(true);
            tabs[tabNo].color = Color.white;
        }
        
        
        
        
        
        
    }
