using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {

	
	void Start ()
    {
		StartAdMobiComponent.GetInstance().ShowAdvert(StartAdMobiComponent.ALIGN_BOTTOM, StartAdMobiComponent.AD_PLACEID_DEFAULT);
	}
	
	
}
