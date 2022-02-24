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
    private bool isOccupied;
    private GameObject fries, drink, plus1, plus2, burger;
    private List<GameObject> entireBurger = new List<GameObject>();
    
    
    



    // Start is called before the first frame update
    void Start()
    {
        
      
        

        


    }

    private void OnTriggerEnter(Collider other)
    {
        
        isOccupied = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(drink);
        
        Destroy(plus1);
        Destroy(fries);
        Destroy(plus2);
        positionFood.transform.DetachChildren();
        foreach(GameObject ingredient in entireBurger)
        {
            Destroy(ingredient);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isOccupied)
        {
            // pour les frites
            fries = Instantiate(friesPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            fries.transform.SetParent(positionFood.transform, false);

            // Plus
            plus1 = Instantiate(plusPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            plus1.transform.SetParent(positionFood.transform, false);

            // pour le burger
            int rand = Random.Range(0, listHamburger.Count);
            Recipes actualRecipe = listHamburger[rand];
            foreach (GameObject ingredient in actualRecipe.ingredientRecipes)
            {
                burger = Instantiate(ingredient, new Vector3(0, 0, 0), Quaternion.identity);
                entireBurger.Add(burger);
                burger.transform.SetParent(positionIngredientBurger.transform, false);
                

            }
            positionIngredientBurger.transform.Rotate(0, 0, 0);

            positionIngredientBurger.transform.SetParent(positionFood.transform, false);

            // Plus
            plus2 = Instantiate(plusPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            plus2.transform.SetParent(positionFood.transform, false);

            // pour la boisson
            int rand2 = Random.Range(0, listDrink.Count);
            drink = Instantiate(listDrink[rand2], new Vector3(0, 0, 0), Quaternion.identity);
            drink.transform.SetParent(positionFood.transform, false);

            isOccupied = false;
        }
    }
}
