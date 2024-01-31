using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.0f;
    public Transform attackPoint;
    public LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        // Assuming you move the player using Rigidbody2D or Transform.Translate in 2D
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Check for attack input
        if (Input.GetButtonDown("T"))
        {
            Attack(movementDirection);
        }
    }

    void Attack(Vector2 direction)
    {
        // Create an overlap circle to check for enemies in the attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Destroy(gameObject);
            // You can implement damage logic here or call a function on the enemy script
            Debug.Log("Attacked: " + enemy.name);
        }
    }

    // Visualize the attack range in the scene view
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}