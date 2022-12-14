using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memSystem : MonoBehaviour
{
    [SerializeField] private memButton butt1;
    [SerializeField] private memButton butt2;
    [SerializeField] private memButton butt3;
    [SerializeField] private List<int> correctSeq = new List<int>()
    {
        1, 1, 2, 3, 2, 3, 1, 2
    };
    [SerializeField] private GameObject iceCream;
    private List<int> curr = new List<int>();

    // Update is called once per frame
    void Update()
    {
      //if any are clicked
        if (butt1.clicked || butt2.clicked || butt3.clicked)
        {
            //if a button is clicked, turn it off and add associated value
            if (butt1.clicked)
            {
                curr.Add(1);
                butt1.clicked = false;
            }

            if (butt2.clicked)
            {
                curr.Add(2);
                butt2.clicked = false;
            }

            if (butt3.clicked)
            {
                curr.Add(3);
                butt3.clicked = false;
            }
            for (int i = 0; i < curr.Count; i++)
            {
                if (curr[i] != correctSeq[i])
                {
                    Debug.Log("You screwed up!");
                    Debug.Log("You were Supposed to put " + correctSeq[i]);
                    Debug.Log("But you put " + curr[i]);
                    curr.Clear();
                }
            }
            if (curr.Count == correctSeq.Count)
            {
                Debug.Log("Success!!!!");
                iceCream.transform.position = new Vector3(568, 7, 536);
                curr.Clear();
            }
        }
    }
}
