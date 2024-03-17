using UnityEngine;

[CreateAssetMenu(fileName = "ScaleRecoveryConfig", menuName = "ScriptableObjects/ScaleRecoveryConfig", order = 1)]
public class ScaleRecoveryConfig : ScriptableObject
{
    public enum ScaleType { Recover, NORecover }

    public ScaleType scaleType;
    public bool isInstant;
    public float scaleSpeed = 0.1f;
    public float instantScale;

}
