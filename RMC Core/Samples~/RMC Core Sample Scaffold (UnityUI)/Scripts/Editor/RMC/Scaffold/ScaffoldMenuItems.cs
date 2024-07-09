using UnityEditor;
using UnityEngine;

namespace RMC.Core.Samples.Scaffold
{
	public static class ScaffoldMenuItems
	{
		//  Properties ------------------------------------

        
		//  Fields ----------------------------------------
		
		[MenuItem( ScaffoldConstants.PathMenuItemWindowCompanyProject + "/" + "Hello World", false,
					ScaffoldConstants.PriorityMenuItem_Examples)]
		public static void HelloWorld()
		{
			// Demo Only
			Debug.Log("Hello World!");
		}
		
	}
}
