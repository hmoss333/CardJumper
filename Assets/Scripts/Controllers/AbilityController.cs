using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour {

    public enum Ability { Dash, DoubleJump, Melee, Gun, WallJump }
    public static Ability ability;
    public static bool dash;
    public static bool doubleJump;
    public static bool melee;
    public static bool gun;
    public static bool wallJump;


    // Use this for initialization
    void Start () {
        ResetAll();
	}
	
	public void Initialize()
    {
        Start();
    }

    void ResetAll()
    {
        dash = false;
        doubleJump = false;
        melee = false;
        gun = false;
        wallJump = false;
    }

    public static void ActivateAbility (Ability selectedAbility)
    {
        Debug.Log("Activate: " + selectedAbility.ToString());
        switch (selectedAbility)
        {            
            case Ability.Dash:
                dash = true;
                break;
            case Ability.DoubleJump:
                doubleJump = true;
                break;
            case Ability.Melee:
                melee = true;
                break;
            case Ability.Gun:
                gun = true;
                break;
            case Ability.WallJump:
                wallJump = true;
                break;
            default:
                Debug.Log("Ability not found: " + selectedAbility.ToString());
                break;
        }
    }

    public static void DeactivateAbility(Ability selectedAbility)
    {
        Debug.Log("Deactivate: " + selectedAbility.ToString());
        switch (selectedAbility)
        {
            case Ability.Dash:
                dash = false;
                break;
            case Ability.DoubleJump:
                doubleJump = false;
                break;
            case Ability.Melee:
                melee = false;
                break;
            case Ability.Gun:
                gun = false;
                break;
            case Ability.WallJump:
                wallJump = false;
                break;
            default:
                Debug.Log("Ability not found: " + selectedAbility.ToString());
                break;
        }
    }

}
