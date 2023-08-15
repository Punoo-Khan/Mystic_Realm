using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    public Transform target; // This is your enemy's Transform
    public float offsetFromScreenBorder = 50.0f; // Distance from the screen border

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector3 targetScreenPos = cam.WorldToScreenPoint(target.position);

        if (targetScreenPos.x < 0 || targetScreenPos.x > Screen.width || targetScreenPos.y < 0 || targetScreenPos.y > Screen.height)
        {
            Vector3 cappedTargetScreenPos = targetScreenPos;
            cappedTargetScreenPos.x = Mathf.Clamp(cappedTargetScreenPos.x, 0, Screen.width);
            cappedTargetScreenPos.y = Mathf.Clamp(cappedTargetScreenPos.y, 0, Screen.height);

            Vector3 directionToTarget = (cappedTargetScreenPos - targetScreenPos).normalized;
            Vector3 arrowPos = cappedTargetScreenPos + directionToTarget * offsetFromScreenBorder;
            transform.position = arrowPos;

            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle - 90);
        }
        else
        {
            // Hide the indicator if the enemy is on the screen
            gameObject.SetActive(false);
        }
    }
}
    