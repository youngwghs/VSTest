using UnityEngine;
using System.Collections;
//Superclass
//: indicates the class to the right is inheritable code
public class Entity : ScriptableObject {

    public string Name;
    public int Age;
    public string Faction;
    public string Occupation;
    public int Level = 1;
    public int Health = 2;
    public int Strength = 1;
    public int Magic = 0;
    public int Defense = 0;
    public int Speed = 1;
    public int Damage = 1;
    public int Armor = 0;
    public int NoOfAttacks = 1;
    public string Weapon;
    public Vector2 Position;
	
}
