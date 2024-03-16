using UnityEngine;

[CreateAssetMenu(fileName = "ScaleRecoveryConfig", menuName = "ScriptableObjects/ScaleRecoveryConfig", order = 1)]
public class ScaleRecoveryConfig : ScriptableObject
{
    public enum ScaleType { Instant, Slow }

    public ScaleType scaleType; // Jenis pemulihan skala
    public bool isInstant;
    public float scaleSpeed = 0.1f; // Kecepatan pemulihan skala

}
