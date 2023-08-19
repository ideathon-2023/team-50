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
        //float x_off = 0;
        float y_off = 0.0002f;
        float angle_off = 10.0f;
        float ang = -60.0f;
        //Create dedicated function or script for this

        Vector3 loc = P1.transform.position;
        loc.z += 0.5f;
        Vector3 rot = loc;
        rot.z -= 0.5f;
        for(int i = 0; i<13; i++){
            GameObject Card = FindChild(deck_object,deck[i]);
            //loc.x += x_off*(float)(Math.Pow(-1,i));
            //rot.x -=0.3f;
            //loc.x -= 0.5f;
            
            loc.y += y_off*(float)(i+1);            
            Card.transform.position = loc;
            Card.transform.Rotate(180.0f,0.0f,0.0f); //face up
            
            Card.transform.RotateAround(rot, Vector3.up, ang);
            ang += angle_off;   
            //x_off += 0.75F*(float)((i%2) - 1);
        }
        loc = P3.transform.position;
        rot = loc;
        loc.z -= 0.5f;
        ang = -60;
        for(int i = 13; i<26; i++){
            GameObject Card = FindChild(deck_object,deck[i]);
            loc.y += y_off*(float)(i+1);            
            Card.transform.position = loc;
            
            Card.transform.RotateAround(rot, Vector3.down, ang);
            ang += angle_off;
        }

        loc = P4.transform.position;
        rot = loc;
        loc.x -= 0.5f;
        ang = -60;
        for(int i = 26; i<39; i++){
            GameObject Card = FindChild(deck_object,deck[i]);
            loc.y += y_off*(float)(i+1);            
            Card.transform.position = loc;
            //Card.transform.Rotate(0.0f,90.0f,90.0f); //find a way to just change one axis; prolly vector3.up
            Card.transform.RotateAround(loc,Vector3.up,90.0f); 
            Card.transform.RotateAround(rot, Vector3.up, ang);
            ang += angle_off;
        }

        loc = P2.transform.position;
        rot = loc;
        loc.x += 0.5f;
        ang = -60;
        for(int i =39; i<52; i++){
            GameObject Card = FindChild(deck_object,deck[i]);
            loc.y += y_off*(float)(i+1);            
            Card.transform.position = loc;
            //Card.transform.Rotate(0.0f,90.0f,90.0f); //find a way to just change one axis; prolly vector3.up
            Card.transform.RotateAround(loc,Vector3.up,-90.0f); 
            Card.transform.RotateAround(rot, Vector3.up, ang);
            ang += angle_off;
        }

    }
}
