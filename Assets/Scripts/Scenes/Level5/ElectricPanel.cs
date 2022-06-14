using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Level5
{
    public class ElectricPanel : MonoBehaviour
    {
        [SerializeField]
        private Breaker[] breakers;

        [SerializeField] 
        private Image status;

        [SerializeField] 
        private Sprite goodStatus;

        public event Action OnClose;

        private void Awake()
        {
            breakers = GetComponentsInChildren<Breaker>();
        }

        private void Start()
        {
            foreach (var breaker in breakers)
            {
                breaker.Button.onClick.AddListener(() =>
                {
                    if (IsSolved())
                    {
                        StartCoroutine(ClosePanel());
                    }
                });
            }
        }

        private bool IsSolved() => breakers.All(x => x.On);

        private IEnumerator ClosePanel()
        {
            status.sprite = goodStatus;
            
            // Prevent altering state after puzzle is finished.
            foreach (var breaker in breakers)
            {
                breaker.Button.onClick.RemoveAllListeners();
            }
            
            yield return new WaitForSeconds(2.0f);
            gameObject.SetActive(false);
            
            OnClose?.Invoke();
        }
    }
}