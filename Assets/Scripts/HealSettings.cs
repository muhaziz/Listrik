using UnityEngine;

[CreateAssetMenu(fileName = "HealingSettings", menuName = "Settings/Healing Settings")]
public class HealingSettings : ScriptableObject
{
    public Vector3 targetScale = Vector3.one; // Skala target penyembuhan (default: Vector3 satu)
    public float healingSpeed = 1f; // Kecepatan penyembuhan (default: 1)
}
