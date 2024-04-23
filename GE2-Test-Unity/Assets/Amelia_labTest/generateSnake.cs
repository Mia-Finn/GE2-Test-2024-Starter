using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateSnake : MonoBehaviour
{
    //Add fields for length, frequency, start_angle, base_size, multiplier
    public float length;
    public int freq;
    public int start_angle;
    public int base_size;
    public int multiplier;

    public GameObject[] sections;

    /*
    private MeshCollider mesh;
    private BoxCollider coll;
    */

    // Start is called before the first frame update
    void Start()
    {
        /*
        mesh = GetComponent<MeshCollider>();
        coll = GetComponent<BoxCollider>();
        */
    }

    // Update is called once per frame
    void Update()
    {
        // coll.size = (5,5,5);

        //render sections of snake
        /*
        for(int i = 0; i < sections.Length; i++)
        {
            GameObject startSect = (i == 0)
                ? this.gameObject;
        }
        

        for (int i = 0; i < sections.Length; i++)
        {
            GameObject prevBone = (i == 0)
                    ? this.gameObject
                    : sections[i - 1];
            GameObject bone = sections[i];

            Vector3 offset = bone.transform.position
                - prevBone.transform.position;
            offset = Quaternion.Inverse(prevBone.transform.rotation)
                * offset;

            offsets.Add(offset);
        }
        */

        //draw gizmo
        OnDrawGizmos();
    }

    private void OnDrawGizmos()
    {
    }
}
