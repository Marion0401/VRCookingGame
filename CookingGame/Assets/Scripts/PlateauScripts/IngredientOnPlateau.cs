using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientOnPlateau : MonoBehaviour
{
    [SerializeField] private GameObject assemblieBurgerCollider;
    [SerializeField] private GameObject assemblieBoissonFrieCollider;
    public List<EnumIngredient> burgerIngredient = new List<EnumIngredient>();
    public EnumIngredient frieIngredient;
    public EnumIngredient sodaIngredient;

    public void ResetPlateau()
    {
        assemblieBurgerCollider.GetComponent<AssemblageBurger>().ResetBurger();
        assemblieBurgerCollider.GetComponent<AssemblageBoissonFrie>().ResetBoissonFrie();
        frieIngredient = EnumIngredient.None;
        sodaIngredient = EnumIngredient.None;
        burgerIngredient = new List<EnumIngredient>();
    }

}
