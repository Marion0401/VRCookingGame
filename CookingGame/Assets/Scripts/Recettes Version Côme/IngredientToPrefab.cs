using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientToPrefab : MonoBehaviour
{
    public static IngredientToPrefab instance;

    [SerializeField] public GameObject BottomBread;
    [SerializeField] public GameObject Salad;
    [SerializeField] public GameObject Tomato;
    [SerializeField] public GameObject Steak;
    [SerializeField] public GameObject TopBread;
    [SerializeField] public GameObject HotDogBread;
    [SerializeField] public GameObject Sausage;
    [SerializeField] public GameObject Fries;


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        
    }
}
