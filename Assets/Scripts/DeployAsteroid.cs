using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployAsteroid : MonoBehaviour
{
    public int energyInterval = 66;
    private int activations = 0;
    public Energy EnergyPrefab;
    public Asteroid AsteroidPrefab;
    public float respawnTime = 0.4f;
    private Vector2 screenBounds;
    public float astPosition = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }

    private void spawnAsteroid()
    {
        float variance = Random.Range(-60.0f, 60.0f);
        Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
        Vector3 position = new Vector3(screenBounds.x * astPosition, Random.Range(-screenBounds.y, screenBounds.y), 0.0f);
        Asteroid ast = Instantiate(this.AsteroidPrefab, position, rotation);
        ast.size = Random.Range(ast.minSize, ast.maxSize);
    }

    private void spawnEnergy()
    {
        float variance = Random.Range(-60.0f, 60.0f);
        Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
        Vector3 position = new Vector3(screenBounds.x * astPosition, Random.Range(-screenBounds.y, screenBounds.y), 0.0f);
        Energy ast = Instantiate(this.EnergyPrefab, position, rotation);
        ast.size = Random.Range(ast.minSize, ast.maxSize);
    }

    IEnumerator asteroidWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            if (activations < energyInterval)
            {
                spawnAsteroid();
                activations ++;
            }
            else
            {
                spawnEnergy();
                activations = 0;
            }
        }
       
    }
}
