using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Controls turns and turn structure, and starts and ends the turns
/// </summary>
public class TurnController : MonoBehaviour
{
    public int turnCount;

    public GameObject enemy_;
    private GameObject[] cardsOnDeck;

    // Start is called before the first frame update
    void Start()
    {
        startFight(EnemyType.Normal, EnemyTier.Tier1, 1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void startFight(EnemyType enemyType, EnemyTier enemyTier, int enemyCount)
    {
        // Create enemy spawner object

        // Initialize player controller
        GameManager.Instance.initializePlayerController();

        // Spawn enemies
        GameManager.Instance.GetComponent<EnemySpawner>().spawnEnemies(enemyType, enemyTier, enemyCount);

        // Pass turn to Player
        GameManager.Instance.turnSide = Characters.Player;

        startNewTurn();
    }

    public void endTurn()
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
        foreach (var item in cards)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in lines)
        {
            Destroy(item.gameObject);
        }
        GameManager.Instance.turnSide = decideTurnSide(GameManager.Instance.turnSide);
        Debug.Log("TURN SIDE: " + GameManager.Instance.turnSide);
        if (GameManager.Instance.turnSide == Characters.Player)
        {
            GameManager.Instance.playerController.applyNextTurnDeltas();
            GameManager.Instance.playerController.normalizeDamageToEnemyMultipliers();
        }
        startNewTurn();
    }

    public void startNewTurn()
    {
        if (GameManager.Instance.turnSide == Characters.Player)
        {
            // TODO
            // create enemy intentions
            turnCount += 1;
            Debug.Log("TurnCOUNT: " + turnCount);

            GameManager.Instance.GetComponent<CardSpawner>().SpawnerStarter();
            GameManager.Instance.GetComponent<CardSpawner>().spawnOnce = true;

            GameManager.Instance.playerController.playerMana = Constants.PlayerConstants.initialMana;
           EnemyController.Instance.decideEnemyIntention_all();
            Debug.Log("Player Turn");
            // GameManager.Instance.playerController.applyStateEffects();
        } else if(GameManager.Instance.turnSide == Characters.Enemy)
        {
            // TODO
            EnemyController.Instance.applyDecidedIntentions_all();
            GameManager.Instance.GetComponent<CardSpawner>().spawnOnce = false;
            Invoke("endTurn", 2);
            EnemyController.Instance.applyNextTurnDamageMultiplier_all();
            Debug.Log("Enemy Turn");
            // apply enemy effects on enemies
            // wait at least 1.5 secs
        }
    }
    
    private Characters decideTurnSide(Characters currentSide)
    {
        if (currentSide == Characters.Player)
        {
            return Characters.Enemy;
        }else
        {
            return Characters.Player;
        }
    }
}