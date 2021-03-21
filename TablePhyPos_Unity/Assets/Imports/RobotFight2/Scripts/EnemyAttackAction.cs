using UnityEngine;

[CreateAssetMenu(menuName ="A.I/Enemy Actions/Attack Action")]
public class EnemyAttackAction : EnemyAction
{
    public int attackDamage = 3;
    public float cooldown = 2;
    public float rates = 0.1f;

    public float minimumDistanceNeededToAttack = 0;
    public float maximumDistanceNeededToAttack = 3;

}
