using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeBehavior : MonoBehaviour
{
    [SerializeField]
    int damage;

    [SerializeField]
    float attackCooldown;
    float lastAttack;

    [SerializeField]
    float movementSpeed;

    [SerializeField]
    float meleeRange;

    GameObject player;
    PlayerStatus playerStatus;
    
    void Start()
    {
        player = PlayerReference.player;
        playerStatus = player.GetComponent<PlayerStatus>();
    }
    
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > meleeRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
        }
        else if (Time.time > lastAttack + attackCooldown)
        {
            playerStatus.ApplyDamage(damage);
            lastAttack = Time.time;
        }
    }
}
