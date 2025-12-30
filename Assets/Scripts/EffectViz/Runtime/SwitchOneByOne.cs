using System.Collections.Generic;
using UnityEngine;

namespace EffectViz.Runtime
{
    public class SwitchOneByOne : MonoBehaviour
    {
        [SerializeField] private List<GameObject> prefabs;
        [SerializeField] private Vector3 offset;

        public EffectViz.Runtime.IntVariable currentSelected;
        public float switchCoolDown = .5f;
        
        private float _currentTime = .5f;

        private void Start()
        {
            Clear();
            Init(currentSelected.value);
        }

        public int SanitizedAdd(int value) => (currentSelected.value + value) % prefabs.Count;

        [ContextMenu("Clear All")]
        public void Clear()
        {
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                var o = transform.GetChild(i).gameObject;
                o.SetActive(false);
            }
        }


        private void Init(int currentSelectedValue)
        {
            var o = prefabs[currentSelectedValue];
            o.transform.localPosition = offset;
            o.SetActive(true);
        }

        private void Update()
        {
            _currentTime  -= Time.deltaTime;
            if (_currentTime >= 0f) return;
            float horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal == 0) return;
            _currentTime = switchCoolDown;
            currentSelected.value = SanitizedAdd(0 < horizontal ? 1 : 0);
            Clear();
            Init(currentSelected.value);
        }
    }
}