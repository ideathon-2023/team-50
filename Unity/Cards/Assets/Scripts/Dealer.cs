using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;  

public class Dealer : MonoBehaviour
{

    public static string[] suits = new string[] {"clubs","diamonds", "hearts", "spades"};
    public static string[] values = new string[] {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};

    public List<string> deck;
    public GameObject deck_object;
    public int players = 4; //same no. of empty to be created at aappropriate angels
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;

    // Start is called before the first frame update
    void Start()
    {
     Playcards();   
    }

    // Update is called once per frame
    void Update()
    {
        bool A_pressed = Input.GetKeyUp(KeyCode.A);
        if(A_pressed){
            print("dis");
            Distribute();
        }
    }

    public void Playcards(){
        deck = GenerateDeck();
        Shuffle(deck);  
        foreach(string card in deck){
            print(card);
        }
    }

    public static List<string> GenerateDeck(){
        List<string> newDeck = new List<string>();
        foreach(string s in suits){
            foreach(string v in values){
                newDeck.Add(s+"_" + v);
            }
        } 

        return newDeck;
    }

    void Shuffle<T>(List<T> list){
        System.Random random = new System.Random();
        int n = list.Count;
        while(n>1){
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] =  temp;
        }
    }

    //can remove this with a numbered array
    private GameObject FindChild(GameObject Parent, string name_c){
        for(int i = 0; i<Parent.transform.childCount;i++){
            if(Parent.transform.GetChild(i).name == name_c)
            {
                print(Parent.transform.GetChild(i).name);
                return Parent.transform.GetChild(i).gameObject;
                
            }
        }

    print("null");
    print(name_c);
    return null;
    }

    public void Distribute(){
        float z_off = 0;
        for(int i = 0; i<13; i++){
            GameObject Card = FindChild(deck_object,deck[i]);
            Vector3 loc = P1.transform.position;
            loc.x += z_off*(float)(Math.Pow(-1,i));       
            Card.transform.position = loc;
            Card.transform.Rotate(180.0f,0.0f,0.0f);
            z_off += 0.75F*(float)((i%2) - 1);
        }

    }
}
