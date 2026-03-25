using UnityEngine;

namespace ApexRush.Systems
{
    public class AdaptiveDifficulty : MonoBehaviour
    {
        [Range(0.7f, 1.3f)] public float minScale = 0.8f;
        [Range(0.7f, 1.3f)] public float maxScale = 1.2f;
        public AnimationCurve catchUpCurve = AnimationCurve.EaseInOut(0, 1.2f, 1, 0.9f);

        public float ComputeAIScale(float normalizedPlayerLead)
        {
            float curve = catchUpCurve.Evaluate(Mathf.Clamp01(normalizedPlayerLead));
            return Mathf.Clamp(curve, minScale, maxScale);
        }
    }
}
