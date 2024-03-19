using UnityEngine;

[CreateAssetMenu(fileName = "ScaleRecoveryConfig", menuName = "ScriptableObjects/ScaleRecoveryConfig", order = 1)]
public class ScaleRecoveryConfig : ScriptableObject
{
    public enum ScaleType { Scale, RecoverSlow, ReduceSlow }

    public ScaleType scaleType;
    public float scaleSpeed = 0.1f;
    public Vector3 target;

}
