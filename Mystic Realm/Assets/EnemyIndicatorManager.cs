using UnityEngine;
using System.Collections.Generic;

public class EnemyIndicatorManager : MonoBehaviour
{
    public GameObject enemyIndicatorPrefab; // Prefab of the arrow

    private List<EnemyIndicator> indicators = new List<EnemyIndicator>();

    private void Start()
    {
        // Find all enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy"); // Assuming enemies have the tag "Enemy"

        // For each enemy, instantiate an indicator and set it up
        foreach (GameObject enemy in enemies)
        {
            GameObject newIndicatorObj = Instantiate(enemyIndicatorPrefab, Vector3.zero, Quaternion.identity, transform);
            EnemyIndicator newIndicator = newIndicatorObj.GetComponent<EnemyIndicator>();

            if (newIndicator != null)
            {
                newIndicator.target = enemy.transform;
                indicators.Add(newIndicator);
            }
        }
    }

    private void Update()
    {
        // Update each indicator (though the indicators update themselves, you might want to handle deactivation or other logic here)
        foreach (EnemyIndicator indicator in indicators)
        {
            if (indicator.target == null) // If enemy is destroyed, remove the indicator
            {
                indicators.Remove(indicator);
                Destroy(indicator.gameObject);
            }
        }
    }
}
