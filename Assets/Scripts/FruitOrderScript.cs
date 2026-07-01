using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitOrderScript : MonoBehaviour{

    [SerializeField]
    private GameObject[] baskets = new GameObject[4];
    [SerializeField]
    private GameObject[] fruit_icons = new GameObject[4];
    [SerializeField]
    private Transform[] icon_positions = new Transform[4];

    public int[] fruit_order = new int[]{0, 1, 2, 3};

    void Start(){
        Shuffle(fruit_order);

        for (int idx = 0; idx < fruit_order.Length; idx++){
            baskets[idx].gameObject.GetComponent<BucketScript>().fruit_type = fruit_order[idx];
            GameObject fruit_icon = Instantiate(fruit_icons[fruit_order[idx]], new Vector3(0, 0, 0), Quaternion.identity);
            fruit_icon.transform.SetParent(icon_positions[idx], false);
        }
    }

    void Shuffle(int[] nums){
        for (int t = 0; t < nums.Length; t++ )
        {
            int tmp = nums[t];
            int r = Random.Range(t, nums.Length);
            nums[t] = nums[r];
            nums[r] = tmp;
        }
    }
}
