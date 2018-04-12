using System.Collections;
using UnityEngine;

/*
 * Manages player, power-ups, and enemies initialization
 */
public class MainGameController : MonoBehaviour {

    public Transform gameSceneRoot;
    public Player playerPrefab;
    public PowerUp powerUpPrefab;
    public Enemy[] enemiesPrefab;

    private int playerScore;
    private bool stopSpawning;
    
    //Clears or initialize the game scene
    public void SetGameScene(ApplicationState currentState, ApplicationState nextState)
    {
        if (currentState != ApplicationState.PAUSE && nextState == ApplicationState.GAME)
        {
            this.InitGameScene();
        }
        else if (nextState != ApplicationState.GAME && nextState != ApplicationState.PAUSE)
        {
            this.ClearGameScene();
        }
    }

    public int GetPlayerScore()
    {
        return this.playerScore;
    }

    public void AddToScore(int scoreToAdd)
    {
        this.playerScore += scoreToAdd;
    }

    public void TrySpawnPowerUp(Vector3 position)
    {
        if (UnityEngine.Random.Range(0, 100) < 20)
        {

            PowerUp powerUp = GameObject.Instantiate(this.powerUpPrefab) as PowerUp;
            powerUp.transform.position = position;
            powerUp.transform.SetParent(this.gameSceneRoot.transform, false);
        }
    }

    private void ClearGameScene()
    {
        this.stopSpawning = true;
        foreach (Transform transform in this.gameSceneRoot)
        {
            Destroy(transform.gameObject);
        }
    }

    private void InitGameScene()
    {
        this.playerScore = 0;

        //Player instantiation
        Player player = GameObject.Instantiate(this.playerPrefab) as Player;
        player.transform.SetParent(this.gameSceneRoot.transform, false);

        StartCoroutine(this.SpawnEnemiesCoroutine());
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        this.stopSpawning = false;
        Camera mainCamera = Camera.main;
        Vector2 spawnPosition = Vector2.zero;
        Vector2 spawnScreenPosition = Vector2.zero;
        yield return new WaitForSeconds(2); // Deplay enemies spawning
        while (!this.stopSpawning)
        {
            if (ApplicationController.Instance.applicationState == ApplicationState.GAME)
            {
                float randomSpawnCooldown = UnityEngine.Random.Range(0.25f, 1.5f); // Spawn enemy at variable speed
                int randomEnemyType = UnityEngine.Random.Range(0, this.enemiesPrefab.Length); // Spawn a random type of enemy
                int randomSpawnPosition = UnityEngine.Random.Range(50, Screen.width - 50); // Spawn an enemy at a variable position

                //Get spawn position on top of the screen
                spawnScreenPosition.x = randomSpawnPosition;
                spawnScreenPosition.y = Screen.height + 5;
                spawnPosition = mainCamera.ScreenToWorldPoint(spawnScreenPosition);

                //Enemy instantiation
                Enemy enemy = GameObject.Instantiate(this.enemiesPrefab[randomEnemyType]) as Enemy;
                enemy.transform.SetParent(this.gameSceneRoot.transform, false);
                enemy.transform.position = spawnPosition;

                yield return new WaitForSeconds(randomSpawnCooldown);
            }
            else
            {
                yield return 0;
            }
        }
    }
}
