using UnityEngine;

[CreateAssetMenu(fileName = "ScaleRecoveryConfig", menuName = "ScriptableObjects/ScaleRecoveryConfig", order = 1)]
public class ScaleRecoveryConfig : ScriptableObject
{
    public enum RecoveryType { Instant, Slow }

    public RecoveryType recoveryType; // Jenis pemulihan skala
    public float recoverySpeed = 0.1f; // Kecepatan pemulihan skala
    public float maxReduction = 0.5f; // Persentase maksimum dari ukuran asli
}
