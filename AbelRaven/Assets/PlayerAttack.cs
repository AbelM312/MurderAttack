using System.Globalization;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.0f;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    //WinController winController;

    public int numberOfCrows;


    private void Start()
    {
        numberOfCrows = 10;

        //winController = GetComponent<WinController>();

    }

    // Update is called once per frame
    void Update()
    {
        // Assuming you move the player using Rigidbody2D or Transform.Translate in 2D
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Check for attack input
        if (Input.GetButtonDown("Fire1"))
        {
            Attack(movementDirection);
        }

        if (numberOfCrows == 0)
        {

            YouWin();

        }

        
    }

    void Attack(Vector2 direction)
    {
        // Calculate the position for the overlap circle based on player's position and movement direction
        Vector2 attackPosition = (Vector2)transform.position + direction * attackRange;

        // Debugging: Print the calculated attack position to the console
        Debug.Log("Calculated Attack Position: " + attackPosition);

        // Create an overlap circle to check for a single enemy in the calculated attack position
        Collider2D hitEnemy = Physics2D.OverlapCircle(attackPosition, attackRange, enemyLayer);

        if (hitEnemy != null)
        {
            // Debugging: Print the name and position of the detected enemy
            Debug.Log("Detected enemy: " + hitEnemy.name + " at position: " + hitEnemy.transform.position);

            // You can implement damage logic here or call a function on the enemy script
            // For example, destroy the enemy:
            Destroy(hitEnemy.gameObject);

            numberOfCrows --;
        }
    }

    void YouWin()
    {

        Debug.Log("You Win!");

    }

    // Visualize the attack range in the scene view
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + (Vector2)attackPoint.localPosition, attackRange);
    }
}