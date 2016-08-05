using UnityEngine;
using System.Collections;

public class MathExt : MonoBehaviour {

    //Contains methods and values for linear interpolation
    public struct Interpolate
    {
        public bool ascending;
        public float value;

        public float getValue()
        {
            return value;
        }
        public void Rebound()
        {
            if (getValue() >= 1 || getValue() <= 0)
            {
                ascending = !ascending;
            }
        }
        public void Rebound(float min, float max)
        {
            if (getValue() > max || getValue() < min)
            {
                ascending = !ascending;
            }
        }
        public void Slide()
        {
            if (ascending)
            {
                value += Time.deltaTime;
            }
            else
            {
                value -= Time.deltaTime;
            }
            value = Mathf.Clamp01(value);
        }
    }
}
