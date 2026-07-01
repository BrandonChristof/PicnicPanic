using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform container;
    private float spawn_rate = 3.5f;
    private float speed = 1.5f;
    private float counter = 1f;

    [SerializeField]
    private GameObject[] fruits = new GameObject[4];

    [SerializeField]
    private GameObject[] fruit_preview = new GameObject[4];

    [SerializeField]
    private Animator cloud_spawn_anim;

    private GameObject new_fruit;
    private GameObject next_fruit;
    private int rand_idx = 0;

    private float timer = 1f;
    public AudioSource spawn_sound;

    void Start(){
        UpcomingFruit();
    }

    void FixedUpdate(){
        timer += Time.deltaTime;
        if (timer > spawn_rate){
            SpawnFruit();
            timer = 0f;
            spawn_rate = (3.5f * UnityEngine.Mathf.Pow(0.97f, counter)) + 1.5f;
            speed += 0.03f;
            if (spawn_rate <= 1.5f){
                spawn_rate = 1.5f;
            }
            if (speed >= 3f){
                speed = 3f;
            }
            counter++;
        }
    }

    void UpcomingFruit(){
        fruit_preview[rand_idx].SetActive(false);
        rand_idx = Random.Range(0, fruits.Length);
        fruit_preview[rand_idx].SetActive(true);
    }

    void SpawnFruit(){
        cloud_spawn_anim.SetTrigger("fruit_spawned");
        next_fruit = fruits[rand_idx];
        if (rand_idx == 3){
            new_fruit = Instantiate(next_fruit, new Vector3(-1.3f, 9f, 0), Quaternion.identity);
        }
        else{
            new_fruit = Instantiate(next_fruit, new Vector3(-1.5f, 9f, 0), Quaternion.identity);
        }
        new_fruit.gameObject.GetComponent<FruitScript>().speed = speed;
        new_fruit.transform.SetParent(container);
        spawn_sound.Play(0);
        UpcomingFruit();
    }
}
