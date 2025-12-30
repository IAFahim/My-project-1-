using UnityEngine;

namespace EffectViz.Runtime
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "Game/Variable/Int", order = 0)]
    public class IntVariable : ScriptableObject
    {
        public int value;
    }
}