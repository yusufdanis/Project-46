using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICardInfoInterface
{
    public string id { get; set; }
    public string name { get; set; }
    public CardTarget cardTarget { get; set; }
    public string description { get; set; }
    public List<string> types { get; set; }
    public int cost { get; set; }
    public Attributes attributes { get; set; }
}

// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var JsonHelper = JsonHelper.FromJson(jsonString);
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Attributes
{
    public int damage { get; set; }
    public int shield { get; set; }
    public object effects { get; set; }
    public int? amount { get; set; }
    public int damageMin { get; set; }
    public int damageMax { get; set; }
}

public class Player: ICardInfoInterface
{
}

public class Root
{
    public List<SingleEnemy> singleEnemy { get; set; }
    public List<Player> player { get; set; }
    public List<object> mutlipleEnemies { get; set; }
    public List<object> all { get; set; }
}

public class SingleEnemy: ICardInfoInterface
{
}
