using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Turn System
    public Characters turnSide = Characters.Player; // 0 --> Player, 1 --> Enemy

    // global variables for player and enemy characters
    public float playerDamageMultiplier = Constants.DamageConstants.initalPlayerMultiplier;
    public float enemyDamageMultiplier = Constants.DamageConstants.initalEnemyMultiplier;
    public int playerMana = Constants.PlayerConstants.initialMana;

    void Update()
    {
        
    }

    public PlayerController initializePlayerController()
    {
        return new PlayerController(
            fullHealth: Constants.PlayerConstants.initialFullHealth,
            shield: Constants.PlayerConstants.initialShield,
            strength: Constants.PlayerConstants.initalStrength,
            name: "SixtyFour");
    }
}
