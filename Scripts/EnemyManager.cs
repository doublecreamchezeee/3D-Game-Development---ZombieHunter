using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    public Animator animator;
    public float damageHit = 10f;
    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        gameManager = GameObject.FindWithTag("Game Manager");

        float healthBonus = (gameManager.GetComponent<GameManager>().round - 1) * 10;

        health += healthBonus;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            animator.SetBool("isDead", false);
        }
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        if (GetComponent<NavMeshAgent>().destination == null)
        {
            return;
        }
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1 && distance > 15 && player.GetComponent<PlayerMovement>().isGrounded)
        {
            GetComponent<NavMeshAgent>().speed = 1.5f;
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);
        }
        else if (GetComponent<NavMeshAgent>().velocity.magnitude > 1 && distance <= 15 && player.GetComponent<PlayerMovement>().isGrounded)
        {
            GetComponent<NavMeshAgent>().speed = 3.5f;
            animator.SetBool("isRunning", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", false);
        }
        else if (!player.GetComponent<PlayerMovement>().isGrounded)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", true);
        }

        if (health <= 0)
        {
            GetComponent<NavMeshAgent>().speed = 0f;
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isDead", true);
            
            StartCoroutine(DestroyAfter3Sec());
        }
        

    }
    IEnumerator DestroyAfter3Sec()
    {
        yield return new WaitForSeconds(3f);
        gameManager.GetComponent<GameManager>().coin += 10;
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerManager>().TakeDame(damageHit);
        }
    }
}
