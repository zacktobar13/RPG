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

    public GameObject meleeRight;

    GameObject player;
    PlayerStatus playerStatus;
    
    void Start()
    {
        player = PlayerReference.player;
        playerStatus = player.GetComponent<PlayerStatus>();
    }
    
    void Update()
    {
        if (player == null)
        {
            return;
        }

        if (Vector3.Distance(transform.position, player.transform.position) > meleeRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
        }
        else if (Time.time > lastAttack + attackCooldown)
        {
            StartCoroutine("MeleeAttack");
            lastAttack = Time.time;
        }
    }

    IEnumerator MeleeAttack()
    {
        meleeRight.SetActive(true);
        lastAttack = Time.time;
        yield return new WaitForSeconds(.25f);
        meleeRight.SetActive(false);
    }
}
