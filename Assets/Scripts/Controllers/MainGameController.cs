using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour {

    public Transform gameSceneRoot;
    public Player playerPrefab;
    public Enemy[] enemiesPrefab;

    private int playerScore;
    private bool stopSpawning;

    public void SetGameScene(ApplicationState currentState, ApplicationState nextState)
    {
        if (nextState == ApplicationState.GAME)
        {
            this.InitGameScene();
        }
        else if (currentState == ApplicationState.GAME)
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

        //Player instanciation
        Player player = GameObject.Instantiate(this.playerPrefab) as Player;
        player.transform.SetParent(this.gameSceneRoot.transform, false);

        StartCoroutine(this.SpawnEnemyCoroutine());
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        this.stopSpawning = false;
        Camera mainCamera = Camera.main;
        Vector2 spawnPosition = Vector2.zero;
        Vector2 spawnScreenPosition = Vector2.zero;
        while (!this.stopSpawning)
        {
            float randomSpawnCooldown = UnityEngine.Random.Range(0.25f, 1.5f);
            int randomEnemyType = UnityEngine.Random.Range(0, this.enemiesPrefab.Length);
            int randomSpawnPosition = UnityEngine.Random.Range(0, Screen.width);

            //Get spawn position from screen size
            spawnScreenPosition.x = randomSpawnPosition;
            spawnScreenPosition.y = Screen.height + 5;
            spawnPosition = mainCamera.ScreenToWorldPoint(spawnScreenPosition);

            //Enemy instanciation
            Enemy enemy = GameObject.Instantiate(this.enemiesPrefab[randomEnemyType]) as Enemy;
            enemy.transform.SetParent(this.gameSceneRoot.transform, false);
            enemy.transform.position = spawnPosition;

            yield return new WaitForSeconds(randomSpawnCooldown);
        }
    }
}
