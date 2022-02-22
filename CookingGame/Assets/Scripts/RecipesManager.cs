using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesManager : MonoBehaviour
{
    public GameObject positionIngredientBurger;
    public GameObject positionFood;
    public GameObject plusPrefab;
    public List<Recipes> listHamburger = new List<Recipes>();
    public List<GameObject> listDrink = new List<GameObject>();
    public GameObject friesPrefab;
    //public float xPositionTopBread;
    //public float yPositionTopBread;
    



    // Start is called before the first frame update
    void Start()
    {
        
      
        // pour les frites
        GameObject fries = Instantiate(friesPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        fries.transform.SetParent(positionFood.transform, false);

        // Plus
        Instantiate(plusPrefab, new Vector3(0, 0, 0), Quaternion.identity).transform.SetParent(positionFood.transform, false);

        // pour le burger
        int rand = Random.Range(0, listHamburger.Count);
        Recipes actualRecipe = listHamburger[rand];
        foreach (GameObject ingredient in actualRecipe.ingredientRecipes)
        {
            GameObject burger = Instantiate(ingredient, new Vector3(0, 0, 0), Quaternion.identity);

            burger.transform.SetParent(positionIngredientBurger.transform, false);

        }
        positionIngredientBurger.transform.SetParent(positionFood.transform, false);

        // Plus
        Instantiate(plusPrefab, new Vector3(0, 0, 0), Quaternion.identity).transform.SetParent(positionFood.transform, false);

        // pour la boisson
        int rand2 = Random.Range(0, listDrink.Count);
        GameObject drink = Instantiate(listDrink[rand2], new Vector3(0, 0, 0), Quaternion.identity);
        drink.transform.SetParent(positionFood.transform, false);

        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
